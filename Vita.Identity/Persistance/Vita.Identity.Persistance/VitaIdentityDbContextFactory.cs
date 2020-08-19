using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Vita.Identity.Persistance.Sql
{
    public class VitaIdentityDbContextFactory : IDesignTimeDbContextFactory<VitaIdentityDbContext>
    {
        public VitaIdentityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VitaIdentityDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=Vita.Identity.Development;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new VitaIdentityDbContext(optionsBuilder.Options);
        }
    }
}
