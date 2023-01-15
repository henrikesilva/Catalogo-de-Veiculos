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

        private string buscarUsuario = @"SELECT 
	                                        UsuarioId,
	                                        LoginUsuario,
	                                        Administrador
                                        FROM
	                                        Usuario
                                        WHERE
	                                        LoginUsuario = @LoginUsuario AND Senha = @Senha";
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

        public async Task<Usuario> BuscarUsuario(string login, string senha)
        {
            try
            {
                using (var con = new SqlConnection(connection))
                {
                    var usuario = await con.QueryFirstAsync<Usuario>(buscarUsuario,
                                                                new
                                                                {
                                                                    LoginUsuario = login,
                                                                    Senha = senha
                                                                });

                    if (usuario.Nome != null)
                        return new Usuario();

                    return usuario;
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
