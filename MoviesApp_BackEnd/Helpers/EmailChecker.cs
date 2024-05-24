using Microsoft.AspNetCore.Mvc;
using MoviesApp_BackEnd.Context;
using Microsoft.EntityFrameworkCore;

namespace MoviesApp_BackEnd.Helpers
{
    public class EmailChecker
    {
        public static Task<bool> CheckIfEmailExist(DbMoviesAppContext _dbcontext, string Email)
        {
            return _dbcontext.Users.AnyAsync(x => x.Email == Email);
        }
    }
}
