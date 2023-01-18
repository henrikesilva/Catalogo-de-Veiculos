using AutoMapper;
using CatalogoVeiculos.Application.Dto;
using CatalogoVeiculos.Application.Interface;
using CatalogoVeiculos.Domain.Entities;
using CatalogoVeiculos.Domain.Interfaces.Services;

namespace CatalogoVeiculos.Application.Service
{
    public class VeiculosAppService : IVeiculosAppService
    {
        private readonly IMapper _mapper;
        private readonly IVeiculoService _veiculoService;

        public VeiculosAppService(IMapper mapper, IVeiculoService veiculoService)
        {
            _mapper = mapper;
            _veiculoService = veiculoService;
        }

        public async Task<bool> AtualizarCadastroVeiculo(VeiculoDto veiculo)
        {
            var veiculoAtualizado = await _veiculoService.AtualizarCadastroVeiculo(_mapper.Map<Veiculo>(veiculo));
            return veiculoAtualizado;
        }

        public async Task<bool> CadastrarVeiculo(VeiculoDto veiculo)
        {
            var veiculoCadastrado = await _veiculoService.CadastrarVeiculo(_mapper.Map<Veiculo>(veiculo));
            return veiculoCadastrado;
        }

        public async Task<bool> ExcluirCadastroVeiculo(int veiculoId)
        {
            var veiculoExcluido = await _veiculoService.ExcluirCadastroVeiculo(_mapper.Map<int>(veiculoId));
            return veiculoExcluido;
        }

        public async Task<VeiculoDto> SelecionarVeiculoEspecifico(int veiculoId)
        {
            var veiculo = _mapper.Map<VeiculoDto>(await _veiculoService.SelecionarVeiculoEspecifico(veiculoId));
            return veiculo;
        }

        public async Task<List<VeiculoDto>> SelecionarVeiculos()
        {
            var veiculos = _mapper.Map<List<VeiculoDto>>(await _veiculoService.SelecionarVeiculos());
            return veiculos;
        }
    }
}
