using CatalogoVeiculos.Application.Dto;

namespace CatalogoVeiculos.Application.Interface
{
    public interface IMarcaAppService
    {
        Task<bool> CadastrarMarca(MarcaDto marca);
        Task<bool> AtualizarMarca(MarcaDto marca);
        Task<bool> ExcluirMarca(int marcaId);
        Task<MarcaDto> BuscarMarca(int marcaId);
        Task<List<MarcaDto>> BuscarMarcas();
    }
}
