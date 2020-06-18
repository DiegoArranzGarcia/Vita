using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Vita.Api.Application.Categories.Commands;
using Vita.Api.Application.Configuration;
using Vita.Api.Domain.Aggregates.Categories;
using Vita.Api.Domain.Aggregates.Goals;
using Vita.Api.Persistance.Sql;
using Vita.Api.Persistance.Sql.Aggregates.Categories;
using Vita.Api.Persistance.Sql.Aggregates.Goals;

namespace Vita.Api.Host
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
            services.AddControllers();
            services.AddCors();

            services.AddAuthentication("Bearer")
                    .AddJwtBearer("Bearer", options =>
                    {
                        options.Authority = "https://localhost:44360";
                        options.RequireHttpsMetadata = false;

                        options.Audience = "api";
                    });

            AddApplicationBootstrapping(services);
            AddPersistanceBootstrapping(services);
        }

        private void AddApplicationBootstrapping(IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateCategoryCommand));
            services.AddSingleton<IConnectionStringProvider>(new ConnectionStringProvider(Configuration.GetConnectionString("Vita.Api.DbContext")));
        }

        private void AddPersistanceBootstrapping(IServiceCollection services)
        {
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IGoalsRepository, GoalsRepository>();
            services.AddDbContext<VitaApiDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Vita.Api.DbContext")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
