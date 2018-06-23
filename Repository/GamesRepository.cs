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

        public Task<IEnumerable<Game>> GetMany()
        {
            throw new System.NotImplementedException();
        }

        public Task<Game> GetOne(ObjectId id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Remove(ObjectId id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(Game game)
        {
            throw new System.NotImplementedException();
        }
    }
}