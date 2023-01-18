using CatalogoVeiculos.Application.Dto;

namespace CatalogoVeiculos.Application.Interface
{
    public interface IModeloAppService
    {
        Task<bool> CadastrarModelo(ModeloDto modelo);
        Task<bool> AtualizarModelo(ModeloDto modelo);
        Task<bool> ExcluirModelo(int modeloId);
        Task<ModeloDto> BuscarModelo(int modeloId);
        Task<List<ModeloDto>> BuscarModeloPorMarca(int marcaId );
        Task<List<ModeloDto>> BuscarModelos();
    }
}
