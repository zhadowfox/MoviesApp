
using BCrypt.Net;

namespace MoviesApp_BackEnd.Helpers
{
    public class PasswordHashing
    {

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool ValidatePassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }


    }
}
