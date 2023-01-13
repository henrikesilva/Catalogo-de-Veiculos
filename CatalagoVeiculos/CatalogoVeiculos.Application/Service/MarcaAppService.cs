using AutoMapper;
using CatalogoVeiculos.Application.Dto;
using CatalogoVeiculos.Application.Interface;
using CatalogoVeiculos.Domain.Entities;
using CatalogoVeiculos.Domain.Interfaces.Services;

namespace CatalogoVeiculos.Application.Service
{
    public class MarcaAppService : IMarcaAppService
    {
        private readonly IMarcaService _marcaService;
        private readonly IMapper _mapper;

        public MarcaAppService(IMarcaService marcaService, IMapper mapper)
        {
            _marcaService = marcaService;
            _mapper = mapper;
        }

        public async Task<bool> AtualizarMarca(MarcaDto marca)
        {
            var marcaAtualizada = await _marcaService.AtualizarMarca(_mapper.Map<Marca>(marca));
            return marcaAtualizada;
        }

        public async Task<MarcaDto> BuscarMarca(int marcaId)
        {
            var marca = _mapper.Map<MarcaDto>(await _marcaService.BuscarMarca(marcaId));
            return marca;
        }

        public async Task<List<MarcaDto>> BuscarMarcas()
        {
            var marcas = _mapper.Map<List<MarcaDto>>(await _marcaService.BuscarMarcas());
            return marcas;
        }

        public async Task<bool> CadastrarMarca(MarcaDto marca)
        {
            var marcaCadastrada = await _marcaService.CadastrarMarca(_mapper.Map<Marca>(marca));
            return marcaCadastrada;
        }

        public async Task<bool> ExcluirMarca(MarcaDto marca)
        {
            var marcaExcluida = await _marcaService.ExcluirMarca(_mapper.Map<Marca>(marca));
            return marcaExcluida;
        }
    }
}
