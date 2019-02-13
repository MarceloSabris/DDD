
using Enterprise.Framework.Services.Messages;
using Loja.Application.ComprasParceiro.Messages;
using Loja.Application.ComprasParceiro.Services;
using Loja.Application.Impl.ComprasParceiro.Mappers;
using Loja.Domain.ComprasParceiro.Models;
using Loja.Domain.ComprasParceiro.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.Impl.ComprasParceiro.Services
{
    public class CompraParceiroService : ICompraParceiroService
    {
        private readonly ICompraParceiroRepository _compraRepository;

        
        public CompraParceiroService(ICompraParceiroRepository compraRepository)
        {
            this._compraRepository = compraRepository;
        }

        public async Task<AlterarStatusParceiroResponse> AlterarStatusParceiro(AlterarStatusParceiroRequest request)
        {
            var response = new AlterarStatusParceiroResponse();

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
                var compraParceiro = request.CompraParceiro.MapStatus();

                string correlationId = System.Guid.NewGuid().ToString();

                var result = await compraParceiro.AlterarStatusParceiro(correlationId);

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
                response.Valido = false;
                response.AdicionarMensagemErro(TipoMensagem.ErroNegocio, appEx.Message);
            }
            catch (Exception ex)
            {
                response.Valido = false;
                response.AdicionarMensagemErro(TipoMensagem.ErroAplicacao, ex.StackTrace);
            }
            return response;
        }

        public async Task<InserirCompraResponse> InserirCompraParceiro(InserirCompraRequest request)
        {
            var response = new InserirCompraResponse();

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
                var compraParceiro = request.CompraParceiro.Map();

                if (!compraParceiro.Validar())
                {
                    response.Valido = false;
                    response.AdicionarMensagemErro(TipoMensagem.ErroNegocio, "Compra parceiro inválida.");
                    return response;
                }

                string correlationId = System.Guid.NewGuid().ToString();

                var result = await compraParceiro.Inserir(correlationId);

                if (!result.Valido)
                {
                    response.Valido = false;
                    response.AdicionarMensagemErro(TipoMensagem.ErroNegocio, "Compra parceiro não foi inserida.");
                }
                else
                {
                    response.CompraParceiro = compraParceiro.Map();
                    response.Valido = true;
                }

            }
            catch (ApplicationException appEx)
            {
                response.Valido = false;
                response.AdicionarMensagemErro(TipoMensagem.ErroNegocio, appEx.Message);
            }
            catch (Exception ex)
            {
                response.Valido = false;
                response.AdicionarMensagemErro(TipoMensagem.ErroAplicacao, ex.StackTrace);
            }
            return response;
        }

        public async Task<ListarCompraResponse> Listar(ListarComprasRequest request)
        {
            var response = new ListarCompraResponse();
            try
            {
                var compras = await this._compraRepository.Listar(request.IdCompra, request.IdCompraEntregaSku, request.IdProdutoParceiro);

                response.ComprasParceiro = compras.Select(c => c.Map()).ToList();
                response.Valido = true;

            }
            catch (ApplicationException appEx)
            {
                response.Valido = false;
                response.AdicionarMensagemErro(TipoMensagem.ErroNegocio, appEx.Message);
            }
            catch (Exception ex)
            {
                response.Valido = false;
                response.AdicionarMensagemErro(TipoMensagem.ErroAplicacao, ex.StackTrace);
            }
            return response;
        }

      
        public async Task<ObterUltimaCompraResponse> ObterUltimaCompra(ObterUltimaCompraRequest request)
        {
            var response = new ObterUltimaCompraResponse();
            try
            {

                string correlationId = System.Guid.NewGuid().ToString();

                var compraParceiro = new CompraParceiro();

                var result = await compraParceiro.ObterUltima(correlationId);

                if (!result.Valido || !compraParceiro.Validar())
                {
                    response.Valido = false;
                    response.AdicionarMensagemErro(TipoMensagem.ErroNegocio, "Compra parceiro não encontrada.");
                }
                else
                {
                    response.CompraParceiro = compraParceiro.Map();
                    response.Valido = true;
                }
               
            }
            catch (ApplicationException appEx)
            {
                response.Valido = false;
                response.AdicionarMensagemErro(TipoMensagem.ErroNegocio, appEx.Message);
            }
            catch (Exception ex)
            {
                response.Valido = false;
                response.AdicionarMensagemErro(TipoMensagem.ErroAplicacao, ex.StackTrace);
            }
            return response;
        }
    }
}
