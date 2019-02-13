using Dapper;
using Enterprise.Framework.SqlClient;
using Loja.Domain.ComprasParceiro.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Loja.Domain.ComprasParceiro.Models;
using Loja.Domain.ComprasParceiro.Dtos;
using Loja.Domain.Compras.Models;

namespace Loja.Infrastructure.SqlClient
{
	public class CompraParceiroRepository : BaseRepository, ICompraParceiroRepository, ICompraERPRepository
    {
        public CompraParceiroRepository(IConectionFactory connection)
              : base(connection)
        {
        }

        public async Task<int> Alterar(Loja.Domain.ComprasParceiro.Models.CompraParceiro compra)
        {
            var result = await WithConnection(DatabaseConnection.Loja, async conn => {

                var parameters = new DynamicParameters();
                parameters.Add("IdCompra", compra.IdCompra, DbType.Int32);
                parameters.Add("IdCompraEntregaSku", compra.IdCompraEntregaSku, DbType.Int32);
                parameters.Add("IdProdutoParceiro", compra.IdProdutoParceiro, DbType.Int32);                
				parameters.Add("StatusIntegracaoParceiro", compra.StatusIntegracaoParceiro, DbType.String);
                parameters.Add("DataIntegracaoParceiro", compra.DataIntegracaoParceiro, DbType.DateTime2);
                parameters.Add("LogRetornoParceiro", compra.LogRetornoParceiro, DbType.String);
                parameters.Add("Hash", compra.Hash, DbType.String);
                parameters.Add("Ativacao", compra.Ativacao, DbType.String);
                parameters.Add("EmailEnvioAtivacao", compra.EmailEnvioAtivacao, DbType.String);
                parameters.Add("DataEnvioAtivacao", compra.DataEnvioAtivacao, DbType.DateTime2);
                parameters.Add("RequisicaoId", compra.RequisicaoId, DbType.String);
                parameters.Add("ClienteId", compra.ClienteId, DbType.String);
                parameters.Add("TentativasIntegracao", compra.TentativasIntegracao, DbType.Int32);

                var alterar = await conn.ExecuteAsync(
                     sql: "IntegracaoParceiroCompraLojaAlterar",
                     param: parameters,
                     commandType: CommandType.StoredProcedure);

                return alterar;
            });

            return result;
        }


        public async Task<int> AlterarStatusParceiro(AlterarStatusParceiro compra)
        {
            var result = await WithConnection(DatabaseConnection.Loja, async conn => {

                var parameters = new DynamicParameters();
                parameters.Add("IdCompra", compra.IdCompra, DbType.Int32);
                parameters.Add("IdCompraEntregaSku", compra.IdCompraEntregaSku, DbType.Int32);                
                parameters.Add("StatusIntegracaoParceiro", compra.StatusIntegracaoParceiro, DbType.String);
                parameters.Add("DataIntegracaoParceiro", compra.DataIntegracaoParceiro, DbType.DateTime2);
                parameters.Add("LogRetornoParceiro", compra.LogRetornoParceiro, DbType.String);
                parameters.Add("Hash", compra.Hash, DbType.String);
                parameters.Add("Ativacao", compra.Ativacao, DbType.String);                
                parameters.Add("RequisicaoId", compra.RequisicaoId, DbType.String);
                parameters.Add("ClienteId", compra.ClienteId, DbType.String);
                parameters.Add("TentativasIntegracao", compra.TentativasIntegracao, DbType.Int32);

                var alterar = await conn.ExecuteAsync(
                     sql: "IntegracaoParceiroCompraLojaAlterarStatusParceiro",
                     param: parameters,
                     commandType: CommandType.StoredProcedure);

                return alterar;
            });

            return result;
        }

        public async Task<int> AlterarStatusAtivacao(AlterarStatusAtivacao compra)
        {
            var result = await WithConnection(DatabaseConnection.Loja, async conn => {

                var parameters = new DynamicParameters();
                parameters.Add("IdCompra", compra.IdCompra, DbType.Int32);
                parameters.Add("IdCompraEntregaSku", compra.IdCompraEntregaSku, DbType.Int32);                
                parameters.Add("DataEnvioAtivacao", compra.DataEnvioAtivacao, DbType.DateTime2);
                
                var alterar = await conn.ExecuteAsync(
                     sql: "IntegracaoParceiroCompraLojaAlterarStatusAtivacao",
                     param: parameters,
                     commandType: CommandType.StoredProcedure);

                return alterar;
            });

            return result;
        }

        public async Task<int> Inserir(Loja.Domain.ComprasParceiro.Models.CompraParceiro compra)
        {
            var result = await WithConnection(DatabaseConnection.Loja, async conn => {

                var parameters = new DynamicParameters();
				parameters.Add("IdCompra", compra.IdCompra, DbType.Int32);
				parameters.Add("IdCompraEntregaSku", compra.IdCompraEntregaSku, DbType.Int32);
				parameters.Add("IdProdutoParceiro", compra.IdProdutoParceiro, DbType.Int32);
				parameters.Add("DataInclusao", compra.DataInclusao, DbType.DateTime2);
				parameters.Add("EmailEnvioAceito", compra.EmailEnvioAceito, DbType.String);
				parameters.Add("DataEnvioAceite", compra.DataEnvioAceite, DbType.DateTime2);
				parameters.Add("DataStatusAceite", compra.DataStatusAceite, DbType.DateTime2);
				parameters.Add("StatusAceite", compra.StatusAceite, DbType.String);
				parameters.Add("StatusIntegracaoParceiro", compra.StatusIntegracaoParceiro, DbType.String);
				parameters.Add("DataIntegracaoParceiro", compra.DataIntegracaoParceiro, DbType.DateTime2);
				parameters.Add("LogRetornoParceiro", compra.LogRetornoParceiro, DbType.String);
				parameters.Add("Ativacao", compra.Ativacao, DbType.String);
				parameters.Add("EmailEnvioAtivacao", compra.EmailEnvioAtivacao, DbType.String);
				parameters.Add("DataEnvioAtivacao", compra.DataEnvioAtivacao, DbType.DateTime2);

				var inserir = await conn.ExecuteAsync(
                    sql: "IntegracaoParceiroCompraLojaInserir",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                return inserir;
            });

            return result;

        }

        public async Task<IEnumerable<Loja.Domain.ComprasParceiro.Models.CompraParceiro>> Listar(int idCompra, int idCompraEntregaSku, int idProdutoParceiro)
        {
            var result = await WithConnection(DatabaseConnection.Loja, async conn => {

                var parameters = new DynamicParameters();
                                
                 parameters.Add("IdCompra", idCompra, DbType.Int32);                
                parameters.Add("IdCompraEntregaSku", idCompraEntregaSku, DbType.Int32);            
                parameters.Add("IdProdutoParceiro", idProdutoParceiro, DbType.Int32);
                
                
                var compras = await conn.QueryAsync<Loja.Domain.ComprasParceiro.Models.CompraParceiro>(
                    sql: "IntegracaoParceiroCompraLojaListar",
                     param: parameters,
                    commandType: CommandType.StoredProcedure);
                return compras;

            });

            return result;
        }

        public async Task<IEnumerable<Loja.Domain.ComprasParceiro.Models.CompraParceiroProduto>> ListarComAceite()
        {
            var result = await WithConnection(DatabaseConnection.Loja, async conn => {

                var compras = await conn.QueryAsync<Loja.Domain.ComprasParceiro.Models.CompraParceiroProduto>(
                    sql: "IntegracaoParceiroCompraLojaListarComAceite",
                    commandType: CommandType.StoredProcedure);
                return compras;

            });

            return result;
        }

       

        public async Task<Loja.Domain.ComprasParceiro.Models.CompraParceiro> ObterPorCompraEntrega(int idCompra, int idCompraEntregaSku)
        {
            var result = await WithConnection(DatabaseConnection.Loja, async conn => {

                var parameters = new DynamicParameters();
                parameters.Add("IdCompra", idCompra, DbType.Int32);
                parameters.Add("IdCompraEntregaSku", idCompraEntregaSku, DbType.Int32);

                var compras = await conn.QueryAsync<Loja.Domain.ComprasParceiro.Models.CompraParceiro>(
                    sql: "IntegracaoParceiroCompraLojaObterPorCompraEntrega",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
                return compras.FirstOrDefault();

            });

            return result;
        }

		
		


		public async Task<Loja.Domain.ComprasParceiro.Models.CompraParceiro> ObterUltimaRecente()
        {
            var result = await WithConnection(DatabaseConnection.Loja, async conn => {

                var compras = await conn.QueryAsync<Loja.Domain.ComprasParceiro.Models.CompraParceiro>(
                    sql: "IntegracaoParceiroCompraLojaObterUltimaProcessada",

                    commandType: CommandType.StoredProcedure);
                return compras.FirstOrDefault();

            });

            return result;
        }

		public async Task<int> AlterarStatusAceiteAsync(AlterarStatusAceite compraParceiro)
		{
			var result = await WithConnection(DatabaseConnection.Loja, async conn => {
				var parameters = new DynamicParameters();
				parameters.Add("IdCompra", compraParceiro.IdCompra, DbType.Int32);
				parameters.Add("IdCompraEntregaSku", compraParceiro.IdCompraEntregaSku, DbType.Int32);
				parameters.Add("StatusAceite", compraParceiro.StatusAceite, DbType.String);

				var inserir = await conn.ExecuteAsync(
					sql: "IntegracaoParceiroCompraLojaAlterarStatusAceite",
					param: parameters,
					commandType: CommandType.StoredProcedure);

				return inserir;
			});

			return result;
		}

		public async Task<IEnumerable<CompraERP>> ListarERP()
		{
			var result = await WithConnection(DatabaseConnection.Loja, async conn => {

				
				var compras = await conn.QueryAsync<CompraERP>(
					sql: "IntegracaoERPCompraLojaListar",
					 
					commandType: CommandType.StoredProcedure);
				return compras;

			});

			return result;
		}


		public async Task<int> AlterarERPAsync(CompraERP compraERP)
		{
			var result = await WithConnection(DatabaseConnection.Loja, async conn => {



				var parameters = new DynamicParameters();
				parameters.Add("IdCompra", compraERP.IdCompra, DbType.Int32);
				parameters.Add("IdCompraEntregaSku", compraERP.IdCompraEntregaSku, DbType.Int32);
				parameters.Add("StatusIntegracaoERP", compraERP.StatusIntegracaoERP, DbType.String);
				parameters.Add("LogRetornoERP", compraERP.LogRetornoERP, DbType.String);
				parameters.Add("TentativasIntegracaoERP", compraERP.TentativasIntegracaoERP, DbType.Int32);
				parameters.Add("DataIntegracaoERP", compraERP.DataIntegracaoERP, DbType.DateTime2);

				var alterar = await conn.ExecuteAsync(
					 sql: "IntegracaoERPCompraLojaAlterarStatusERP",
					 param: parameters,
					 commandType: CommandType.StoredProcedure);

				return alterar;
			});

			return result;
		}

		

		
	}
}
