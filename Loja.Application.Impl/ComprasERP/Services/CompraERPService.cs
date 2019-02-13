using Loja.Application.ComprasERP.Messages;
using Loja.Application.ComprasERP.Services;
using Loja.Domain.ComprasParceiro.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Application.Impl.ComprasERP.Mappers;
using Enterprise.Framework.Services.Messages;
using Enterprise.Framework.Logging;
using Enterprise.Framework.Logging.Utils;

namespace Loja.Application.Impl.ComprasERP.Services
{
	public class CompraERPService : ICompraERPService
	{
		private readonly ICompraERPRepository _compraRepository;
        private readonly IResponseUtil _responseUtil;

        public CompraERPService(ICompraERPRepository compraRepository, IResponseUtil responseUtil)
		{
			this._compraRepository = compraRepository;
            this._responseUtil = responseUtil;
		}

		public async Task<AlterarStatusERPResponse> AlterarStatusERPAsync(AlterarStatusERPRequest request)
		{

			var response = new AlterarStatusERPResponse();

			var validationResult = request.Validate();
			if (!validationResult.IsValid)
			{
				response.Valido = false;
				foreach (var failure in validationResult.Errors)
					response.AdicionarMensagemErro(TipoMensagem.Validacao, failure.ErrorMessage);

				return response;
			}

			try
			{
				var compraParceiro = request.CompraERP.MapStatus();

				string correlationId = System.Guid.NewGuid().ToString();

				var result = await compraParceiro.AlterarStatusERP(correlationId);

				if (!result.Valido)
				{
					response.Valido = false;
					response.AdicionarMensagemErro(TipoMensagem.ErroNegocio, "Alterar Status Parceiro não foi realizado.");
				}
				else
				{
					response.Valido = true;
				}

			}
			catch (ApplicationException appEx)
			{
                return _responseUtil.GetResponseError<AlterarStatusERPResponse>(this, appEx);
            }
			catch (Exception ex)
			{
                return _responseUtil.GetResponseError<AlterarStatusERPResponse>(this, ex);
            }
			return response;



		}

		public async Task<ListaComprasERPResponse> ListarAsync()
		{

			var response = new ListaComprasERPResponse();
			try
			{
				var compras = await _compraRepository.ListarERP();

				response.ComprasERP = compras.Select(c => c.Map()).ToList();
				response.Valido = true;

            }
            catch (ApplicationException appEx)
            {
                return _responseUtil.GetResponseError<ListaComprasERPResponse>(this, appEx);
            }
            catch (Exception ex)
			{
                return _responseUtil.GetResponseError<ListaComprasERPResponse>(this, ex);
			}
			return response;
            
		}
	}
}
