using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models.Tasks
{
    public class UserTask
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? Name { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime? CompletedTime { get; set; }
    }
}
