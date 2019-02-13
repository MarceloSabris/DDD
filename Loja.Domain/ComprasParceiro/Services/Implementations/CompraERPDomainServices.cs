using Enterprise.Framework.Domain.Events;
using Enterprise.Framework.Domain.Events.Messages;
using Loja.Domain.ComprasParceiro.Events;
using Loja.Domain.ComprasParceiro.Repositories;
using Loja.Domain.ComprasParceiro.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Domain.ComprasParceiro.Services.Implementations
{
	public class CompraERPDomainServices : ICompraERPDomainServices
	{
		private readonly ICompraERPRepository _compraERPRepository;

		public CompraERPDomainServices(ICompraERPRepository compraERPRepository)
		{
			_compraERPRepository = compraERPRepository;
		}
		public RaiseResult Raise(AlterarStatusERPEvent domainEvent)
		{
			RaiseResult result = new RaiseResult();

			try
			{
				Task.Run(async () =>
				{
					var alterar = await _compraERPRepository.AlterarERPAsync (domainEvent.compraERP);
				}).GetAwaiter().GetResult();

				result.IsValid = true;

			}
			catch (Exception ex)
			{
				result.IsValid = false;
				result.Mensagem = new EventMessage
				{
					Content = ex.InnerException.ToString(),
					Type = MessageType.ApplicationError
				};
			}
			return result;
		}
	}
}
