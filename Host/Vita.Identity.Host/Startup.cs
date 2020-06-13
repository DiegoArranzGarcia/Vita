using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Vita.Identity.Application.Configuration;
using Vita.Identity.Application.Users.Queries;
using Vita.Identity.Domain.Aggregates.Users;
using Vita.Identity.Domain.Services;
using Vita.Identity.Host.Claims;
using Vita.Identity.Persistance.Sql;
using Vita.Identity.Persistance.Sql.Aggregates.Users;

namespace Vita.Identity
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                    .AddRazorRuntimeCompilation();

            services.AddSameSiteCookiePolicy();

            services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseSuccessEvents = true;
            }).AddInMemoryApiResources(Config.GetApis())
              .AddInMemoryIdentityResources(Config.GetIdentityResources())
              .AddInMemoryClients(Config.GetClients())
              .AddProfileService<ProfileService>();

            services.AddCors(options =>
            {
                options.AddPolicy("api", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            AddApplicationBootstrapping(services);
            AddPersistanceBootstrapping(services);
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


        public void Configure(IApplicationBuilder app)
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