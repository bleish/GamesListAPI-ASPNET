using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GamesListAPI.Models
{
    public class Game
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string System { get; set; }
        public int ReleaseDate { get; set; }
    }
}