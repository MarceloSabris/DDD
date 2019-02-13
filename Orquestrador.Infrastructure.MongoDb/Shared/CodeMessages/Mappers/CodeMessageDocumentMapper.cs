using Orquestrador.Domain.Shared.CodeMessages.Models;
using Orquestrador.Infrastructure.MongoDb.Shared.CodeMessages.Documents;

namespace Orquestrador.Infrastructure.MongoDb.Shared.CodeMessages.Mappers
{
    internal static class CodeMessageDocumentMapper
    {
        internal static CodeMessage Mapper(this CodeMessageDocument document)
        {
            if (document == null) return null;
            return new CodeMessage(document.Code, document.Message, document.FormattedMessage);
        }
    }
}