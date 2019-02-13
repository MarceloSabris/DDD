using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Orquestrador.Core.Validations
{
    public static class EnterpriseValidatorExtensions
    {
        public static bool IsValid(this IEnumerable<ValidationResult> validations)
        {
            if (validations == null)
            {
                return true;
            }
            return validations.All(v => v.IsValid);
        }
    }
}
