using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace MoviesApp_BackEnd.Models
{

    public class Users
    {
        
        [Key]
        public long Id { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string Email { get; set; }
        
        public string Password { get; set; }
        public string Token { get; set; }

        private int _DefaultUserRol = 2;
        public int IdRol {
            get { return _DefaultUserRol; }
            set { _DefaultUserRol = value; }
        }
        
    }


}
