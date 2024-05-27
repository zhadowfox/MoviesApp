using System.ComponentModel.DataAnnotations;

namespace MoviesApp_BackEnd.Models
{
    public class UsersPublicInfo
    {
        [Key]
        public long Id { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string Email { get; set; }
        public int IdRol { get; set; }



    }
}
