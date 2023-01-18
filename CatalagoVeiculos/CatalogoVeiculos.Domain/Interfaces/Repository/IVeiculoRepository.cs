using CatalogoVeiculos.Domain.Entities;

namespace CatalogoVeiculos.Domain.Interfaces.Repository
{
    public interface IVeiculoRepository
    {
        Task<bool> CadastrarVeiculo(Veiculo veiculo);
        Task<bool> AtualizarCadastroVeiculo(Veiculo veiculo);
        Task<bool> ExcluirCadastroVeiculo(int veiculoId);

        Task<List<Veiculo>> SelecionarVeiculos();
        Task<Veiculo> SelecionarVeiculoEspecifico(int veiculoId);
    }
}
