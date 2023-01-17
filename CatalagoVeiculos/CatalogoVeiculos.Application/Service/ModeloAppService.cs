using AutoMapper;
using CatalogoVeiculos.Application.Dto;
using CatalogoVeiculos.Application.Interface;
using CatalogoVeiculos.Domain.Entities;
using CatalogoVeiculos.Domain.Interfaces.Services;

namespace CatalogoVeiculos.Application.Service
{
    public class ModeloAppService : IModeloAppService
    {
        private readonly IModeloService _modeloService;
        private readonly IMapper _mapper;

        public ModeloAppService(IModeloService modeloService, IMapper mapper)
        {
            _modeloService = modeloService;
            _mapper = mapper;
        }

        public async Task<bool> AtualizarModelo(ModeloDto modelo)
        {
            var modeloAtualizado = await _modeloService.AtualizarModelo(_mapper.Map<Modelo>(modelo));
            return modeloAtualizado;
        }

        public async Task<ModeloDto> BuscarModelo(int modeloId)
        {
            var modelo = _mapper.Map<ModeloDto>(await _modeloService.BuscarModelo(modeloId));
            return modelo;
        }

        public async Task<List<ModeloDto>> BuscarModeloPorMarca(int marcaId)
        {
            var modelo = _mapper.Map<List<ModeloDto>>(await _modeloService.BuscarModeloPorMarca(marcaId));
            return modelo;
        }

        public async Task<List<ModeloDto>> BuscarModelos()
        {
            var modelos = _mapper.Map<List<ModeloDto>>(await _modeloService.BuscarModelos());
            return modelos;
        }

        public async Task<bool> CadastrarModelo(ModeloDto modelo)
        {
            var modeloCadastrado = await _modeloService.CadastrarModelo(_mapper.Map<Modelo>(modelo));
            return modeloCadastrado;
        }

        public async Task<bool> ExcluirModelo(ModeloDto modelo)
        {
            var modeloExcluido = await _modeloService.ExcluirModelo(_mapper.Map<Modelo>(modelo));
            return modeloExcluido;
        }
    }
}
