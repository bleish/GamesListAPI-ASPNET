using System.ComponentModel.DataAnnotations;

namespace GamesListAPI.DTOs
{
    public class GameDTO
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string System { get; set; }
        
        [Required]
        public int ReleaseDate { get; set; }
    }
}