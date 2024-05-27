using System.ComponentModel.DataAnnotations;

namespace MoviesApp_BackEnd.Models
{
    public class UsersRoles
    {
        [Key]
        public int Id { get; set; }
        public string RolName { get; set; }
        public string Description { get; set; }
    }
}
