using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApp_BackEnd.Context;
using MoviesApp_BackEnd.Interfaces;
using MoviesApp_BackEnd.Models;

namespace MoviesApp_BackEnd.Strategies
{
    public class MyFavMoviesStrategy :IMoviesStrategies<long>
    {
        public async Task<IActionResult> Execute(DbMoviesAppContext _dbcontext,  long UserId)

        {


            List<UsersFavoriteMovies> FavoriteMoviesOfUser = await _dbcontext.UsersFavoriteMovies.Where(x => x.UserId == UserId).ToListAsync();
            if (FavoriteMoviesOfUser.Count > 0)
            {
                return new OkObjectResult(new { state = 1, listOfFavoriteMovies = FavoriteMoviesOfUser });
            }
 
                

            return new OkObjectResult(new { state = 0, message = "Ups, parece que no tienes ninguna pelicula marcada como favorita" });


        }
    }
}
