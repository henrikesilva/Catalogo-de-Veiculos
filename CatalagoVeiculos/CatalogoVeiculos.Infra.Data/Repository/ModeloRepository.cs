using CatalogoVeiculos.Domain.Entities;
using CatalogoVeiculos.Domain.Interfaces.Repository;
using CatalogoVeiculos.Infra.Data.Context;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Reflection;

namespace CatalogoVeiculos.Infra.Data.Repository
{
    public class ModeloRepository : CatalogoVeiculoContext, IModeloRepository
    {
        #region [QUERYS]
        private string atualizarModelo = @"UPDATE
	                                Modelo
                                SET
	                                NomeModelo = @NomeModelo,
	                                MarcaId = @MarcaId
                                WHERE
	                                ModeloId = @ModeloId";

        private string cadastrarModelo = @"INSERT INTO Modelo
	                                                    (NomeModelo, MarcaId)
                                                    VALUES
	                                                    (@NomeModelo, @MarcaId)";

        private string excluirModelo = @"DELETE FROM Modelo WHERE ModeloId = @ModeloId";

        private string buscarModelo = @"SELECT 
	                                        MO.ModeloId,
	                                        MO.NomeModelo,
	                                        MO.MarcaId,
	                                        MA.NomeMarca
                                        FROM
	                                        Modelo AS MO (nolock)
	                                        INNER JOIN Marca (nolock) AS MA ON MA.MarcaId = MO.MarcaId
                                        WHERE
	                                        MO.ModeloId = @ModeloId";

        private string buscarModeloPorMarca = @"SELECT 
	                                        MO.ModeloId,
	                                        MO.NomeModelo,
	                                        MO.MarcaId,
	                                        MA.NomeMarca
                                        FROM
	                                        Modelo AS MO (nolock)
	                                        INNER JOIN Marca (nolock) AS MA ON MA.MarcaId = MO.MarcaId
                                        WHERE
	                                        MO.MarcaId = @MarcaId";

        private string buscarModelos = @"SELECT 
	                                        MO.ModeloId,
	                                        MO.NomeModelo,
	                                        MO.MarcaId,
	                                        MA.NomeMarca
                                        FROM
	                                        Modelo AS MO (nolock)
	                                        INNER JOIN Marca (nolock) AS MA ON MA.MarcaId = MO.MarcaId";
        #endregion

        private string _connection;
        public ModeloRepository(IConfiguration configuration) : base(configuration)
        {
            _connection = this.GetConnection();
        }

        public async Task<bool> AtualizarModelo(Modelo modelo)
        {
            try
            {
                using(var con = new SqlConnection(_connection))
                {
                    var modeloAtualizado = await con.ExecuteAsync(atualizarModelo,
                                                                new 
                                                                {
                                                                    ModeloId = modelo.ModeloId,
                                                                    NomeModelo = modelo.NomeModelo,
                                                                    MarcaId = modelo.MarcaId 
                                                                });

                    if (modeloAtualizado == 1)
                        return true;

                    return false;
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        public async Task<Modelo> BuscarModelo(int modeloId)
        {
            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    var modeloAtualizado = await con.QueryAsync<Modelo, Marca, Modelo>(buscarModelo,
                                                               (Modelo, Marca) =>
                                                               {
                                                                   Modelo.Marca = Marca;

                                                                   return Modelo;
                                                               },
                                                               new
                                                               {
                                                                   ModeloId = modeloId
                                                               },
                                                               splitOn: "MarcaId");

                    if (modeloAtualizado.Any())
                        return modeloAtualizado.FirstOrDefault();

                    return new Modelo();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        
        public async Task<List<Modelo>> BuscarModeloPorMarca(int marcaId)
        {
            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    var modeloAtualizado = await con.QueryAsync<Modelo, Marca, Modelo>(buscarModeloPorMarca,
                                                               (Modelo, Marca) =>
                                                               {
                                                                   Modelo.Marca = Marca;

                                                                   return Modelo;
                                                               },
                                                               new
                                                               {
                                                                   MarcaId = marcaId
                                                               },
                                                               splitOn: "MarcaId");

                    if (modeloAtualizado.Any())
                        return modeloAtualizado.ToList();

                    return new List<Modelo>();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async Task<List<Modelo>> BuscarModelos()
        {
            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    var modelos = await con.QueryAsync<Modelo, Marca, Modelo>(buscarModelos,
                                                               (Modelo, Marca) =>
                                                               {
                                                                   Modelo.Marca = Marca;

                                                                   return Modelo;
                                                               },
                                                               splitOn: "MarcaId");

                    if (modelos.Any())
                        return modelos.ToList();

                    return new List<Modelo>();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CadastrarModelo(Modelo modelo)
        {
            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    var modeloCadastrado = await con.ExecuteAsync(cadastrarModelo,
                                                                new
                                                                {
                                                                    NomeModelo = modelo.NomeModelo,
                                                                    MarcaId = modelo.MarcaId
                                                                });

                    if (modeloCadastrado == 1)
                        return true;

                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExcluirModelo(Modelo modelo)
        {
            try
            {
                using (var con = new SqlConnection(_connection))
                {
                    var modeloExcluido = await con.ExecuteAsync(excluirModelo,
                                                                new
                                                                {
                                                                    ModeloId = modelo.ModeloId
                                                                });

                    if (modeloExcluido == 1)
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
