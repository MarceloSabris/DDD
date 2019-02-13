
using Enterprise.Framework.Domain.Events;
using Enterprise.Framework.Domain.Events.Messages;
using Loja.Domain.ComprasParceiro.Events;
using Loja.Domain.ComprasParceiro.Mappers;
using Loja.Domain.ComprasParceiro.Repositories;
using Loja.Domain.ComprasParceiro.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Domain.ComprasParceiro.Services.Implementations
{
    public class CompraParceiroDomainService : ICompraParceiroDomainService
    {
      
        private readonly ICompraParceiroRepository _compraParceiroRepository;
    
        public CompraParceiroDomainService(ICompraParceiroRepository compraParceiroRepository)
        {
            _compraParceiroRepository = compraParceiroRepository ?? throw new ArgumentNullException(nameof(compraParceiroRepository));
        }

        public RaiseResult Raise(ObterUltimaEvent domainEvent)
        {
            RaiseResult result = new RaiseResult();
         
            try
            {
                Task.Run(async () =>
                {
                    domainEvent.Compra = await _compraParceiroRepository.ObterUltimaRecente(); 
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

        public RaiseResult Raise(InserirEvent domainEvent)
        {
            RaiseResult result = new RaiseResult();

            try
            {
                Task.Run(async () =>
                {
                    var inserir = await _compraParceiroRepository.Inserir(domainEvent.Compra);
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

        public RaiseResult Raise(AlterarEvent domainEvent)
        {
            RaiseResult result = new RaiseResult();

            try
            {
                Task.Run(async () =>
                {
                    var alterar = await _compraParceiroRepository.Alterar(domainEvent.Compra);
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


		public RaiseResult Raise(AlterarStatusAceiteEvent domainEvent)
		{
			RaiseResult result = new RaiseResult();

			try
			{
				Task.Run(async () =>
				{
					var alterar = await _compraParceiroRepository.AlterarStatusAceiteAsync(domainEvent.Compra.Map());
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

        public RaiseResult Raise(AlterarStatusAtivacaoEvent domainEvent)
        {
            RaiseResult result = new RaiseResult();

            try
            {
                Task.Run(async () =>
                {
                    var alterar = await _compraParceiroRepository.AlterarStatusAtivacao(domainEvent.Compra.MapAtivacao());
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

        public RaiseResult Raise(AlterarStatusParceiroEvent domainEvent)
        {
            RaiseResult result = new RaiseResult();

            try
            {
                Task.Run(async () =>
                {
                    var alterar = await _compraParceiroRepository.AlterarStatusParceiro(domainEvent.Compra.MapParceiro());
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
