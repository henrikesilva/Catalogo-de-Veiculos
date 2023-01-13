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
            var connectionString = _configuration.GetSection("ConnectionStrings").GetSection("Connection").Value;
            if (connectionString == null)
                throw new ArgumentException("Não foi possivel obter a conexão com o banco de dados");

            return connectionString;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
