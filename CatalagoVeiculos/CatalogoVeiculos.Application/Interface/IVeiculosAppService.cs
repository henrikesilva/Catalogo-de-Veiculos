using CatalogoVeiculos.Application.Dto;

namespace CatalogoVeiculos.Application.Interface
{
    public interface IVeiculosAppService
    {
        Task<bool> CadastrarVeiculo(VeiculoDto veiculo);
        Task<bool> AtualizarCadastroVeiculo(VeiculoDto veiculo);
        Task<bool> ExcluirCadastroVeiculo(int veiculoId);

        Task<List<VeiculoDto>> SelecionarVeiculos();
        Task<VeiculoDto> SelecionarVeiculoEspecifico(int veiculoId);
    }
}
