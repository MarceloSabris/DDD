using Dapper;
using Enterprise.Framework.Collections;
using Enterprise.Framework.SqlClient;
using Loja.Domain.Compras.Models;
using Loja.Domain.Compras.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Infrastructure.SqlClient
{
    public class CompraRepository : BaseRepository, ICompraRepository
    {
        
        public CompraRepository(IConectionFactory connection) 
            : base(connection)
        {
        }

        public async Task<IEnumerable<Compra>> ListarElegiveisAsync(DateTime? dataUltimaExecucao)
        {
            var result = await WithConnection(DatabaseConnection.Loja, async conn => {
                
                var parameters = new DynamicParameters(); 
                parameters.Add("DataUltimaExecucao", dataUltimaExecucao, DbType.DateTime2);
                var compras = await conn.QueryAsync<Compra>(
                    sql: "IntegracaoParceiroCompraLojaListarPorMaisRecente",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
                return compras;
                
            });

            return result;
        }

        public async Task<IEnumerable<CompraAtivacao>> ListarComAtivacao()
        {
            var result = await WithConnection(DatabaseConnection.Loja, async conn => {

                var compras = await conn.QueryAsync<CompraAtivacao>(
                    sql: "IntegracaoParceiroCompraLojaListarComAtivacao",
                    commandType: CommandType.StoredProcedure);
                return compras;

            });

            return result;
        }

		//public async Task<IEnumerable<CompraERP>> ListarPendenteLN(DateTime? dataUltimaExecucao)
		//{
		//	var result = await WithConnection(DatabaseConnection.Loja, async conn => {

		//		var parameters = new DynamicParameters();
		//		parameters.Add("DataUltimaExecucao", dataUltimaExecucao, DbType.DateTime2);
		//		var compras = await conn.QueryAsync<CompraERP>(
		//			sql: "IntegracaoParceiroLN",
		//			param: parameters,
		//			commandType: CommandType.StoredProcedure);
		//		return compras;

		//	});

		//	return result;
		//}
	}
}
