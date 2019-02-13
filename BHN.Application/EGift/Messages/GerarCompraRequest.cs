using BHN.Application.EGift.Dtos;
using BHN.Core.Validations;
using Enterprise.Framework.Services.Messages;
using FluentValidation;
using FluentValidation.Results;
using System.Runtime.Serialization;

namespace BHN.Application.EGift.Messages
{
    [DataContract(Namespace = "http://bhn.api-cnova.com.br/bhn/v1/egift")]
    public class GerarCompraRequest : BaseRequest
    {
        private readonly EnterpriseValidator<GerarCompraRequest> _validator;

        public GerarCompraRequest()
        {
            _validator = new EnterpriseValidator<GerarCompraRequest>();
            SetValidationRules();
        }

        [DataMember(Name = "GerarEGift")]
        public GerarEGiftDto GerarEGift { get; set; }

        public ValidationResult Validate()
        {
            return _validator.Validate(this);
        }

        private void SetValidationRules()
        {
            _validator
                .RuleFor(request => request.GerarEGift)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                ;

            //_validator
            //    .RuleFor(request => request.GerarEGift.ClienteId)
            //    .Cascade(CascadeMode.Continue)
            //    .NotNull()
            //    .NotEmpty()
            //    ;

            _validator
                .RuleFor(request => request.GerarEGift.SKUParceiro)
                .Cascade(CascadeMode.Continue)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255)
                ;

            _validator
                .RuleFor(request => request.GerarEGift.NumeroPedido)
                .Cascade(CascadeMode.Continue)
                .NotNull()
                .NotEmpty()
                .Length(12)
                ;

            _validator
                .RuleFor(request => request.GerarEGift.Preco)
                .Cascade(CascadeMode.Continue)
                .GreaterThan(0)
                ;
        }
    }
}