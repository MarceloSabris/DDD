using Orquestrador.Domain.Loja.Dtos;
using Orquestrador.Domain.Loja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orquestrador.Domain.Loja.Mappers
{
    public static class PedidoMapper
    {
        public static List<Pedido> Map(this List<CompraAtivacaoDto> list)
        {
            var pedidos = new List<Pedido>();

            var agrupados = list.GroupBy(x => x.IdCompra);

            foreach(var g in agrupados)
            {
                var pedido = new Pedido() {
                    IdCompra=g.Key,
                    Skus = new List<Sku>()
                };

                var itens = list.Where(x => x.IdCompra == pedido.IdCompra);
                
                pedido.Skus.AddRange(itens.Select(c => c.MapSku()));
                                
                pedido.Cliente = itens.FirstOrDefault().MapCliente();

                pedido.Endereco = itens.FirstOrDefault().MapEndereco();

                pedidos.Add(pedido);

            }

            return pedidos;
        }

        public static Sku MapSku(this CompraAtivacaoDto model)
        {
            return new Sku() {
                IdSku=model.IdSku,
                Ativacao=model.Ativacao,                
                Hash=model.Hash,
                IdCompraEntregaSku=model.IdCompraEntregaSku,
                IdProdutoParceiro=model.IdProdutoParceiro,
                Produto=model.Produto,
                RequisicaoId=model.RequisicaoId,
                TermosCondicoes=model.TermosCondicoes,
                    
            };
        }

        public static Cliente MapCliente(this CompraAtivacaoDto model)
        {
            return new Cliente() {
                Nome=model.Nome,
                Sobrenome=model.Sobrenome,
                EmailEnvioAceito = model.EmailEnvioAceito,
                EmailEnvioAtivacao = model.EmailEnvioAtivacao,
                IdCliente=model.IdCliente
            };
        }

        public static Endereco MapEndereco(this CompraAtivacaoDto model)
        {
            return new Endereco() {
                Bairro=model.Bairro,
                Cep=model.Cep,
                Complemento=model.Complemento,
                Estado=model.Estado,
                IdentificacaoEndereco=model.IdentificacaoEndereco,
                Municipio=model.Municipio,
                Numero=model.Numero,
                Pais=model.Pais,
                PontoReferencia=model.PontoReferencia,
                Rua=model.Rua,
                    

            };
        }


       

    }
}
