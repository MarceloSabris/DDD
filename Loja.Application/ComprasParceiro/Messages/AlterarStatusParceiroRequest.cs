
using Enterprise.Framework.Services.Messages;
using FluentValidation;
using FluentValidation.Results;
using Loja.Application.ComprasParceiro.Dtos;
using Loja.Core.Validations;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Loja.Application.ComprasParceiro.Messages
{
    [DataContract(Namespace = "http://bhn.api-cnova.com.br/bhn/v1/compras")]
    public class AlterarStatusParceiroRequest : BaseRequest
    {
        private readonly EnterpriseValidator<AlterarStatusParceiroRequest> _validator;
        public AlterarStatusParceiroRequest()
        {

            _validator = new EnterpriseValidator<AlterarStatusParceiroRequest>();
            SetValidationRules();
        }
        [DataMember(Name = "CompraParceiro")]
        public AlterarStatusParceiroDto CompraParceiro { get; set; }

        public ValidationResult Validate()
        {
            return _validator.Validate(this);
        }

        private void SetValidationRules()
        {
            _validator.RuleFor(request => request.CompraParceiro)
                        .Cascade(CascadeMode.Continue)
                        .NotNull();

            _validator.RuleFor(request => request.CompraParceiro.IdCompra)
                      .Cascade(CascadeMode.Continue)
                      .NotNull()
                      .GreaterThan(0);
         
            _validator.RuleFor(request => request.CompraParceiro.IdCompraEntregaSku)
                      .Cascade(CascadeMode.Continue)
                       .NotNull()
                       .GreaterThan(0);
        }
    }
}
