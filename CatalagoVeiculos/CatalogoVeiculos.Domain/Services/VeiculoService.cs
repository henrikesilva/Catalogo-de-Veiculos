using CatalogoVeiculos.Domain.Entities;
using CatalogoVeiculos.Domain.Interfaces.Repository;
using CatalogoVeiculos.Domain.Interfaces.Services;

namespace CatalogoVeiculos.Domain.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<bool> AtualizarCadastroVeiculo(Veiculo veiculo)
        {
            var cadastroVeiculoAtualizado = await _veiculoRepository.AtualizarCadastroVeiculo(veiculo);
            return cadastroVeiculoAtualizado;
        }

        public async Task<bool> CadastrarVeiculo(Veiculo veiculo)
        {
            var veiculoCadastrado = await _veiculoRepository.CadastrarVeiculo(veiculo);
            return veiculoCadastrado;
        }

        public async Task<bool> ExcluirCadastroVeiculo(Veiculo veiculo)
        {
            var cadastroVeiculoExcluido = await _veiculoRepository.ExcluirCadastroVeiculo(veiculo);
            return cadastroVeiculoExcluido;
        }

        public async Task<Veiculo> SelecionarVeiculoEspecifico(int veiculoId)
        {
            var veiculo = await _veiculoRepository.SelecionarVeiculoEspecifico(veiculoId);
            return veiculo;
        }

        public async Task<List<Veiculo>> SelecionarVeiculos()
        {
            var veiculos = await _veiculoRepository.SelecionarVeiculos();
            return veiculos;
        }
    }
}
