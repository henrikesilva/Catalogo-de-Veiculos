using CatalogoVeiculos.Application.Dto;
using CatalogoVeiculos.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatalogoVeiculos.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaAppService _marcaAppService;
        public MarcaController(IMarcaAppService marcaAppService)
        {
            _marcaAppService = marcaAppService;
        }

        [HttpGet("buscar/{marcaId}")]
        public async Task<IActionResult> BuscarMarca(int marcaId)
        {
            try
            {
                var marca = await _marcaAppService.BuscarMarca(marcaId);
                if(marca == null)
                    return NotFound("Não foram encontrados registros");

                return Ok(marca);
                
            }
            catch(ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("BuscarTodas")]
        public async Task<IActionResult> BuscarTodasMarcas()
        {
            try
            {
                var marcas = await _marcaAppService.BuscarMarcas();
                if (marcas.Any())
                    return Ok(marcas);

                return NotFound("Não foram encontrados registros");

            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("Adicionar")]
        public async Task<IActionResult> AdicionarMarca(MarcaDto marca)
        {
            try
            {
                var marcaCadastrada = await _marcaAppService.CadastrarMarca(marca);
                if (marcaCadastrada)
                    return Ok();

                return BadRequest("Ocorreu um erro ao tentar cadastrar a marca");

            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> AtualizarMarca(MarcaDto marca)
        {
            try
            {
                var marcaAtualizada = await _marcaAppService.AtualizarMarca(marca);
                if (marcaAtualizada)
                    return Ok();

                return BadRequest("Ocorreu um erro ao tentar atualizar a marca");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("Excluir/{marcaId}")]
        public async Task<IActionResult> ExcluirMarca(int marcaId)
        {
            try
            {
                var marcaExcluida = await _marcaAppService.ExcluirMarca(marcaId);
                if (marcaExcluida)
                    return BadRequest("Ocorreu um erro ao tentar excluir a marca");

                return Ok();

            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
