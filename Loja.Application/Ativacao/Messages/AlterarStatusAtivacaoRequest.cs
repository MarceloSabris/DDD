using Enterprise.Framework.Services.Messages;
using FluentValidation;
using FluentValidation.Results;
using Loja.Application.Ativacao.Dtos;
using Loja.Core.Validations;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Loja.Application.Ativacao.Messages
{
    [DataContract(Namespace = "http://loja.api-cnova.com.br/loja/v1/compras")]
    public class AlterarStatusAtivacaoRequest : BaseRequest
    {
        private readonly EnterpriseValidator<AlterarStatusAtivacaoRequest> _validator;
        public AlterarStatusAtivacaoRequest()
        {

            _validator = new EnterpriseValidator<AlterarStatusAtivacaoRequest>();
            SetValidationRules();
        }
        public ValidationResult Validate()
        {
            return _validator.Validate(this);
        }

        private void SetValidationRules()
        {
            _validator.RuleFor(request => request.CompraAtivacao)
                        .Cascade(CascadeMode.Continue)
                        .NotNull();

            _validator.RuleFor(request => request.CompraAtivacao.IdCompra)
                      .Cascade(CascadeMode.Continue)
                      .NotNull()
                      .GreaterThan(0);

            _validator.RuleFor(request => request.CompraAtivacao.IdCompraEntregaSku)
                      .Cascade(CascadeMode.Continue)
                       .NotNull()
                       .GreaterThan(0);



        }
        [DataMember(Name= "CompraAtivacao")]
        public AlterarStatusAtivacaoDto CompraAtivacao {get;set;}
    }
}
