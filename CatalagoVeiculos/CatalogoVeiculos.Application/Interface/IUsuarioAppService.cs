﻿using CatalogoVeiculos.Application.Dto;
using CatalogoVeiculos.Domain.Entities;

namespace CatalogoVeiculos.Application.Interface
{
    public interface IUsuarioAppService
    {
        string Login(LoginDto usuario);
        Task<UsuarioDto> BuscarUsuarioPorLoginSenha(string login, string senha);
        Task<UsuarioDto> BuscarUsuarioPorLogin(string login);
        Task<bool> CadastrarUsuario(UsuarioDto usuario);
    }
}
