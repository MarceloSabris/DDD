using MongoDB.Bson.Serialization.Attributes;

namespace Orquestrador.Infrastructure.MongoDb.Shared.CodeMessages.Documents
{
    public class CodeMessageDocument
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public string Code { get; set; }
        public string Message { get; set; }
        public string FormattedMessage { get; set; }
    }
}
