using CatalogoVeiculos.Domain.Entities;

namespace CatalogoVeiculos.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<bool> CadastrarUsuario(Usuario usuario);
        Task<Usuario> BuscarUsuario(string login, string senha);
        Task<bool> AtualizarUsuario(Usuario usuario);
    }
}
