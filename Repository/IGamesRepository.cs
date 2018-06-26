using System.Collections.Generic;
using System.Threading.Tasks;
using GamesListAPI.Models;
using MongoDB.Bson;

namespace GamesListAPI.Repository
{
    public interface IGamesRepository
    {
        Task<IEnumerable<Game>> GetMany();
        Task<Game> GetOne(ObjectId id);
        Task Add(Game game);
        Task<bool> Remove(ObjectId id);
        Task<bool> Update(Game game);
    }
}