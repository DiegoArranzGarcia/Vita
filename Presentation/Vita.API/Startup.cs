﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vita.Persistance.Sql;
using Vita.Application.Users.Commands;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Vita.Application.Categories.Commands;
using MediatR;
using Vita.Domain.Aggregates.Categories;
using Vita.Domain.Aggregates.Users;
using Microsoft.Extensions.Configuration;
using Vita.Application.Users.Queries;
using Vita.Application.Categories.Queries;
using Vita.Persistance.Sql.Aggregates.Categories;
using Vita.Persistance.Sql.Aggregates.Users;

namespace Vita.API
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
            services.AddScoped<IUserQueries, UserQueries>(factory => new UserQueries(Configuration.GetConnectionString("Vita.DbContext")));
            services.AddScoped<ICategoryQueries, CategoryQueries>(factory => new CategoryQueries(Configuration.GetConnectionString("Vita.DbContext")));
        }

        private void AddPersistanceBootstrapping(IServiceCollection services)
        {
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddDbContext<VitaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Vita.DbContext")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());            
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers() );
        }
    }
}
