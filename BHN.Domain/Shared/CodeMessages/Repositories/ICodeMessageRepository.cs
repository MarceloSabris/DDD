using BHN.Domain.Shared.CodeMessages.Models;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BHN.Domain.Shared.CodeMessages.Repositories
{
    public interface ICodeMessageRepository
    {
        CodeMessage Obter(string code);
        Task<CodeMessage> ObterAsync(string code);
        Task<IList<CodeMessage>> ListarAsync();
        Task<IList<CodeMessage>> ListarAsync(ValidationResult validationResult);
        Task<IList<CodeMessage>> ListarAsync(IEnumerable<ValidationResult> validationResults);
    }
}
