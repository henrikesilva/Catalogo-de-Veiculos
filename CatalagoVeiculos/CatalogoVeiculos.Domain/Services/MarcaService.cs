using CatalogoVeiculos.Domain.Entities;
using CatalogoVeiculos.Domain.Interfaces.Repository;
using CatalogoVeiculos.Domain.Interfaces.Services;

namespace CatalogoVeiculos.Domain.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;
        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public async Task<bool> AtualizarMarca(Marca marca)
        {
            var marcaAtualizada = await _marcaRepository.AtualizarMarca(marca);
            return marcaAtualizada;
        }

        public async Task<Marca> BuscarMarca(int marcaId)
        {
            var marca = await _marcaRepository.BuscarMarca(marcaId);
            return marca;
        }

        public async Task<List<Marca>> BuscarMarcas()
        {
            var marcas = await _marcaRepository.BuscarMarcas();
            return marcas;
        }

        public async Task<bool> CadastrarMarca(Marca marca)
        {
            var marcaId = await _marcaRepository.CadastrarMarca(marca);
            return marcaId;
        }

        public async Task<bool> ExcluirMarca(int marcaId)
        {
            var marcaExcluida = await _marcaRepository.ExcluirMarca(marcaId);
            return marcaExcluida;
        }
    }
}
