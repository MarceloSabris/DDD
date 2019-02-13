using BHN.Core.Validations;
using Enterprise.Framework.Services.Messages;
using FluentValidation;
using FluentValidation.Results;
using System.Runtime.Serialization;


namespace BHN.Domain.Catalog.Messages
{
    [DataContract(Namespace = "http://bhn.api-cnova.com.br/bhn/v1/catalog")]
    public class VersaoCatalogoRequest : BaseRequest
    {
        private readonly EnterpriseValidator<VersaoCatalogoRequest> _validator;

        public VersaoCatalogoRequest()
        {
            _validator = new EnterpriseValidator<VersaoCatalogoRequest>();
            SetValidationRules();
        }

        public ValidationResult Validate()
        {
            return _validator.Validate(this);
        }

        private void SetValidationRules()
        {

        }
    }
}