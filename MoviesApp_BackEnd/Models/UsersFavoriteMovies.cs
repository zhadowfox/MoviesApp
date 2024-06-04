using System.ComponentModel.DataAnnotations;

namespace MoviesApp_BackEnd.Models
{
    public class UsersFavoriteMovies
    {
        [Key]
        public long Id { get; set; }
        public long UserId { get; set; }
        public long MovieId { get; set; }
    }
}
