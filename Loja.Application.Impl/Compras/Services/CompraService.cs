using Enterprise.Framework.Services.Messages;
using Loja.Application.Compras.Messages;
using Loja.Application.Compras.Services;
using Loja.Application.Impl.Compras.Mappers;
using Loja.Domain.Compras.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.Impl.Compras.Services
{
    public class CompraService : ICompraService
    {
        private readonly ICompraRepository _compraRepository;

        public CompraService(ICompraRepository compraRepository)
        {
            this._compraRepository = compraRepository;
        }
        

        public async Task<ObterCompraElegivelResponse> ObterComprasElegiveis(ObterCompraElegivelRequest request)
        {
            var response = new ObterCompraElegivelResponse();
            try
            {               
                var compras = await this._compraRepository.ListarElegiveisAsync(request.DataUltimaExecucao);

                response.ComprasElegives = compras.Select(c => c.Map()).ToList();
                response.Valido = true;
            }
            catch(Exception ex)
            {
                response.Valido = false;
                response.AdicionarMensagemErro(TipoMensagem.ErroAplicacao, ex.StackTrace);

            }
            return response;
        }
    }
}
