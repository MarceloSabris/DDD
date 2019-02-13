using Loja.Application.Ativacao.Dtos;
using Loja.Domain.Compras.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Application.Impl.Ativacao.Mappers
{
    public static class AtivacaoMapper
    {
        public static CompraAtivacaoDto Map(this CompraAtivacao model)
        {
            return new CompraAtivacaoDto() {
                Ativacao=model.Ativacao,
                Bairro=model.Bairro,
                Cep=model.Cep,
                Complemento=model.Complemento,
                EmailEnvioAceito=model.EmailEnvioAceito,
                EmailEnvioAtivacao=model.EmailEnvioAtivacao,
                Estado=model.Estado,
                Hash=model.Hash,
                IdCompra=model.IdCompra,
                IdCompraEntregaSku=model.IdCompraEntregaSku,
                IdentificacaoEndereco=model.IdentificacaoEndereco,
                IdProdutoParceiro=model.IdProdutoParceiro,
                IdSku=model.IdSku,
                Municipio=model.Municipio,
                Nome=model.Nome,
                Numero=model.Numero,
                Pais=model.Pais,
                PontoReferencia=model.PontoReferencia,
                Produto=model.Produto,
                RequisicaoId=model.RequisicaoId,
                Rua=model.Rua,
                Sobrenome=model.Sobrenome,
                TermosCondicoes=model.TermosCondicoes,
                IdCliente=model.IdCliente
            };

        }

        public static CompraAtivacao Map(this CompraAtivacaoDto model)
        {
            return new CompraAtivacao()
            {
                Ativacao = model.Ativacao,
                Bairro = model.Bairro,
                Cep = model.Cep,
                Complemento = model.Complemento,
                EmailEnvioAceito = model.EmailEnvioAceito,
                EmailEnvioAtivacao = model.EmailEnvioAtivacao,
                Estado = model.Estado,
                Hash = model.Hash,
                IdCompra = model.IdCompra,
                IdCompraEntregaSku = model.IdCompraEntregaSku,
                IdentificacaoEndereco = model.IdentificacaoEndereco,
                IdProdutoParceiro = model.IdProdutoParceiro,
                IdSku = model.IdSku,
                Municipio = model.Municipio,
                Nome = model.Nome,
                Numero = model.Numero,
                Pais = model.Pais,
                PontoReferencia = model.PontoReferencia,
                Produto = model.Produto,
                RequisicaoId = model.RequisicaoId,
                Rua = model.Rua,
                Sobrenome = model.Sobrenome,
                TermosCondicoes = model.TermosCondicoes,

            };

        }
    }
}
