using CatalogoVeiculos.Domain.Entities;
using CatalogoVeiculos.Domain.Interfaces.Repository;
using CatalogoVeiculos.Infra.Data.Context;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoVeiculos.Infra.Data.Repository
{
    public class MarcaRepository : CatalogoVeiculoContext, IMarcaRepository
    {
        #region [QUERYS]
        private string atualizarMarca = @"UPDATE 
	                                            Marca
                                            SET
	                                            NomeMarca = @NomeMarca
                                            WHERE
	                                            MarcaId = @MarcaId";

        private string cadastrarMarca = @"INSERT INTO Marca
	                                                        (NomeMarca)
                                                        VALUES
	                                                        (@NomeMarca)";

        private string excluirMarca = @"DELETE FROM Marca WHERE MarcaId = @MarcaId";

        private string buscarMarca = @"SELECT 
	                                        * 
                                        FROM 
	                                        Marca(nolock)
                                        WHERE
	                                        MarcaId = @MarcaId ";

        private string buscarMarcas = @"SELECT 
	                                        * 
                                        FROM 
	                                        Marca(nolock)";
        #endregion

        private string _connection;
        public MarcaRepository(IConfiguration configuration) : base(configuration)
        {
            _connection = this.GetConnection();
        }

        public async Task<bool> AtualizarMarca(Marca marca)
        {
            try
            {
                using(var con = new SqlConnection(_connection))
                {
                    var veiculoAtualizado = await con.ExecuteAsync(atualizarMarca,
                                                                    new
                                                                    {
                                                                        MarcaId = marca.MarcaId,
                                                                        NomeMarca = marca.NomeMarca
                                                                    });

                    if (veiculoAtualizado == 1)
                        return true;

                    return false;
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        public async Task<Marca> BuscarMarca(int marcaId)
        {
            try
            {
                using(var con = new SqlConnection(_connection))
                {
                    var marca = await con.QuerySingleAsync<Marca>(buscarMarca, new { MarcaId = marcaId});

                    if(marca.MarcaId == 0)
                        return new Marca();

                    return marca;
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        public async Task<List<Marca>> BuscarMarcas()
        {
            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    var marca = await con.QueryAsync<Marca>(buscarMarcas);

                    if (marca.Any())
                        return marca.ToList();

                    
                    return new List<Marca>();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CadastrarMarca(Marca marca)
        {
            try
            {
                using(var con = new SqlConnection(_connection))
                {
                    var marcaCadastrada = await con.ExecuteAsync(cadastrarMarca, 
                                                                new
                                                                {
                                                                    NomeMarca = marca.NomeMarca
                                                                });

                    if (marcaCadastrada == 1)
                        return true;

                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExcluirMarca(Marca marca)
        {
            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    var marcaExcluida = await con.ExecuteAsync(excluirMarca,
                                                                new
                                                                {
                                                                    MarcaId = marca.MarcaId
                                                                });

                    if (marcaExcluida == 1)
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
