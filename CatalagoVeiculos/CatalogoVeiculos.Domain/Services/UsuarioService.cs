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
            if (usuario == null || usuario.StatusUsuario == false)
                return null;

            var decriptado = new Criptografia().Decrypt(usuario.Senha);
            if (decriptado == null)
            {
                return null;
            }
            else
            {
                if (usuario.LoginUsuario.ToUpper() == login.ToUpper() && decriptado.ToUpper() == senha.ToUpper())
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

        public async Task<bool> ExcluirUsuario(int usuarioId)
        {
            var usuarioExcluido = await _usuarioRepository.ExcluirUsuario(usuarioId);
            return usuarioExcluido;
        }

        public async Task<List<Usuario>> BuscarUsuarios()
        {
            var usuarios = await _usuarioRepository.BuscarUsuarios();
            return usuarios;
        }
    }
}
