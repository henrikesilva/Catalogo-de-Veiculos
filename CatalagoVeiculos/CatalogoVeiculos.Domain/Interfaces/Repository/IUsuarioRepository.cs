using CatalogoVeiculos.Domain.Entities;

namespace CatalogoVeiculos.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<bool> CadastrarUsuario(Usuario usuario);
        Task<Usuario> BuscarUsuarioPorLoginSenha(string login, string senha);
        Task<Usuario> BuscarUsuarioPorLogin(string login);
        Task<bool> AtualizarUsuario(Usuario usuario);
    }
}
