using CatalogoVeiculos.Domain.Entities;

namespace CatalogoVeiculos.Domain.Interfaces.Repository
{
    public interface IModeloRepository
    {
        Task<bool> CadastrarModelo(Modelo modelo);
        Task<bool> AtualizarModelo(Modelo modelo);
        Task<bool> ExcluirModelo(Modelo modelo);
        Task<Modelo> BuscarModelo(int modeloId);
        Task<List<Modelo>> BuscarModeloPorMarca(int marcaId);
        Task<List<Modelo>> BuscarModelos();
    }
}
