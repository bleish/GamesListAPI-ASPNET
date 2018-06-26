using System.Collections.Generic;
using System.Threading.Tasks;
using GamesListAPI.Configuration;
using GamesListAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GamesListAPI.Repository
{
    public class GamesRepository : IGamesRepository
    {
        private IMongoCollection<Game> Collection { get; set; }

        public GamesRepository(IOptions<MongoConnectionConfiguration> options)
        {
            // TODO: Research and add error handling
            var client = new MongoClient(options.Value.ConnectionString);
            var database = client.GetDatabase(options.Value.Database);
            Collection = database.GetCollection<Game>("games");
        }

        public async Task<IEnumerable<Game>> GetMany()
        {
            return await Collection.Find(Builders<Game>.Filter.Empty).ToListAsync();
        }

        public async Task<Game> GetOne(ObjectId id)
        {
            return await Collection.Find(g => g.Id == id).FirstOrDefaultAsync();
        }

        public async Task Add(Game game)
        {
            await Collection.InsertOneAsync(game);
        }

        public async Task<bool> Remove(ObjectId id)
        {
            var actionResult = await Collection.DeleteOneAsync(g => g.Id == id);
            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }

        public async Task<bool> Update(Game game)
        {
            var update = Builders<Game>.Update
                .Set(g => g.Title, game.Title)
                .Set(g => g.System, game.System)
                .Set(g => g.ReleaseDate, game.ReleaseDate);

            var actionResult = await Collection.UpdateOneAsync(g => g.Id == game.Id, update);
            return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
        }
    }
}