using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GamesListAPI.Models
{
    public class Game
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("title")]
        [Required]
        public string Title { get; set; }

        [BsonElement("system")]
        [Required]
        public string System { get; set; }

        [BsonElement("releaseDate")]
        [Required]
        public int ReleaseDate { get; set; }
    }
}