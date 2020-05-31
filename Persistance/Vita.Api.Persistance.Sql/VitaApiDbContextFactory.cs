using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Vita.Api.Persistance.Sql
{
    public class VitaApiDbContextFactory : IDesignTimeDbContextFactory<VitaApiDbContext>
    {
        public VitaApiDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VitaApiDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Vita.Development;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new VitaApiDbContext(optionsBuilder.Options);
        }
    }
}
