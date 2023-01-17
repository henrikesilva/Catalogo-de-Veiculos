using CatalogoVeiculos.Domain.Entities;

namespace CatalogoVeiculos.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<bool> CadastrarUsuario(Usuario usuario);
        Task<Usuario> BuscarUsuarioPorloginSenha(string login, string senha);
        Task<Usuario> BuscarUsuarioPorLogin(string login);
        Task<bool> AtualizarUsuario(Usuario usuario);
    }
}
