using CatalogoVeiculos.Application.Dto;
using CatalogoVeiculos.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatalogoVeiculos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculosAppService _veiculosAppService;
        public VeiculoController(IVeiculosAppService veiculosAppService)
        {
            _veiculosAppService = veiculosAppService;
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> SelecionarVeiculos()
        {
            try
            {
                var veiculos = await _veiculosAppService.SelecionarVeiculos();
                if (veiculos.Any())
                    return Ok(veiculos);

                return NotFound("Não foram encontrados veiculos");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("buscar/{veiculoId}")]
        public async Task<IActionResult> SelecionarVeiculoPorId(int veiculoId)
        {
            if (veiculoId == 0)
            {
                return BadRequest("VeiculoId é obrigatório");
            }

            try
            {
                var veiculo = await _veiculosAppService.SelecionarVeiculoEspecifico(veiculoId);
                if (veiculo.Usuario == null)
                    return NotFound("Não foi encontrado veiculo");

                return Ok(veiculo);

            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarVeiculo(VeiculoDto veiculo)
        {
            try
            {
                var veiculoCadastrado = await _veiculosAppService.CadastrarVeiculo(veiculo);
                if (veiculoCadastrado)
                    return Ok("Veiculo cadastrado com sucesso!");

                return BadRequest("Ocorreu um erro ao cadastrar o veiculo");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarVeiculo(VeiculoDto veiculo)
        {
            try
            {
                var veiculoAtualizado = await _veiculosAppService.AtualizarCadastroVeiculo(veiculo);
                if (veiculoAtualizado)
                    return Ok("Veiculo atualizado com sucesso");

                return BadRequest("Ocorreu um erro ao cadastrar o veiculo");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("excluir")]
        public async Task<IActionResult> ExcluirVeiculo(VeiculoDto veiculo)
        {
            try
            {
                var veiculoExcluido = await _veiculosAppService.ExcluirCadastroVeiculo(veiculo);
                if (veiculoExcluido)
                    return Ok("Veiculo excluido com sucesso");

                return BadRequest("Ocorreu um erro ao excluir o veiculo");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}