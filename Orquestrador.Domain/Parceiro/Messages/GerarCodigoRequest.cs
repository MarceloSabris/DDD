
using Enterprise.Framework.Services.Messages;
using FluentValidation;
using FluentValidation.Results;
using Orquestrador.Domain.Parceiro.Dtos;
using System.Runtime.Serialization;

namespace Orquestrador.Domain.Parceiro.Messages
{
    [DataContract(Namespace = "http://bhn.api-cnova.com.br/bhn/v1/egift")]
    public class GerarCodigoRequest : BaseRequest
    {
        

        public GerarCodigoRequest()
        {
        
        }

        [DataMember(Name = "GerarEGift")]
        public GerarEGiftDto GerarEGift { get; set; }

        
    }
}