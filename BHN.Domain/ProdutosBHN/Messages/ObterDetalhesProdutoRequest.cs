using BHN.Core.Validations;
using Enterprise.Framework.Services.Messages;
using FluentValidation;
using FluentValidation.Results;
using System.Runtime.Serialization;

namespace BHN.Domain.ProdutosBHN.Messages
{
    [DataContract(Namespace = "http://bhn.api-cnova.com.br/bhn/v1/produto")]
    public class ObterDetalhesProdutoRequest : BaseRequest
    {
        [DataMember(Name = "IdProduto")]
        public string IdProduto { get; set; }

        private readonly EnterpriseValidator<ObterDetalhesProdutoRequest> _validator;

        public ObterDetalhesProdutoRequest()
        {
            _validator = new EnterpriseValidator<ObterDetalhesProdutoRequest>();
            SetValidationRules();
        }
        public ValidationResult Validate()
        {
            return _validator.Validate(this);
        }

        private void SetValidationRules()
        {
            _validator
                .RuleFor(request => request.IdProduto)
                .Cascade(CascadeMode.Continue)
                .NotNull()
                .NotEmpty()
                ;
        }
    }
}
