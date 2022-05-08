using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PerfectSite.Models
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string UserFirstName { get; set; }
        public string UserSecondName { get; set; }
        public string UserId { get; set; }
        public string Value { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}