using CatalogoVeiculos.Application.Dto;
using CatalogoVeiculos.Domain.Entities;

namespace CatalogoVeiculos.Application.Interface
{
    public interface IUsuarioAppService
    {
        string Login(LoginDto usuario);
        Task<UsuarioDto> BuscarUsuario(string login, string senha);
        Task<bool> CadastrarUsuario(UsuarioDto usuario);
    }
}
