using CatalogoVeiculos.Domain.Entities;

namespace CatalogoVeiculos.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<bool> CadastrarUsuario(Usuario usuario);
        Task<Usuario> BuscarUsuario(string email, string senha);
        Task<bool> AtualizarUsuario(Usuario usuario);
    }
}
