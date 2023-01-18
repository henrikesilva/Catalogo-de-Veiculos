using CatalogoVeiculos.Application.Dto;
using CatalogoVeiculos.Application.Interface;
using CatalogoVeiculos.Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatalogoVeiculos.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ModeloController : ControllerBase
    {
        private readonly IModeloAppService _modeloAppService;
        public ModeloController(IModeloAppService modeloAppService)
        {
            _modeloAppService = modeloAppService;
        }

        [HttpGet("Buscar/{modeloId}")]
        public async Task<IActionResult> BuscarPorId(int modeloId)
        {
            try
            {
                var modelo = await _modeloAppService.BuscarModelo(modeloId);
                if (modelo == null)
                    return NotFound("Não foram encontrados dados nessa busca");

                return Ok(modelo);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("buscarMarcas/{marcaId}")]
        public async Task<IActionResult> BuscarModeloPorNome(int marcaId)
        {
            try
            {
                var modelo = await _modeloAppService.BuscarModeloPorMarca(marcaId);
                if (modelo == null)
                    return NotFound("Não foram encontrados registros");

                return Ok(modelo);

            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("BuscarTodos")]
        public async Task<IActionResult> BuscarTodos()
        {
            try
            {
                var modelos = await _modeloAppService.BuscarModelos();
                if (modelos.Any())
                    return Ok(modelos);
               
                return NotFound("Não foram encontrados dados nessa busca");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("Adicionar")]
        public async Task<IActionResult> AdicionarModelo(ModeloDto modelo)
        {
            try
            {
                var modeloCadastrado = await _modeloAppService.CadastrarModelo(modelo);
                if (modeloCadastrado)
                    return Ok();

                return BadRequest("Ocorreu um erro ao tentar cadastrar o modelo");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> AtualizarModelo(ModeloDto modelo)
        {
            try
            {
                var modeloCadastrado = await _modeloAppService.AtualizarModelo(modelo);
                if (modeloCadastrado)
                    return Ok();

                return BadRequest("Ocorreu um erro ao tentar atualizar o modelo");

            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("Excluir/{modeloId}")]
        public async Task<IActionResult> ExcluirModelo(int modeloId)
        {
            try
            {
                var modeloCadastrado = await _modeloAppService.ExcluirModelo(modeloId);
                if (modeloCadastrado)
                    return Ok();

                return BadRequest("Ocorreu um erro ao tentar excluir o modelo");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
