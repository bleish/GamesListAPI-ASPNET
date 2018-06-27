using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GamesListAPI.Models;
using GamesListAPI.Repository;
using GamesListAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace GamesListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IMapper _mapper;

        public GamesController(IGamesRepository gamesRepository, IMapper mapper)
        {
            _gamesRepository = gamesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var games = await _gamesRepository.GetMany();
            return Ok(games);
        }

        [HttpGet("{id}", Name = "GetGame")]
        public async Task<ActionResult> Get(string id)
        {
            var game = await _gamesRepository.GetOne(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult> Create(GameDTO game)
        {
            var newGame = await _gamesRepository.Add(_mapper.Map<Game>(game));
            return CreatedAtRoute("GetGame", new { id = newGame.Id }, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, GameDTO gameDTO)
        {
            var game = await _gamesRepository.GetOne(id);
            if (game == null)
            {
                return NotFound();
            }
            await _gamesRepository.Update(_mapper.Map(gameDTO, game));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
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