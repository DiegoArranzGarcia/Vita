using Azure;
using Azure.Identity;
using Azure.Security.KeyVault.Certificates;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Secrets;
using IdentityServer4.Models;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Vita.Identity.Application.Configuration;
using Vita.Identity.Application.Users.Queries;
using Vita.Identity.Domain.Aggregates.Users;
using Vita.Identity.Domain.Services;
using Vita.Identity.Host.Claims;
using Vita.Identity.Persistance.Sql;
using Vita.Identity.Persistance.Sql.Aggregates.Users;

namespace Vita.Identity.Host
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                    .AddRazorRuntimeCompilation();

            services.AddSameSiteCookiePolicy();

            Client[] clients = Configuration.GetSection("IdentityServer:Clients").Get<Client[]>();

            var identityServerBuilder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseSuccessEvents = true;
            }).AddInMemoryApiResources(Config.GetApis())
              .AddInMemoryIdentityResources(Config.GetIdentityResources())
              .AddInMemoryClients(clients)
              .AddProfileService<ProfileService>()
              .AddSigningCredential(GenerateCertFromAsym());

            var allowedOrigins = clients.Select(x => x.ClientUri).ToList();

            services.AddCors(options =>
            {
                options.AddPolicy("api", policy =>
                {
                    policy.WithOrigins(allowedOrigins.ToArray()).AllowAnyHeader().AllowAnyMethod();
                });
            });

            AddApplicationBootstrapping(services);
            AddPersistanceBootstrapping(services);
        }


        private X509Certificate2 GenerateCertFromAsym()
        {
            var secretClient = new SecretClient(new Uri(Configuration["KeyVault:BaseUrl"]), new DefaultAzureCredential());
            Response<KeyVaultSecret> secret = secretClient.GetSecret("SignInCredentialsCert");

            return new X509Certificate2(Convert.FromBase64String(secret.Value.Value));
        }

        private void AddApplicationBootstrapping(IServiceCollection services)
        {
            services.AddMediatR(typeof(GetUserByEmailQuery));
            services.AddSingleton<IConnectionStringProvider>(new ConnectionStringProvider(Configuration.GetConnectionString("VitaIdentityDbContext")));
        }

        private void AddPersistanceBootstrapping(IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddDbContext<VitaIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("VitaIdentityDbContext")));
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSerilogRequestLogging();
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("api");

            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}