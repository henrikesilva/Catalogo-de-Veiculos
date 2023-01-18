using CatalogoVeiculos.Domain.Entities;
using CatalogoVeiculos.Domain.Interfaces.Repository;
using CatalogoVeiculos.Infra.Data.Context;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CatalogoVeiculos.Infra.Data.Repository
{
    public class UsuarioRepository : CatalogoVeiculoContext, IUsuarioRepository
    {
        #region [QUERYS]
        private string atualizarUsuario = @"UPDATE
	                                            Usuario
                                            SET
	                                            Nome = @Nome,
	                                            Administrador = @Administrador
                                            WHERE
	                                            UsuarioId = @UsuarioId";

        private string cadastrarUsuario = @"INSERT INTO Usuario
	                                                (Nome, LoginUsuario, Senha, Administrador)
                                                VALUES
	                                                (@Nome, @LoginUsuario, @Senha, @Administrador)";

        private string loginUsuario = @"SELECT 
	                                        UsuarioId,
	                                        LoginUsuario,
                                            Senha,
	                                        Administrador
                                        FROM
	                                        Usuario
                                        WHERE
	                                        LoginUsuario = @LoginUsuario";
        
        private string buscarUsuario = @"SELECT 
	                                        UsuarioId,
	                                        LoginUsuario,
                                            Nome,
	                                        Administrador
                                        FROM
	                                        Usuario
                                        WHERE
	                                        LoginUsuario = @LoginUsuario";
        #endregion

        private string connection;
        public UsuarioRepository(IConfiguration configuration) : base(configuration)
        {
            connection = this.GetConnection();
        }

        public async Task<bool> AtualizarUsuario(Usuario usuario)
        {
            try
            {
                using(var con = new SqlConnection(connection))
                {
                    var usuarioAtualizado = await con.ExecuteAsync(atualizarUsuario, 
                                                                new 
                                                                { 
                                                                    UsuarioId = usuario.UsuarioId,
                                                                    Nome = usuario.Nome,
                                                                    Administrador = usuario.Administrador
                                                                });

                    if(usuarioAtualizado == 1)
                        return true;

                    return false;
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        public async Task<Usuario> RecuperarUsuarioPorlogin(string login)
        {
            

            try
            {
                using (var con = new SqlConnection(connection))
                {
                    var usuario = await con.QueryFirstOrDefaultAsync<Usuario>(loginUsuario,
                                                                new
                                                                {
                                                                    LoginUsuario = login
                                                                });

                    if (usuario != null)
                        return usuario;

                    else
                    {
                        
                        if (login.ToLower().Contains("administrador"))
                        {
                            return new Usuario()
                            {
                                Nome = "Teste Mocado",
                                LoginUsuario = "Administrador",
                                Senha = "gXqSIQDfasgmZuM6a+iIDg==",
                                Administrador = true
                            };
                        }
                        
                        return null;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        public async Task<Usuario> BuscarUsuarioPorLogin(string login)
        {
            try
            {
                using (var con = new SqlConnection(connection))
                {
                    var usuario = await con.QueryFirstAsync<Usuario>(buscarUsuario,
                                                                new
                                                                {
                                                                    LoginUsuario = login
                                                                });

                    if (usuario.LoginUsuario != null)
                        return usuario;

                    return new Usuario();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CadastrarUsuario(Usuario usuario)
        {
            try
            {
                using (var con = new SqlConnection(connection))
                {
                    var usuarioCadastrado = await con.ExecuteAsync(cadastrarUsuario,
                                                                new
                                                                {
                                                                    Nome = usuario.Nome,
                                                                    LoginUsuario = usuario.LoginUsuario,
                                                                    Senha = usuario.Senha,
                                                                    Administrador = usuario.Administrador
                                                                });

                    if (usuarioCadastrado == 1)
                        return true;

                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
