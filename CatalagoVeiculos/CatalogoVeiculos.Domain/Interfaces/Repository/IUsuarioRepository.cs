using CatalogoVeiculos.Domain.Entities;

namespace CatalogoVeiculos.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<bool> CadastrarUsuario(Usuario usuario);
        Task<Usuario> RecuperarUsuarioPorlogin(string login);
        Task<Usuario> BuscarUsuarioPorLogin(string login);
        Task<List<Usuario>> BuscarUsuarios();
        Task<bool> AtualizarUsuario(Usuario usuario);
        Task<bool> ExcluirUsuario(int usuarioId);
    }
}
