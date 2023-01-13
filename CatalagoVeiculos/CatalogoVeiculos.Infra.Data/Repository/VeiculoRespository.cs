using CatalogoVeiculos.Domain.Entities;
using CatalogoVeiculos.Domain.Interfaces.Repository;
using CatalogoVeiculos.Infra.Data.Context;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CatalogoVeiculos.Infra.Data.Repository
{
    public class VeiculoRespository : CatalogoVeiculoContext, IVeiculoRepository
    {
        #region [QUERYS do banco]
        private string atualizarVeiculo = @"UPDATE
	                                                Veiculo
                                                SET
	                                                Nome = @Nome,
	                                                Foto = @Foto,
	                                                Preco = @Preco,
	                                                DataAtualizacao = @DataAtualizacao,
	                                                ModeloId = @ModeloId
                                                WHERE
	                                                VeiculoId = @VeiculoId";


        private string cadastrarVeiculo = @"INSERT INTO
                                                Veiculo
	                                                (Nome, Foto, Preco, DataCriacao, DataAtualizacao, ModeloId, UsuarioId)
                                                VALUES
	                                                (@Nome, @Foto, @Preco, @DataCriacao, @DataAtualizacao, @ModeloId, @UsuarioId)";


        private string excluirVeiculo = @"DELETE FROM Veiculo WHERE VeiculoId = @VeiculoId";

        //private string buscarVeiculo = @"";
        #endregion

        private string connection;
        public VeiculoRespository(IConfiguration configuration) : base(configuration)
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
                                                                    UsuarioId = veiculo.UsuarioId,
                                                                    Foto = veiculo.Foto,
                                                                    Preco = veiculo.Preco,
                                                                    DataAtualizacao = veiculo.DataAtualizacao,
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
                                                                    Foto = veiculo.Foto,
                                                                    Preco = veiculo.Preco,
                                                                    DataCriacao = veiculo.DataCriacao,
                                                                    DataAtualizacao = veiculo.DataAtualizacao,
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

        public async Task<bool> ExcluirCadastroVeiculo(Veiculo veiculo)
        {
            try
            {
                using (var con = new SqlConnection(connection))
                {
                    var veiculoExcluido = await con.ExecuteAsync(excluirVeiculo,
                                                                new
                                                                {
                                                                    VeiculoId = veiculo.VeiculoId
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
                    var veiculoExcluido = await con.QueryAsync(excluirVeiculo,
                                                                new
                                                                {
                                                                    VeiculoId = veiculo.VeiculoId
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

        public Task<List<Veiculo>> SelecionarVeiculos()
        {
            throw new NotImplementedException();
        }
    }
}
