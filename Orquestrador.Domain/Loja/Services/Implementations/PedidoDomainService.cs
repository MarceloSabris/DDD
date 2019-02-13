using Enterprise.Framework.Domain.Events;
using Enterprise.Framework.Domain.Events.Messages;
using Orquestrador.Domain.Erp.Repositories;
using Orquestrador.Domain.Loja.Events;
using Orquestrador.Domain.Loja.Repositories;
using Orquestrador.Domain.Loja.Services.Contracts;
using Orquestrador.Domain.Parceiro.Repositories;
using Orquestrador.Domain.Utilitario.Mappers;
using Orquestrador.Domain.Utilitario.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orquestrador.Domain.Loja.Services.Implementations
{
    public class PedidoDomainService : IPedidoDomainService
    {
        private readonly IUtilitarioHttpRepository _utilitarioHttpRepository;
        private readonly ILojaHttpRepository _lojaHttpRepository;
        private readonly IParceiroHttpRepository _parceiroHttpRepository;
        private readonly IErpHttpRepository _erpHttpRepository;

        public PedidoDomainService(IUtilitarioHttpRepository utilitarioHttpRepository, 
            ILojaHttpRepository lojaHttpRepository,
            IParceiroHttpRepository parceiroHttpRepository,
            IErpHttpRepository erpHttpRepository)
        {
            _utilitarioHttpRepository = utilitarioHttpRepository ?? throw new ArgumentNullException(nameof(utilitarioHttpRepository));
            _lojaHttpRepository = lojaHttpRepository ?? throw new ArgumentNullException(nameof(lojaHttpRepository));
            _parceiroHttpRepository = parceiroHttpRepository ?? throw new ArgumentNullException(nameof(parceiroHttpRepository));
            _erpHttpRepository = erpHttpRepository ?? throw new ArgumentNullException(nameof(erpHttpRepository));
        }

        public RaiseResult Raise(EnviarCodigoClienteEvent domainEvent)
        {
            RaiseResult result = new RaiseResult();

            var pedido = domainEvent.Pedido;

            try
            {
                Task.Run(async () =>
                {
                    var enviarEmailsResult = new List<bool>();

                    var emailTipoCodigoAtivacao = await ObterDadosConfiguracao("EmailTipoCodigoAtivacaoBHN");
                    
                    var skusAgrupados = pedido.Skus.GroupBy(x => x.IdSku);

                    foreach (var sku in skusAgrupados)
                    {
                        var compraEntregaSkus = pedido.Skus.Where(x => x.IdSku == sku.Key);

                        var enviarEmailRequest = pedido.Map(compraEntregaSkus);                          
                        enviarEmailRequest.Email.IdEmailTipo = int.Parse(emailTipoCodigoAtivacao);

                        var enviarEmailResponse = await _utilitarioHttpRepository.EnviarEmailOffline(enviarEmailRequest);
                        if (enviarEmailResponse.Valido)
                        {
                            foreach (var item in compraEntregaSkus)
                            {
                                var alterarStatusAtivacaoRequest = new Messages.AlterarStatusAtivacaoRequest()
                                {
                                    CompraAtivacao = new Dtos.AlterarStatusAtivacaoDto()
                                    {
                                        IdCompra = pedido.IdCompra,
                                        IdCompraEntregaSku = item.IdCompraEntregaSku,
                                        DataEnvioAtivacao = DateTime.Now
                                    }
                                };

                                var alterarStatusAtivacaoResponse = await this._lojaHttpRepository.AlterarStatusAtivacao(alterarStatusAtivacaoRequest);
                            }
                        }
                        enviarEmailsResult.Add(enviarEmailResponse.Valido);
                    }

                    result.IsValid = enviarEmailsResult.All(e=>e==true);

                    if (!result.IsValid)
                    {
                        result.Mensagem = new EventMessage
                        {
                            Content = "Não foi possível enviar código pedido p/cliente.",
                            Type = MessageType.BusinessError
                        };
                    }

                }).GetAwaiter().GetResult();

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



        public RaiseResult Raise(EnfileirarEvent domainEvent)
        {
            RaiseResult result = new RaiseResult();

            var pedido = domainEvent.Pedido;

            try
            {
                Task.Run(async () =>
                {
                    var sku = pedido.Skus.FirstOrDefault();

                    var inserirCompraParceiroRequest = new Messages.InserirCompraParceiroRequest()
                    {
                        CompraParceiro = new Dtos.CompraParceiroDto()
                        {
                            IdCompra = pedido.IdCompra,
                            IdCompraEntregaSku = sku.IdCompraEntregaSku,
                            IdProdutoParceiro = sku.IdProdutoParceiro,
                            EmailEnvioAceito = pedido.Cliente.EmailEnvioAceito,
                            EmailEnvioAtivacao = pedido.Cliente.EmailEnvioAtivacao,
                            DataEnvioAceite = DateTime.Now,
                            DataStatusAceite = DateTime.Now,
                            StatusAceite = Convert.ToInt32(true).ToString(),
                            DataInclusao = DateTime.Now
                        }
                    };

                    var inserirCompraParceiroResponse = await this._lojaHttpRepository.InserirCompraParceiro(inserirCompraParceiroRequest);

                    result.IsValid = inserirCompraParceiroResponse.Valido;

                    if (!result.IsValid)
                    {
                        result.Mensagem = new EventMessage
                        {
                            Content = "Não foi possível enfileirar pedido.",
                            Type = MessageType.BusinessError
                        };
                    }

                }).GetAwaiter().GetResult();

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

        public RaiseResult Raise(IntegrarParceiroEvent domainEvent)
        {
            RaiseResult result = new RaiseResult();

            var pedido = domainEvent.Pedido;

            try
            {
                Task.Run(async () =>
                {                    
                    var sku = pedido.Skus.FirstOrDefault();
                                     
                    var gerarCodigoRequest = new Parceiro.Messages.GerarCodigoRequest()
                    {
                        GerarEGift = new Parceiro.Dtos.GerarEGiftDto()
                        {
                            ClienteId = sku.ClienteId,
                            Hash = sku.Hash,
                            NumeroPedido = pedido.IdCompra.ToString().PadLeft(12,'0'),
                            RequisicaoId = sku.RequisicaoId,
                            SKUParceiro = sku.SkuParceiro,
                            TentativasAnteriores= sku.TentativasIntegracao,
                            GerarCodigoAtivacao= (sku.Tipo == Convert.ToInt32(true)),
                            Preco=sku.Preco
                        }
                    };
                    var gerarCodigoResponse = await this._parceiroHttpRepository.GerarCodigo(gerarCodigoRequest);

                    var alterarStatusParceiroRequest = new Messages.AlterarStatusParceiroRequest()
                    {
                        CompraParceiro=new Dtos.AlterarStatusParceiroDto()
                        {
                            Hash=gerarCodigoResponse.Hash,
                            TentativasIntegracao= !gerarCodigoResponse.Valido ? sku.TentativasIntegracao+1 : sku.TentativasIntegracao,
                            Ativacao=gerarCodigoResponse.Ativacao,
                            ClienteId=gerarCodigoResponse.ClienteId,
                            IdCompra=pedido.IdCompra,
                            IdCompraEntregaSku = sku.IdCompraEntregaSku,                            
                            StatusIntegracaoParceiro= (Convert.ToInt16(gerarCodigoResponse.Valido)).ToString(),
                            LogRetornoParceiro = !gerarCodigoResponse.Valido ? String.Join(" | ", gerarCodigoResponse.Mensagens.Select(x=>x.Conteudo)) : string.Empty,
                            RequisicaoId = gerarCodigoResponse.RequisicaoId,
                            DataIntegracaoParceiro= DateTime.Now,    
                        }
                    };
                    var alterarStatusParceiroResponse = await this._lojaHttpRepository.AlterarStatusParceiro(alterarStatusParceiroRequest);

                    result.IsValid = gerarCodigoResponse.Valido && alterarStatusParceiroResponse.Valido;
                    
                    if (!result.IsValid)
                    {
                        result.Mensagem = new EventMessage
                        {
                            Content = "Não foi possível integrar pedido.",
                            Type = MessageType.BusinessError
                        };
                    }

                }).GetAwaiter().GetResult();

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

        public RaiseResult Raise(IntegrarERPEvent domainEvent)
        {
            RaiseResult result = new RaiseResult();

            var pedido = domainEvent.Pedido;

            try
            {
                Task.Run(async () =>
                {
                    var codigoUnidadeNegocio = await ObterDadosConfiguracao("CodUnidadeNegocio");

                    var sku = pedido.Skus.FirstOrDefault();

                    var enviarItemVirtualRequest = new Erp.Messages.EnviarItemVirtualRequest()
                    {
                        ItemVirtual=new Erp.Dtos.ItemEntradaVirtualDto()
                        {
                            GerencialId=sku.GerencialId,
                            IdUnidadeNegocio=Convert.ToInt32(codigoUnidadeNegocio),
                            Sequencial=sku.Sequencial,
                            Usuario="servicos-integracaoparceiro"
                        }
                    };
                    var enviarItemVirtualResponse = await this._erpHttpRepository.EnviarItemVirtual(enviarItemVirtualRequest);

                    var alterarStatusERPRequest = new Messages.AlterarStatusERPRequest()
                    {
                        CompraERP = new Dtos.CompraERPDto()
                        {   
                            TentativasIntegracaoERP = !enviarItemVirtualResponse.Valido ? sku.TentativasIntegracaoERP + 1 : sku.TentativasIntegracaoERP,                           
                            IdCompra = pedido.IdCompra,
                            IdCompraEntregaSku = sku.IdCompraEntregaSku,
                            SequencialId = sku.Sequencial,
                            StatusIntegracaoERP = (Convert.ToInt16(enviarItemVirtualResponse.Valido)).ToString(),
                            LogRetornoERP = !enviarItemVirtualResponse.Valido ? String.Join(" | ", enviarItemVirtualResponse.Mensagens.Select(x => x.Conteudo)) : string.Empty,                            
                            DataIntegracaoERP = DateTime.Now,
                            GerencialId =sku.GerencialId
                        }
                    };
                    var alterarStatusERPResponse = await this._lojaHttpRepository.AlterarStatusERP(alterarStatusERPRequest);

                    result.IsValid = enviarItemVirtualResponse.Valido && alterarStatusERPResponse.Valido;

                    if (!result.IsValid)
                    {
                        result.Mensagem = new EventMessage
                        {
                            Content = "Não foi possível integrar ERP.",
                            Type = MessageType.BusinessError
                        };
                    }

                }).GetAwaiter().GetResult();

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

        private async Task<string> ObterDadosConfiguracao(string nome)
        {
            var dadosConfiguracaoRequest = new Utilitario.Messages.ObterDadosConfiguracaoRequest() { Nome = nome };
            var dadosConfiguracaoResponse = await _utilitarioHttpRepository.ObterDadosConfiguracao(dadosConfiguracaoRequest);

            return dadosConfiguracaoResponse.Configuracao != null ? dadosConfiguracaoResponse.Configuracao.Valor : string.Empty;

        }
    }
}
