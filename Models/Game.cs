using MongoDB.Bson;

namespace GamesListAPI.Models
{
    public class Game
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string System { get; set; }
        public int ReleaseDate { get; set; }
    }
}