
using FluentValidation;
using FluentValidation.Results;
using Loja.Application.Utils;
using Loja.Core.Validations;
using Loja.Domain.Shared.CodeMessages.Models;
using System;
using System.Runtime.Serialization;

namespace Loja.Application.TermoAceite.Messages
{
    [DataContract(Namespace = "http://corporativo.api-cnova.com.br/Orquestradors/v1/postagens")]
    public class StatusAceiteRequest : BaseOrquestradorRequest
    {
        private readonly EnterpriseValidator<StatusAceiteRequest> _validator;

        public StatusAceiteRequest()
		{ 
        
            _validator = new EnterpriseValidator<StatusAceiteRequest>();
            SetValidationRules();
        }
        [DataMember(Name = "idCompra")]
        public int IdCompra { get; set; }

        [DataMember(Name = "idCompraSKU")]
        public int IdCompraSKU { get; set; }

		[DataMember(Name = "StatusAceite")]
		public string StatusAceite { get; set; }

        public ValidationResult Validate()
        {
            return _validator.Validate(this);
        }

        private void SetValidationRules()
        {
            _validator.RuleFor(request => request.IdCompra)
                      .Cascade(CascadeMode.Continue)
                      .NotNull()
                      .WithErrorCode(CodeMessageConstants.Validation.CampoIdCompraObrigatorio);

            _validator.RuleFor(request => request.IdCompraSKU)
                      .Cascade(CascadeMode.Continue)
					   .NotNull()
					  .WithErrorCode(CodeMessageConstants.Validation.CampoIdCompraSKUObrigatorio);

			_validator.RuleFor(request => request.StatusAceite)
					  .Cascade(CascadeMode.Continue)
					   .NotNull()
					  .WithErrorCode(CodeMessageConstants.Validation.CampoStautsAceiteObrigatorio);

        }
    }
}
