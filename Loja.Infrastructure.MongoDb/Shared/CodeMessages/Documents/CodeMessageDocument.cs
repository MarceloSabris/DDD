using MongoDB.Bson.Serialization.Attributes;

namespace Loja.Infrastructure.MongoDb.Shared.CodeMessages.Documents
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
