using CatalogoVeiculos.Domain.Entities;

namespace CatalogoVeiculos.Domain.Interfaces.Services
{
    public interface IMarcaService
    {
        Task<bool> CadastrarMarca(Marca marca);
        Task<bool> AtualizarMarca(Marca marca);
        Task<bool> ExcluirMarca(Marca marca);
        Task<Marca> BuscarMarca(int marcaId);
        Task<List<Marca>> BuscarMarcas();
    }
}
