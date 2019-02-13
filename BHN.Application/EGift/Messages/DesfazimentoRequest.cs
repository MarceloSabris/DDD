using BHN.Application.EGift.Dtos;
using BHN.Core.Validations;
using Enterprise.Framework.Services.Messages;
using FluentValidation;
using FluentValidation.Results;
using System.Runtime.Serialization;

namespace BHN.Application.EGift.Messages
{
    [DataContract(Namespace = "http://bhn.api-cnova.com.br/bhn/v1/egift")]
    public class DesfazimentoRequest : BaseRequest
    {
        [DataMember(Name = "RequisicaoId")]
        public string RequisicaoId { get; set; }

        private readonly EnterpriseValidator<DesfazimentoRequest> _validator;

        public DesfazimentoRequest()
        {
            _validator = new EnterpriseValidator<DesfazimentoRequest>();
            SetValidationRules();
        }
        public ValidationResult Validate()
        {
            return _validator.Validate(this);
        }

        private void SetValidationRules()
        {
            _validator
                .RuleFor(request => request.RequisicaoId)
                .Cascade(CascadeMode.Continue)
                .NotNull()
                .NotEmpty()
                ;
        }
    }
}
