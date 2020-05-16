using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vita.Persistance.Sql;
using Vita.Application.Users.Commands;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Vita.Application.Categories.Commands;
using MediatR;
using Vita.Persistance.Sql.Repositories;
using Vita.Domain.Aggregates.Categories;
using Vita.Domain.Aggregates.Users;
using Microsoft.Extensions.Configuration;

namespace Vita.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();

            AddApplicationBootstrapping(services);
            AddPersistanceBootstrapping(services);
        }

        private void AddApplicationBootstrapping(IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateCategoryCommand, bool>, CreateCategoryCommandHandler>();
            services.AddTransient<IRequestHandler<CreateUserCommand, bool>, CreateUserCommandHandler>();

        }

        private static void AddPersistanceBootstrapping(IServiceCollection services)
        {
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddDbContext<VitaDbContext>(options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Vita.Development;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod());
        }
    }
}
