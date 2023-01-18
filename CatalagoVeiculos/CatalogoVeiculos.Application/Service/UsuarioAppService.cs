using AutoMapper;
using CatalogoVeiculos.Application.Dto;
using CatalogoVeiculos.Application.Interface;
using CatalogoVeiculos.Application.Security;
using CatalogoVeiculos.Domain.Entities;
using CatalogoVeiculos.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace CatalogoVeiculos.Application.Service
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;
        private IConfiguration _configuration;

        public UsuarioAppService(
            IUsuarioService usuarioService,
            IMapper mapper,
            SigningConfigurations signingConfigurations,
            TokenConfigurations tokenConfigurations,
            IConfiguration configuration)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
        }

        public async Task<UsuarioDto> RecuperarUsuarioPorlogin(string login, string senha)
        {
            return _mapper.Map<UsuarioDto>(await _usuarioService.RecuperarUsuarioPorlogin(login, senha));
        }

        public async Task<UsuarioDto> BuscarUsuarioPorLogin(string login)
        {
            return _mapper.Map<UsuarioDto>(await _usuarioService.BuscarUsuarioPorLogin(login));
        }

        public async Task<bool> CadastrarUsuario(UsuarioDto usuario)
        {
            var usuarioCadastrado = await _usuarioService.CadastrarUsuario(_mapper.Map<Usuario>(usuario));
            return usuarioCadastrado;
        }

        public async Task<object> Login(UsuarioDto login)
        {
            if(login != null)
            {
                var identity = new ClaimsIdentity(
                                 new GenericIdentity(login.LoginUsuario),
                                 new[]
                                 {
                                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                    new Claim(JwtRegisteredClaimNames.UniqueName, login.LoginUsuario),
                                    new Claim(ClaimTypes.Role, login.Administrador.ToString())
                                 }
                );

                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromHours(_tokenConfigurations.Hours);
                
                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expirationDate, handler);
                return SuccessObject(createDate, expirationDate, token, login);
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, UsuarioDto login)
        {
            return new
            {
                autheticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accesToken = token,
                usuario = login.LoginUsuario,
                Administrador = login.Administrador,
                message = "Usuario auteticado com sucesso"
            };
        }
    }
}
