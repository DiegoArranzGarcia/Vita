using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vita.API.Core;
using Vita.Application.Categories;
using Vita.Persistance.Categories;
using Vita.Persistance.Sql;
using Vita.Domain.Categories;
using System;
using Vita.Application.Users;
using Vita.Application.UsersCategories;
using Vita.Domain.UsersCategories;
using Vita.Persistance.Sql.UserCategories;
using Vita.Persistance.Sql.Users;
using Vita.Domain.Users;

namespace Vita.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            AddApplicationBootstrapping(services);
            AddPersistanceBootstrapping(services);

            AddAutomapperProfiles(services);
        }

        private void AddApplicationBootstrapping(IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserCategoryService, UserCategoryService>();
        }

        private static void AddPersistanceBootstrapping(IServiceCollection services)
        {
            services.AddDbContext<VitaDbContext>(options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Vita.Development;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                                                                   .UseLazyLoadingProxies());
            services.AddTransient<ICategoryRepository, SqlCategoryRepository>();
            services.AddTransient<IUserCategoryRepository, SqlUserCategoryRepository>();
            services.AddTransient<IUserRepository, SqlUserRepository>();
        }

        private void AddAutomapperProfiles(IServiceCollection services)
        {
            var config = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod());

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
