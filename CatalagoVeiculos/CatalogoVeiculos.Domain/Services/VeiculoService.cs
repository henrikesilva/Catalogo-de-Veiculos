using CatalogoVeiculos.Domain.Entities;
using CatalogoVeiculos.Domain.Interfaces.Repository;
using CatalogoVeiculos.Domain.Interfaces.Services;

namespace CatalogoVeiculos.Domain.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IModeloService _modeloService;

        public VeiculoService(IVeiculoRepository veiculoRepository, IModeloService modeloService)
        {
            _veiculoRepository = veiculoRepository;
            _modeloService = modeloService;
        }

        public async Task<bool> AtualizarCadastroVeiculo(Veiculo veiculo)
        {
            var cadastroVeiculoAtualizado = await _veiculoRepository.AtualizarCadastroVeiculo(veiculo);
            return cadastroVeiculoAtualizado;
        }

        public async Task<bool> CadastrarVeiculo(Veiculo veiculo)
        {
            /*var marcaCadastrada = await _marcaService.BuscarMarca(veiculo.Modelo.Marca.MarcaId);
            if(marcaCadastrada.MarcaId == 0)
                return false;*/

            var modeloCadastrado = await _modeloService.BuscarModelo(veiculo.ModeloId);
            if (modeloCadastrado.ModeloId == 0)
                return false;


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
