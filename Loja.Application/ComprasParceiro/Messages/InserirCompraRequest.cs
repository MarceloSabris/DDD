
using Enterprise.Framework.Services.Messages;
using FluentValidation;
using FluentValidation.Results;
using Loja.Application.ComprasParceiro.Dtos;
using Loja.Core.Validations;
using Loja.Domain.Shared.CodeMessages.Models;
using System;
using System.Collections.Generic;

using System.Runtime.Serialization;
using System.Text;

namespace Loja.Application.ComprasParceiro.Messages
{
    [DataContract(Namespace = "http://bhn.api-cnova.com.br/loja/v1/compras")]
    public class InserirCompraRequest : BaseRequest
    {
        private readonly EnterpriseValidator<InserirCompraRequest> _validator;
        public InserirCompraRequest()
        {

            _validator = new EnterpriseValidator<InserirCompraRequest>();
            SetValidationRules();
        }
        [DataMember(Name = "CompraParceiro")]
        public CompraParceiroDto CompraParceiro { get; set; }

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
                      //.WithErrorCode(CodeMessageConstants.Validation.CampoIdCompraObrigatorio);

            _validator.RuleFor(request => request.CompraParceiro.IdCompraEntregaSku)
                      .Cascade(CascadeMode.Continue)
                       .NotNull()
                       .GreaterThan(0);
            //.WithErrorCode(CodeMessageConstants.Validation.CampoIdCompraSKUObrigatorio);

            _validator.RuleFor(request => request.CompraParceiro.IdProdutoParceiro)
                      .Cascade(CascadeMode.Continue)
                       .NotNull()
                       .GreaterThan(0);
                      //.WithErrorCode(CodeMessageConstants.Validation.CampoStautsAceiteObrigatorio);

        }
    }
}
