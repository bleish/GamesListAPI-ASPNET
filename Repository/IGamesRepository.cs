using System.Collections.Generic;
using System.Threading.Tasks;
using GamesListAPI.Models;
using MongoDB.Bson;

namespace GamesListAPI.Repository
{
    public interface IGamesRepository
    {
        Task<IEnumerable<Game>> GetMany();
        Task<Game> GetOne(string id);
        Task<Game> Add(Game game);
        Task<bool> Remove(string id);
        Task<bool> Update(Game game);
    }
}