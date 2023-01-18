using CatalogoVeiculos.Application.Dto;
using CatalogoVeiculos.Domain.Entities;

namespace CatalogoVeiculos.Application.Interface
{
    public interface IUsuarioAppService
    {
        Task<object> Login(UsuarioDto usuario);
        Task<UsuarioDto> RecuperarUsuarioPorlogin(string login, string senha);
        Task<UsuarioDto> BuscarUsuarioPorLogin(string login);
        Task<List<UsuarioDto>> BuscarUsuarios();
        Task<bool> CadastrarUsuario(UsuarioDto usuario);
        Task<bool> AtualizarUsuario(UsuarioDto usuario);
        Task<bool> ExcluirUsuario(int usuarioId);
    }
}
