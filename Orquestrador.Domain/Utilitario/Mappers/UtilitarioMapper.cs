using Orquestrador.Domain.Loja.Models;
using Orquestrador.Domain.Utilitario.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orquestrador.Domain.Utilitario.Mappers
{
    public static class UtilitarioMapper
    {

        public static EnviarEmailRequest Map(this Pedido model, IEnumerable<Sku> skusAgrupados)
        {
            var emailRequest = new Utilitario.Messages.EnviarEmailRequest()
            {
                Email = new Utilitario.Dtos.EmailDto()
                {
                    IdCliente=model.Cliente.IdCliente,                    
                    EmailDestino= !string.IsNullOrEmpty(model.Cliente.EmailEnvioAtivacao) ? model.Cliente.EmailEnvioAtivacao : model.Cliente.EmailEnvioAceito,                    
                    IdCompra=model.IdCompra,                    
                    NomeDestino= string.Format("{0} {1}", model.Cliente.Nome, model.Cliente.Sobrenome),
                    ChavesValor = new List<Utilitario.Dtos.ChaveValorDto>()
                }
            };

            emailRequest.Email.ChavesValor.Add(new Dtos.ChaveValorDto()
            {
                Chave= "#(PED_CLIE_ORIG)",
                Valor =model.IdCompra.ToString()
            });

            emailRequest.Email.ChavesValor.Add(new Dtos.ChaveValorDto()
            {
                Chave = "#(CLIE_NOME)",
                Valor = string.Format("{0} {1}", model.Cliente.Nome , model.Cliente.Sobrenome)
            });

            var ativacao = skusAgrupados.Select(x =>x.Ativacao);

            emailRequest.Email.ChavesValor.Add(new Dtos.ChaveValorDto()
            {
                Chave = "#(CODIGO_ATIVACAO)",
                Valor = string.Join("<BR>", ativacao)
            });

            var termosCondicoes = skusAgrupados.Select(x =>x.TermosCondicoes);

            emailRequest.Email.ChavesValor.Add(new Dtos.ChaveValorDto()
            {
                Chave = "#(TERMOS_CONDICOES)",
                Valor = string.Join("<BR>", termosCondicoes)
            });

            emailRequest.Email.ChavesValor.Add(new Dtos.ChaveValorDto()
            {
                Chave = "#(ENDERECO)",
                Valor = string.Format("{0} {1}<BR>{2} {3}<BR>{4} {5} {6}",
                            model.Endereco.Rua, model.Endereco.Numero,
                            model.Endereco.Bairro, model.Endereco.Cep,
                            model.Endereco.Complemento, model.Endereco.Municipio, model.Endereco.Pais)
            });

            emailRequest.Email.ChavesValor.Add(new Dtos.ChaveValorDto()
            {
                Chave = "#(PRODUTO_NOME)",
                Valor = skusAgrupados.FirstOrDefault().Produto
            });


            emailRequest.Email.ChavesValor.Add(new Dtos.ChaveValorDto()
            {
                Chave = "#(TOTAL_PRODUTO)",
                Valor = skusAgrupados.Count().ToString()
            });

            return emailRequest;
        }
    }
}
