using CatalogoVeiculos.Domain.Entities;
using CatalogoVeiculos.Domain.Interfaces.Repository;
using CatalogoVeiculos.Domain.Interfaces.Services;

namespace CatalogoVeiculos.Domain.Services
{
    public class ModeloService : IModeloService
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly IMarcaService _marcaService;
        public ModeloService(IModeloRepository modeloRepository, IMarcaService marcaService)
        {
            _modeloRepository = modeloRepository;
            _marcaService = marcaService;
        }

        public async Task<bool> AtualizarModelo(Modelo modelo)
        {
            var modeloAtualizado = await _modeloRepository.AtualizarModelo(modelo);
            return modeloAtualizado;
        }

        public async Task<Modelo> BuscarModelo(int modeloId)
        {
            var modelo = await _modeloRepository.BuscarModelo(modeloId);
            return modelo;
        }

        public async Task<List<Modelo>> BuscarModeloPorMarca(int marcaId)
        {
            var modelo = await _modeloRepository.BuscarModeloPorMarca(marcaId);
            return modelo;
        }

        public async Task<List<Modelo>> BuscarModelos()
        {
            var modelos = await _modeloRepository.BuscarModelos();
            return modelos;
        }

        public async Task<bool> CadastrarModelo(Modelo modelo)
        {
            var marca = await _marcaService.BuscarMarca(modelo.MarcaId);
            if (marca.MarcaId == 0)
                return false;

            var modeloCadastrado = await _modeloRepository.CadastrarModelo(modelo);
            return modeloCadastrado;
        }

        public async Task<bool> ExcluirModelo(int modeloId)
        {
            var veiculoExcluido = await _modeloRepository.ExcluirModelo(modeloId);
            return veiculoExcluido;
        }
    }
}
