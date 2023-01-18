using CatalogoVeiculos.Domain.Entities;
using CatalogoVeiculos.Domain.Interfaces.Repository;
using CatalogoVeiculos.Domain.Interfaces.Services;
using CatalogoVeiculos.Domain.Security;

namespace CatalogoVeiculos.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> AtualizarUsuario(Usuario usuario)
        {
            if(!string.IsNullOrEmpty(usuario.Senha))
                usuario.Senha = new Criptografia().Encrypt(usuario.Senha);

            var usuarioAtualizado = await _usuarioRepository.AtualizarUsuario(usuario);
            return usuarioAtualizado;
        }

        public async Task<Usuario> BuscarUsuarioPorLogin(string login)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorLogin(login);
            return usuario;
        }

        public async Task<Usuario> RecuperarUsuarioPorlogin(string login, string senha)
        {
            var usuario = await _usuarioRepository.RecuperarUsuarioPorlogin(login);
            if (usuario == null)
                return null;

            var decriptado = new Criptografia().Decrypt(usuario.Senha);
            if (decriptado == null)
            {
                return null;
            }
            else
            {
                if (usuario.LoginUsuario == login && decriptado == senha)
                {
                    usuario.Senha = null;
                    return usuario;
                }

                return null;
            }

            usuario.Senha = null;
            return usuario;
        }

        public async Task<bool> CadastrarUsuario(Usuario usuario)
        {
            usuario.Senha = new Criptografia().Encrypt(usuario.Senha);
            var usuarioCadastrado = await _usuarioRepository.CadastrarUsuario(usuario);
            return usuarioCadastrado;
        }
    }
}
