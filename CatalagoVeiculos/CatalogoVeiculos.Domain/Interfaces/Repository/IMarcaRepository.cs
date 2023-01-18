using CatalogoVeiculos.Domain.Entities;

namespace CatalogoVeiculos.Domain.Interfaces.Repository
{
    public interface IMarcaRepository
    {
        Task<bool> CadastrarMarca(Marca marca);
        Task<bool> AtualizarMarca(Marca marca);
        Task<bool> ExcluirMarca(int marcaId);
        Task<Marca> BuscarMarca(int marcaId);
        Task<List<Marca>> BuscarMarcas();
    }
}
