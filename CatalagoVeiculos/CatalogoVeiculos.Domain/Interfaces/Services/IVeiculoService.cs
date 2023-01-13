using CatalogoVeiculos.Domain.Entities;

namespace CatalogoVeiculos.Domain.Interfaces.Services
{
    public interface IVeiculoService
    {
        Task<bool> CadastrarVeiculo(Veiculo veiculo);
        Task<bool> AtualizarCadastroVeiculo(Veiculo veiculo);
        Task<bool> ExcluirCadastroVeiculo(Veiculo veiculo);

        Task<List<Veiculo>> SelecionarVeiculos();
        Task<Veiculo> SelecionarVeiculoEspecifico(int veiculoId);
    }
}
