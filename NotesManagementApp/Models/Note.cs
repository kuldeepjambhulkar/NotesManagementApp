using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NotesManagementApp.Models
{
    [BsonIgnoreExtraElements]
    public class Note
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? Title { get; set; }

        [BsonElement("content")]
        public string? Content { get; set; }
        
        [BsonElement("tags")]
        public List<string>? Tags { get; set; }

        [BsonElement("color")]
        public string? Color { get; set; }
    }
}
