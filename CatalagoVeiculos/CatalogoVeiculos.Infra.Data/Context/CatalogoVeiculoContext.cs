using Microsoft.Extensions.Configuration;

namespace CatalogoVeiculos.Infra.Data.Context
{
    public abstract class CatalogoVeiculoContext : IDisposable
    {
        IConfiguration _configuration;

        public CatalogoVeiculoContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connectionString = _configuration.GetConnectionString("CatalogoVeiculos");
            return connectionString;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
