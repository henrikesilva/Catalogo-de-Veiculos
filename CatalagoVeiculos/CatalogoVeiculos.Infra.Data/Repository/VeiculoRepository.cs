using CatalogoVeiculos.Domain.Entities;
using CatalogoVeiculos.Domain.Interfaces.Repository;
using CatalogoVeiculos.Infra.Data.Context;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CatalogoVeiculos.Infra.Data.Repository
{
    public class VeiculoRepository : CatalogoVeiculoContext, IVeiculoRepository
    {
        #region [QUERYS do banco]
        private string atualizarVeiculo = @"UPDATE
	                                                Veiculo
                                                SET
	                                                Nome = @Nome,
	                                                Foto = @Foto,
	                                                Preco = @Preco,
	                                                DataAtualizacao = @DataAtualizacao,
                                                    StatusVeiculo = @StatusVeiculo,
	                                                ModeloId = @ModeloId,
                                                    UsuarioId = @UsuarioId
                                                WHERE
	                                                VeiculoId = @VeiculoId";


        private string cadastrarVeiculo = @"INSERT INTO
                                                Veiculo
	                                                (Nome, Foto, Preco, DataCriacao, DataAtualizacao, StatusVeiculo, ModeloId, UsuarioId)
                                                VALUES
	                                                (@Nome, @Foto, @Preco, @DataCriacao, @DataAtualizacao, @StatusVeiculo, @ModeloId, @UsuarioId)";


        private string excluirVeiculo = @"UPDATE
	                                                Veiculo
                                                SET
	                                                DataAtualizacao = @DataAtualizacao,
                                                    StatusVeiculo = @StatusVeiculo
                                                WHERE
	                                                VeiculoId = @VeiculoId";

        private string buscarVeiculoPorId = @"SELECT 
	                                                VE.VeiculoId,
	                                                VE.Nome,
	                                                VE.Foto,
	                                                VE.Preco,
	                                                VE.DataCriacao,
	                                                VE.DataAtualizacao,
                                                    VE.StatusVeiculo,
	                                                MO.ModeloId,
	                                                MO.NomeModelo,
	                                                MA.MarcaId,
	                                                MA.NomeMarca,
	                                                US.UsuarioId,
	                                                US.Nome
                                                FROM
	                                                Veiculo AS VE
	                                                INNER JOIN Modelo AS MO ON MO.ModeloId = VE.ModeloId
	                                                INNER JOIN Marca AS MA ON MA.MarcaId = MO.MarcaId
	                                                INNER JOIN Usuario AS US ON US.UsuarioId = VE.UsuarioId
                                                WHERE
	                                                VE.VeiculoId = @VeiculoId";

        private string buscarVeiculos = @"SELECT 
	                                            VE.VeiculoId,
	                                            VE.Nome,
	                                            VE.Foto,
	                                            VE.Preco,
	                                            VE.DataCriacao,
	                                            VE.DataAtualizacao,
                                                VE.StatusVeiculo,
	                                            MO.ModeloId,
	                                            MO.NomeModelo,
	                                            MA.MarcaId,
	                                            MA.NomeMarca,
	                                            US.UsuarioId,
	                                            US.Nome
                                            FROM
	                                            Veiculo AS VE
	                                            INNER JOIN Modelo AS MO ON MO.ModeloId = VE.ModeloId
	                                            INNER JOIN Marca AS MA ON MA.MarcaId = MO.MarcaId
	                                            INNER JOIN Usuario AS US ON US.UsuarioId = VE.UsuarioId
	                                            ORDER BY VE.Preco DESC";
        #endregion

        private string connection;
        public VeiculoRepository(IConfiguration configuration) : base(configuration)
        {
            connection = this.GetConnection();
        }

        public async Task<bool> AtualizarCadastroVeiculo(Veiculo veiculo)
        {
            try
            {
                using(var con = new SqlConnection(connection))
                {
                    var veiculoAtualizado = await con.ExecuteAsync(atualizarVeiculo, 
                                                                new
                                                                {
                                                                    VeiculoId = veiculo.VeiculoId,
                                                                    UsuarioId = veiculo.UsuarioId,
                                                                    Nome = veiculo.Nome,
                                                                    Foto = veiculo.Foto,
                                                                    Preco = veiculo.Preco,
                                                                    DataAtualizacao = veiculo.DataAtualizacao,
                                                                    StatusVeiculo = veiculo.StatusVeiculo,
                                                                    ModeloId = veiculo.ModeloId
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

        public async Task<bool> CadastrarVeiculo(Veiculo veiculo)
        {
            try
            {
                using (var con = new SqlConnection(connection))
                {
                    var veiculoCadastrado = await con.ExecuteAsync(cadastrarVeiculo,
                                                                new
                                                                {
                                                                    UsuarioId = veiculo.UsuarioId,
                                                                    Nome = veiculo.Nome,
                                                                    Foto = veiculo.Foto,
                                                                    Preco = veiculo.Preco,
                                                                    DataCriacao = veiculo.DataCriacao,
                                                                    DataAtualizacao = veiculo.DataAtualizacao,
                                                                    StatusVeiculo = true,
                                                                    ModeloId = veiculo.ModeloId
                                                                });

                    if (veiculoCadastrado == 1)
                        return true;

                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExcluirCadastroVeiculo(int veiculoId)
        {
            try
            {
                using (var con = new SqlConnection(connection))
                {
                    var veiculoExcluido = await con.ExecuteAsync(excluirVeiculo,
                                                                new
                                                                {
                                                                    StatusVeiculo = false,
                                                                    DataAtualizacao = DateTime.UtcNow.AddHours(-3d),
                                                                    VeiculoId = veiculoId
                                                                });

                    if (veiculoExcluido == 1)
                        return true;

                    return false;
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        public async Task<Veiculo> SelecionarVeiculoEspecifico(int veiculoId)
        {
            try
            {
                using (var con = new SqlConnection(connection))
                {
                    var veiculo = await con.QueryAsync<Veiculo, Modelo, Marca, Usuario, Veiculo>
                                                        (buscarVeiculoPorId, (Veiculo, Modelo, Marca, Usuario) =>
                                                        {
                                                            Veiculo.Modelo = Modelo;
                                                            Veiculo.Modelo.Marca = Marca;
                                                            Veiculo.Usuario = Usuario;

                                                            return Veiculo;
                                                        }, 
                                                        new 
                                                        { 
                                                            VeiculoId = veiculoId 
                                                        },
                                                        splitOn: "ModeloId, MarcaId, UsuarioId");

                    if (veiculo.Any())
                    {
                        return veiculo.FirstOrDefault();
                    }

                    return new Veiculo();
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        public async Task<List<Veiculo>> SelecionarVeiculos()
        {
            try
            {
                using (var con = new SqlConnection(connection))
                {
                    var veiculo = await con.QueryAsync<Veiculo, Modelo, Marca, Usuario, Veiculo>
                                                        (buscarVeiculos, (Veiculo, Modelo, Marca, Usuario) =>
                                                        {
                                                            Veiculo.Modelo = Modelo;
                                                            Veiculo.Modelo.Marca = Marca;
                                                            Veiculo.Usuario = Usuario;

                                                            return Veiculo;
                                                        },
                                                        splitOn: "ModeloId, MarcaId, UsuarioId");

                    if (veiculo.Any())
                    {
                        return veiculo.ToList();
                    }

                    return new List<Veiculo>();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
