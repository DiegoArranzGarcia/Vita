namespace Vita.Identity.Application.Sql.Configuration
{
    public interface IConnectionStringProvider
    {
        string ConnectionString { get; }
    }
}
