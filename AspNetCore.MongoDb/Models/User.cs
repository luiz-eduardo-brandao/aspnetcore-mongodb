using MongoDB.Bson.Serialization.Attributes;

namespace AspNetCore.MongoDb.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        
        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
    }
}