using Orquestrador.Domain.Loja.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Orquestrador.Domain.Loja.Repositories
{
    public interface ILojaHttpRepository
    {
        Task<ListarComAtivacaoResponse> ListarComAtivacao(ListarComAtivacaoRequest request);

        Task<ObterCompraElegivelResponse> ObterElegiveis(ObterCompraElegivelRequest request);

        Task<InserirCompraParceiroResponse> InserirCompraParceiro(InserirCompraParceiroRequest request);

        Task<AlterarStatusParceiroResponse> AlterarStatusParceiro(AlterarStatusParceiroRequest request);

        Task<AlterarStatusAtivacaoResponse> AlterarStatusAtivacao(AlterarStatusAtivacaoRequest request);

        Task<ListarCompraComAceiteResponse> ListarComAceite(ListarComprasComAceiteRequest request);

        Task<ListarComprasParceiroResponse> ListarComprasParceiro(ListarComprasParceiroRequest request);

        Task<AlterarStatusERPResponse> AlterarStatusERP(AlterarStatusERPRequest request);

        Task<ListarComprasERPResponse> ListarComprasERP(ListarComprasERPRequest request);
    }
}
