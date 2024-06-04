using System.ComponentModel.DataAnnotations;

namespace MoviesApp_BackEnd.Models
{
    public class UsersFavoriteMovies
    {
        [Key]
        public long Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}
