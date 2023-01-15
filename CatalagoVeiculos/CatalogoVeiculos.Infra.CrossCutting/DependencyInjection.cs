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
            serviceCollection.AddTransient<IMarcaAppService, MarcaAppService>();
            serviceCollection.AddTransient<IModeloAppService, ModeloAppService>();
            serviceCollection.AddTransient<IUsuarioAppService, UsuarioAppService>();

            serviceCollection.AddTransient<IVeiculoService, VeiculoService>();
            serviceCollection.AddTransient<IMarcaService, MarcaService>();
            serviceCollection.AddTransient<IModeloService, ModeloService>();
            serviceCollection.AddTransient<IUsuarioService, UsuarioService>();

            serviceCollection.AddTransient<IVeiculoRepository, VeiculoRepository>();
            serviceCollection.AddTransient<IMarcaRepository, MarcaRepository>();
            serviceCollection.AddTransient<IModeloRepository, ModeloRepository>();
            serviceCollection.AddTransient<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
