using IdentityServer4.Models;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Linq;
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

            X509Certificate2 cert = GetJwtCertificate();
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
              .AddSigningCredential(cert);

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

        private X509Certificate2 GetJwtCertificate()
        {
            using X509Store certStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            certStore.Open(OpenFlags.ReadOnly);

            var certCollection = certStore.Certificates.Find(
                X509FindType.FindByThumbprint,
                Configuration["IdentityServer:CertificateThumbprint"],
                false);

            if (certCollection.Count == 0)
                throw new Exception("The certificate wasn't found!");

            return certCollection[0];
        }

        private void AddApplicationBootstrapping(IServiceCollection services)
        {
            services.AddMediatR(typeof(GetUserByEmailQuery));
            services.AddSingleton<IConnectionStringProvider>(new ConnectionStringProvider(Configuration.GetConnectionString("Vita.Identity.DbContext")));
        }

        private void AddPersistanceBootstrapping(IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddDbContext<VitaIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Vita.Identity.DbContext")));
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