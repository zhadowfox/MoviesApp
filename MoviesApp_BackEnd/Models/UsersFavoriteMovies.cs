using System.ComponentModel.DataAnnotations;

namespace MoviesApp_BackEnd.Models
{
    public class UsersFavoriteMovies
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}
