using CatalogoVeiculos.Domain.Entities;
using CatalogoVeiculos.Domain.Interfaces.Repository;
using CatalogoVeiculos.Domain.Interfaces.Services;

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
            var usuarioAtualizado = await _usuarioRepository.AtualizarUsuario(usuario);
            return usuarioAtualizado;
        }

        public async Task<Usuario> BuscarUsuario(string email, string senha)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(email, senha);
            return usuario;
        }

        public async Task<bool> CadastrarUsuario(Usuario usuario)
        {
            var usuarioCadastrado = await _usuarioRepository.CadastrarUsuario(usuario);
            return usuarioCadastrado;
        }
    }
}
