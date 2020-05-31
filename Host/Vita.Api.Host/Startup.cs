using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MediatR;
using Microsoft.Extensions.Configuration;
using Vita.Api.Application.Categories.Commands;
using Vita.Api.Application.Configuration;
using Vita.Api.Domain.Aggregates.Categories;
using Vita.Api.Persistance.Sql.Aggregates.Categories;
using Vita.Api.Persistance.Sql;

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

            AddApplicationBootstrapping(services);
            AddPersistanceBootstrapping(services);
        }

        private void AddApplicationBootstrapping(IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateCategoryCommand));
            services.AddSingleton<IConnectionStringProvider>(new ConnectionStringProvider(Configuration.GetConnectionString("Vita.DbContext")));
        }

        private void AddPersistanceBootstrapping(IServiceCollection services)
        {
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddDbContext<VitaApiDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Vita.DbContext")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
