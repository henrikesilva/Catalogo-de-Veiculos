using CatalogoVeiculos.Domain.Entities;

namespace CatalogoVeiculos.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<bool> CadastrarUsuario(Usuario usuario);
        Task<Usuario> RecuperarUsuarioPorlogin(string login, string senha);
        Task<Usuario> BuscarUsuarioPorLogin(string login);
        Task<List<Usuario>> BuscarUsuarios();
        Task<bool> AtualizarUsuario(Usuario usuario);
        Task<bool> ExcluirUsuario(int usuarioId);
    }
}
