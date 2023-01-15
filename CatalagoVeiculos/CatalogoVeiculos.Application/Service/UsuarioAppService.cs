using AutoMapper;
using CatalogoVeiculos.Application.Config;
using CatalogoVeiculos.Application.Dto;
using CatalogoVeiculos.Application.Interface;
using CatalogoVeiculos.Domain.Entities;
using CatalogoVeiculos.Domain.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CatalogoVeiculos.Application.Service
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        public UsuarioAppService(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        public async Task<UsuarioDto> BuscarUsuario(string login, string senha)
        {
            return _mapper.Map<UsuarioDto>(await _usuarioService.BuscarUsuario(login, senha));
        }

        public async Task<bool> CadastrarUsuario(UsuarioDto usuario)
        {
            var usuarioCadastrado = await _usuarioService.CadastrarUsuario(_mapper.Map<Usuario>(usuario));
            return usuarioCadastrado;
        }

        public string Login(LoginDto login)
        {
            if(login != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Auth.secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, login.Usuario)
                    }),

                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            else
            {
                return null;
            }
        }
    }
}
