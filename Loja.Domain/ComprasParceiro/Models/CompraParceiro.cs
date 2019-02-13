using Enterprise.Framework.Domain.BusinessResults;
using Enterprise.Framework.Domain.Events;
using Enterprise.Framework.Services.Messages;
using Loja.Domain.ComprasParceiro.Events;
using Loja.Domain.ComprasParceiro.Mappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Domain.ComprasParceiro.Models
{
   public class CompraParceiro
    {
        public int IdCompra { get; set; }
        public int IdProdutoParceiro { get; set; }
        public int IdCompraEntregaSku { get; set; }
        public string Ativacao { get; set; }
        public string StatusIntegracaoParceiro { get; set; }
        public DateTime DataInclusao { get; set; }        
        public string EmailEnvioAtivacao { get; set; }
        public string EmailEnvioAceito { get; set; }
		public string  StatusAceite { get; set; }
		public DateTime? DataStatusAceite { get; set; }		
        public DateTime? DataEnvioAceite { get; set; }
        public DateTime? DataIntegracaoParceiro { get; set; }
        public string LogRetornoParceiro { get; set; }
        public DateTime? DataEnvioAtivacao { get; set; }
        public string Hash { get; set; }
        public string RequisicaoId { get; set; }
        public int TentativasIntegracao { get; set; }
        public string ClienteId { get; set; }


        public async Task<BusinessResult> ObterUltima(string correlationId)
        {
            var obterUltimaEvent = new ObterUltimaEvent(this, correlationId);

            EventResult eventResult = await DomainEventManager.RaiseAsync(obterUltimaEvent);

            if (!eventResult.IsValid)
                return eventResult.Map(TipoMensagem.ErroAplicacao);

            var ultimaCompra = obterUltimaEvent.Compra;
            if (ultimaCompra == null)
                return eventResult.Map(TipoMensagem.ErroNegocio);

            this.IdCompra = ultimaCompra.IdCompra;
            this.IdCompraEntregaSku = ultimaCompra.IdCompraEntregaSku;
            this.IdProdutoParceiro = ultimaCompra.IdProdutoParceiro;
            this.StatusIntegracaoParceiro = ultimaCompra.StatusIntegracaoParceiro;
            this.EmailEnvioAceito = ultimaCompra.EmailEnvioAceito;
            this.EmailEnvioAtivacao = ultimaCompra.EmailEnvioAtivacao;
			this.StatusAceite = ultimaCompra.StatusAceite;
            this.DataStatusAceite = ultimaCompra.DataStatusAceite;
            this.DataInclusao = ultimaCompra.DataInclusao;
            this.DataEnvioAceite = ultimaCompra.DataEnvioAceite;
            this.Ativacao = ultimaCompra.Ativacao;
            this.DataEnvioAtivacao = ultimaCompra.DataEnvioAtivacao;
            this.DataIntegracaoParceiro = ultimaCompra.DataIntegracaoParceiro;

            return eventResult.Map();
        }

        public async Task<BusinessResult> Inserir(string correlationId)
        {
            EventResult eventResult = await DomainEventManager.RaiseAsync(new InserirEvent(this, correlationId));
            if (!eventResult.IsValid)
                return eventResult.Map(TipoMensagem.ErroAplicacao);

            return eventResult.Map();
        }

        public async Task<BusinessResult> Alterar(string correlationId)
        {
            EventResult eventResult = await DomainEventManager.RaiseAsync(new AlterarEvent(this, correlationId));
            if (!eventResult.IsValid)
                return eventResult.Map(TipoMensagem.ErroAplicacao);

            return eventResult.Map();
        }



        public async Task<BusinessResult> AlterarStatusAceite(string correlationId)
		{
			EventResult eventResult = await DomainEventManager.RaiseAsync(new AlterarStatusAceiteEvent(this, correlationId));
			if (!eventResult.IsValid)
				return eventResult.Map(TipoMensagem.ErroAplicacao);

			return eventResult.Map();
		}

        public async Task<BusinessResult> AlterarStatusParceiro(string correlationId)
        {
            EventResult eventResult = await DomainEventManager.RaiseAsync(new AlterarStatusParceiroEvent(this, correlationId));
            if (!eventResult.IsValid)
                return eventResult.Map(TipoMensagem.ErroAplicacao);

            return eventResult.Map();
        }

        public async Task<BusinessResult> AlterarStatusAtivacao(string correlationId)
        {
            EventResult eventResult = await DomainEventManager.RaiseAsync(new AlterarStatusAtivacaoEvent(this, correlationId));
            if (!eventResult.IsValid)
                return eventResult.Map(TipoMensagem.ErroAplicacao);

            return eventResult.Map();
        }

        public bool Validar()
        {
            return this.IdCompra > 0
                && this.IdCompraEntregaSku > 0
                && this.IdProdutoParceiro > 0;
        }
    }
}
