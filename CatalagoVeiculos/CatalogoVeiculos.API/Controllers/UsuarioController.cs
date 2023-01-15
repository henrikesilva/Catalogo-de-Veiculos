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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;
        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto login)
        {
            try
            {
                var acesso = await _usuarioAppService.BuscarUsuario(login.Usuario, login.Senha);
                if (acesso == null)
                    return Unauthorized("Não foi possivel efetuar o login");

                else
                {
                    var token = _usuarioAppService.Login(login);
                    var returnRequest = new
                    {
                        Login = login.Usuario,
                        token
                    };

                    return Ok(returnRequest);
                }
            }
            catch(ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> CadastrarUsuario(UsuarioDto usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var usuarioCadastrado = await _usuarioAppService.CadastrarUsuario(usuario);
                if (usuarioCadastrado)
                    return Ok("Usuário cadastrado com sucesso!");

                return BadRequest("Ocorreu um erro ao cadastrar o usuário");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("Buscar")]
        public async Task<IActionResult> BuscarUsuario(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return BadRequest("o campo nome é obrigatório");

            try
            {
                var usuario = await _usuarioAppService.BuscarUsuario(nome, null);
                if (usuario.Equals(new UsuarioDto()))
                    return NotFound("Não foi encontrado usuario para essa busca");

                return Ok(usuario);
            }
            catch(ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
