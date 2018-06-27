using AutoMapper;
using GamesListAPI.Models;
using GamesListAPI_ASPNET.DTOs;

namespace GamesListAPI_ASPNET.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<GameDTO, Game>();
        }
    }
}