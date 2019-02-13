using BHN.Domain.EGifts.Dtos;
using BHN.Domain.EGifts.Messages;
using BHN.Domain.EGifts.Models;
using System.Collections.Generic;
using System.Linq;

namespace BHN.Domain.EGifts.Mappers
{
    public static class EGiftMapper
    {
        public static GenerateEGiftHashResponse Map(this GerarEGiftResponse response)
        {
            return new GenerateEGiftHashResponse()
            {
                AccountId = response.AccountId,
                EntityId = response.EntityId,
                Status = response.Status               
            };
        }

        public static GenerateEGiftKeyResponse Map(this GerarKeyResponse response)
        {
            return new GenerateEGiftKeyResponse()
            {
                AccountNumber = response.AccountNumber,
                ActivationAccountNumber = response.ActivationAccountNumber,
                BalanceResponse = response.BalanceResponse,
                EntityId = response.EntityId,
                SecurityCode = response.SecurityCode                
            };
        }

        public static GenerateEGiftKeyRequest Map(this GenerateEGiftHashResponse response)
        {
            return new GenerateEGiftKeyRequest()
            {
                Hash = response.EntityId,
                IdCliente = response.AccountId
            };
        }

        public static string ConcatenarErros(this string erros, string erro, string separador = "#$@")
        {
            erros = string.Format("{0}{1}{2}", erros, separador, erro);
            if (erros.StartsWith(separador)) erros = erros.Substring(separador.Length);
            return erros;
        }

        public static List<string> ObterErros(this string erros, string separador = "#$@")
        {
            return erros.Split(separador.ToCharArray()).ToList();
        }

        public static string ObterHash(this GenerateEGiftHashResponse response)
        {
            var hash = response.EntityId;
            hash = hash.Substring(hash.LastIndexOf('/') + 1);
            return hash;
        }

        public static string ObterHash(this GerarEGiftResponse response)
        {
            var hash = response.EntityId;
            hash = hash.Substring(hash.LastIndexOf('/') + 1);
            return hash;
        }

        public static string ObterAccountId(this GenerateEGiftHashResponse response)
        {
            var accountId = response.AccountId;

            if (accountId.Contains("accountId="))
            {
                accountId = accountId.Substring(accountId.IndexOf("accountId="));
                accountId = accountId.Replace("accountId=", "");
                return accountId;
            }

            return "";
        }

        public static string ObterAccountId(this GerarEGiftResponse response)
        {
            var accountId = response.AccountId;

            if (accountId.Contains("accountId="))
            {
                accountId = accountId.Substring(accountId.IndexOf("accountId="));
                accountId = accountId.Replace("accountId=", "");
                return accountId;
            }

            return "";
        }

        public static string GerarUrlAtivacao(this GerarEGiftResponse response, string urlTemplate)
        {
            var hash = response.ObterHash();
            if (string.IsNullOrEmpty(urlTemplate) || string.IsNullOrEmpty(hash)) return "";

            return string.Format(urlTemplate, hash);
        }
    }
}