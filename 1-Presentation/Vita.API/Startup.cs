using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vita.API.Core;
using Vita.Persistance.Categories;
using Vita.Persistance.Sql;
using Vita.Domain.Categories;
using Vita.Domain.UsersCategories;
using Vita.Persistance.Sql.UsersCategories;
using Vita.Persistance.Sql.Users;
using Vita.Domain.Users;
using Vita.Application.Users.Commands;
using Vita.Application.UsersCategories.Commands;
using Vita.Application.Categories.Queries;
using Vita.Application.UsersCategories.Queries;
using Vita.Application.UsersGoals.Queries;
using Vita.Domain.UsersGoals;

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
            services.AddScoped<IGetAllDefaultCategoriesQuery, GetAllDefaultCategoriesQuery>();
            services.AddScoped<IGetAllCategoriesQuery, GetAllCategoriesQuery>();
            services.AddScoped<ICreateUserCategoriesCommand, CreateUserCategoriesCommand>();
            services.AddScoped<ICreateUserCommand, CreateUserCommand>();
            services.AddScoped<IGetAllUserCategoriesForUserQuery, GetAllUserCategoriesForUserQuery>();
            services.AddScoped<IGetAllUserGoalForUserQuery, GetAllUserGoalForUserQuery>();
        }

        private static void AddPersistanceBootstrapping(IServiceCollection services)
        {
            services.AddDbContext<VitaDbContext>(options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Vita.Development;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                                                                   .UseLazyLoadingProxies());
            services.AddTransient<ICategoryRepository, SqlCategoryRepository>();
            services.AddTransient<IUserCategoryRepository, SqlUserCategoryRepository>();
            services.AddTransient<IUserRepository, SqlUserRepository>();
            services.AddTransient<IUserGoalRepository, SqlUserRepository>();
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
