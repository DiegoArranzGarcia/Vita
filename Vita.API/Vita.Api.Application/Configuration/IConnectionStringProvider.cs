namespace Vita.Api.Application.Sql.Configuration
{
    public interface IConnectionStringProvider
    {
        string ConnectionString { get; }
    }
}
