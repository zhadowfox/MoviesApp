using System.ComponentModel.DataAnnotations;

namespace MoviesApp_BackEnd.Models
{
    public class MovieStarsRating
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int Stars {  get; set; }
    }
}
