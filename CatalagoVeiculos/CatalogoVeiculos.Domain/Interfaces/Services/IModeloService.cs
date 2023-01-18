using CatalogoVeiculos.Domain.Entities;

namespace CatalogoVeiculos.Domain.Interfaces.Services
{
    public interface IModeloService
    {
        Task<bool> CadastrarModelo(Modelo modelo);
        Task<bool> AtualizarModelo(Modelo modelo);
        Task<bool> ExcluirModelo(int modeloId);
        Task<Modelo> BuscarModelo(int modeloId);
        Task<List<Modelo>> BuscarModeloPorMarca(int marcaId);
        Task<List<Modelo>> BuscarModelos();
    }
}
