using BHN.Domain.EGifts.Models;
using BHN.Domain.EGifts.Repositories;
using Dapper;
using Enterprise.Framework.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BHN.Infrastructure.SqlClient
{
    public class AcaoEGiftRepository : BaseRepository, IAcaoEGiftRepository
    {
        public AcaoEGiftRepository(IConectionFactory connection) : base(connection) { }

        public async Task<IEnumerable<AcaoEGift>> ObterPorCodigoRetorno(string codigo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("CodigoRetorno", codigo, DbType.String);
            parameters.Add("Numero", null);
            parameters.Add("Acao", null);
            parameters.Add("Desfazimento", null);

            var result = await WithConnection(DatabaseConnection.Loja, async conn =>
            {
                var acoes = await conn.QueryAsync<AcaoEGift>(
                    sql: "IntegracaoParceiroBhnAcaoEGiftListar",
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                return acoes;
            });

            return result;
        }

        public async Task<IEnumerable<AcaoEGift>> ObterPorNumero(int numero)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Numero", numero, DbType.Int32);
            parameters.Add("CodigoRetorno", null);
            parameters.Add("Acao", null);
            parameters.Add("Desfazimento", null);

            var result = await WithConnection(DatabaseConnection.Loja, async conn =>
            {
                var acoes = await conn.QueryAsync<AcaoEGift>(
                    sql: "IntegracaoParceiroBhnAcaoEGiftListar",
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                return acoes;
            });

            return result;
        }
    }
}