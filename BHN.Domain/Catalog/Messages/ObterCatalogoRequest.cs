using BHN.Core.Validations;
using Enterprise.Framework.Services.Messages;
using FluentValidation;
using FluentValidation.Results;
using System.Runtime.Serialization;

namespace BHN.Domain.Catalog.Messages
{
    [DataContract(Namespace = "http://bhn.api-cnova.com.br/bhn/v1/catalog")]
    public class ObterCatalogoRequest : BaseRequest
    {
        public string IdCatalogo { get; set; }

        private readonly EnterpriseValidator<ObterCatalogoRequest> _validator;

        public ObterCatalogoRequest()
        {
            _validator = new EnterpriseValidator<ObterCatalogoRequest>();
            SetValidationRules();
        }

        public ValidationResult Validate()
        {
            return _validator.Validate(this);
        }

        private void SetValidationRules()
        {
            _validator
                .RuleFor(request => request.IdCatalogo)
                .Cascade(CascadeMode.Continue)
                .NotEmpty()
                .NotNull()
                ;
        }

    }
}
