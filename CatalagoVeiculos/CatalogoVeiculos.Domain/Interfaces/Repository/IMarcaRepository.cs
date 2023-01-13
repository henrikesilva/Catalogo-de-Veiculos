using CatalogoVeiculos.Domain.Entities;

namespace CatalogoVeiculos.Domain.Interfaces.Repository
{
    public interface IMarcaRepository
    {
        Task<int> CadastrarMarca(Marca marca);
        Task<bool> AtualizarMarca(Marca marca);
        Task<bool> ExcluirMarca(Marca marca);
        Task<Marca> BuscarMarca(int marcaId);
        Task<List<Marca>> BuscarMarca(Marca marca);
    }
}
