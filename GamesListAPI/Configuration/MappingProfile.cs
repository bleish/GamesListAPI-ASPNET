using AutoMapper;
using GamesListAPI.Models;
using GamesListAPI.DTOs;

namespace GamesListAPI.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<GameDTO, Game>();
        }
    }
}