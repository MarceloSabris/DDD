using Enterprise.Framework.Services.Messages;
using FluentValidation;
using FluentValidation.Results;
using Loja.Application.ComprasERP.Dtos;
using Loja.Core.Validations;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Loja.Application.ComprasERP.Messages
{
    [DataContract(Namespace = "http://bhn.api-cnova.com.br/bhn/v1/compras")]
    public class AlterarStatusERPRequest : BaseRequest
    {
        private readonly EnterpriseValidator<AlterarStatusERPRequest> _validator;
        public AlterarStatusERPRequest()
        {

            _validator = new EnterpriseValidator<AlterarStatusERPRequest>();
            SetValidationRules();
        }
        [DataMember(Name = "CompraERP")]
        public CompraERPDto CompraERP { get; set; }

        public ValidationResult Validate()
        {
            return _validator.Validate(this);
        }

        private void SetValidationRules()
        {
            _validator.RuleFor(request => request.CompraERP)
                        .Cascade(CascadeMode.Continue)
                        .NotNull();

            _validator.RuleFor(request => request.CompraERP.IdCompra)
                      .Cascade(CascadeMode.Continue)
                      .NotNull()
                      .GreaterThan(0);

            _validator.RuleFor(request => request.CompraERP.IdCompraEntregaSku)
                      .Cascade(CascadeMode.Continue)
                       .NotNull()
                       .GreaterThan(0);

			_validator.RuleFor(request => request.CompraERP.StatusIntegracaoERP)
					.Cascade(CascadeMode.Continue)
					 .NotNull();
		}
    }
}
