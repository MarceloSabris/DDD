using BHN.Domain.EGifts.Events;
using BHN.Domain.EGifts.Mappers;
using BHN.Domain.EGifts.Messages;
using BHN.Domain.EGifts.Models;
using BHN.Domain.EGifts.Repositories;
using BHN.Domain.EGifts.Services.Contracts;
using Enterprise.Framework.Domain.Events;
using Enterprise.Framework.Domain.Events.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHN.Domain.EGifts.Services.Implementations
{
    public class GerarEGiftDomainService : IGerarEGiftDomainService
    {
        private readonly IEGiftHttpService _httpService;

        private readonly IAcaoEGiftRepository _acaoEGiftRepository;


        public GerarEGiftDomainService(IEGiftHttpService httpService, IAcaoEGiftRepository acaoEGiftRepository)
        {
            this._httpService = httpService;
            this._acaoEGiftRepository = acaoEGiftRepository;
        }

        public RaiseResult Raise(GerarEGiftEvent domainEvent)
        {
            RaiseResult result = new RaiseResult()
            {
                Mensagem = new EventMessage()
            };

            try
            {
                Task.Run(async () =>
                {
                    try
                    {
                        var gerarEGift = domainEvent.EGift;

                        if (string.IsNullOrEmpty(gerarEGift.Hash))
                        {
                            var gerarHashResponse = await this._httpService.GerarHashEGift(new GenerateEGiftHashRequest()
                            {
                                ClienteId = gerarEGift.ClienteId,
                                NumeroPedido = gerarEGift.NumeroPedido,
                                Preco = gerarEGift.Preco,
                                ProductConfigutationId = gerarEGift.SKUParceiro,
                                RequisicaoId = gerarEGift.RequisicaoId,
                                TentativasAnteriores = gerarEGift.TentativasAnteriores
                            });

                            gerarEGift.ClienteId = gerarHashResponse.AccountId;
                            gerarEGift.Hash = gerarHashResponse.EntityId;

                            if (gerarEGift.GerarCodigoAtivacao)
                            {
                                var gerarKeyResponse = await this._httpService.GerarKeyEGift(new GenerateEGiftKeyRequest()
                                {
                                    Hash = gerarEGift.Hash,
                                    IdCliente = gerarEGift.ClienteId
                                });

                                gerarEGift.Ativacao = gerarKeyResponse.ActivationAccountNumber;

                                foreach (var mensagem in gerarKeyResponse.Mensagens)
                                    result.Mensagem.Content = result.Mensagem.Content.ConcatenarErros(mensagem.Conteudo);
                            }
                            else
                            {
                                gerarEGift.Ativacao = gerarHashResponse.ActivationUrl;
                            }

                            result.IsValid = true;

                        }
                        else if (gerarEGift.GerarCodigoAtivacao)
                        {
                            var gerarKeyResponse = await this._httpService.GerarKeyEGift(new GenerateEGiftKeyRequest()
                            {
                                Hash = gerarEGift.Hash,
                                IdCliente = gerarEGift.ClienteId
                            });

                            foreach (var mensagem in gerarKeyResponse.Mensagens)
                                result.Mensagem.Content = result.Mensagem.Content.ConcatenarErros(mensagem.Conteudo);

                            gerarEGift.Ativacao = gerarKeyResponse.ActivationAccountNumber;

                            result.IsValid = true;
                        }
                    }
                    catch (BHNResponseException bhnEx)
                    {
                        result.IsValid = false;
                        result.Mensagem.Content = result.Mensagem.Content.ConcatenarErros(bhnEx.ToString());                        

                        var erros = await _acaoEGiftRepository.ObterPorNumero((int)bhnEx.StatusCode);
                        if (erros.Any())
                        {

                            var acao = erros.Count() > 1
                                        ? (erros.FirstOrDefault(q => q.CodigoRetorno.ToLower() == bhnEx.ErrorCode.ToLower()) ?? new AcaoEGift() { Desfazer = false })
                                        : erros.FirstOrDefault()
                                        ;

                            domainEvent.EGift.DesfazimentoNecessario = acao.Desfazer;

                            if (!string.IsNullOrEmpty(acao.Descricao) && !string.IsNullOrEmpty(acao.Acao))
                            {
                                result.Mensagem.Content = result.Mensagem.Content.ConcatenarErros(acao.ToString());
                            }

                            if (acao.Desfazer)
                            {
                                var desfazimentoResponse = await _httpService.DesfazimentoEGift(new DesfazimentoEGiftRequest()
                                {
                                    RequisicaoId = domainEvent.EGift.RequisicaoId
                                });

                                domainEvent.EGift.DesfazimentoExecutado = desfazimentoResponse.Valido;

                                if (desfazimentoResponse.Valido)
                                {
                                    result.Mensagem.Content = result.Mensagem.Content.ConcatenarErros("Desfazimento realizado com sucesso.");
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                })
                .GetAwaiter()
                .GetResult()
                ;
            }
            catch (Exception e)
            {
                result.IsValid = false;
                result.Mensagem = new EventMessage
                {
                    Content = e.InnerException.ToString(),
                    Type = MessageType.ApplicationError
                };
            }
            return result;
        }
    }
}