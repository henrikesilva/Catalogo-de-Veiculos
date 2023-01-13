using CatalogoVeiculos.Application.Interface;
using CatalogoVeiculos.Application.Service;
using CatalogoVeiculos.Domain.Interfaces.Repository;
using CatalogoVeiculos.Domain.Interfaces.Services;
using CatalogoVeiculos.Domain.Services;
using CatalogoVeiculos.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogoVeiculos.Infra.CrossCutting
{
    public class DependencyInjection
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IVeiculosAppService, VeiculosAppService>();

            serviceCollection.AddTransient<IVeiculoService, VeiculoService>();

            serviceCollection.AddTransient<IVeiculoRepository, VeiculoRespository>();
        }
    }
}
