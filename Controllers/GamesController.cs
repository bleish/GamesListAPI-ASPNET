using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GamesListAPI.Models;
using GamesListAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace GamesListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepository _gamesRepository;
        public GamesController(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var games = await _gamesRepository.GetMany();
            return Ok(games);
        }

        [HttpGet("{id}", Name = "GetGame")]
        public async Task<ActionResult> Get(ObjectId id)
        {
            var game = await _gamesRepository.GetOne(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Game game)
        {
            await _gamesRepository.Add(game);
            return CreatedAtRoute("GetGame", new { id = game.Id }, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(ObjectId id, Game game)
        {
            var oldGame = await _gamesRepository.GetOne(id);
            if (oldGame == null)
            {
                return NotFound();
            }
            await _gamesRepository.Update(Mapper.Map(game, oldGame));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(ObjectId id)
        {
            var oldGame = await _gamesRepository.GetOne(id);
            if (oldGame == null)
            {
                return NotFound();
            }
            await _gamesRepository.Remove(id);
            return NoContent();
        }
    }
}