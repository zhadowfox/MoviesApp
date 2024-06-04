using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApp_BackEnd.Context;
using MoviesApp_BackEnd.Interfaces;
using MoviesApp_BackEnd.Models;

namespace MoviesApp_BackEnd.Strategies
{
    public class AddToFavStrategy : IMoviesStrategies<UsersFavoriteMovies>
    {
        public async Task<IActionResult> Execute(DbMoviesAppContext _dbcontext, UsersFavoriteMovies movie)

        {
          

            bool movieFinded = await _dbcontext.UsersFavoriteMovies.AnyAsync(x => x.UserId == movie.UserId && x.MovieId == movie.MovieId);
            if(!movieFinded)
            {
                await _dbcontext.UsersFavoriteMovies.AddAsync(movie);
                await _dbcontext.SaveChangesAsync();
                return new OkObjectResult(new {state=1, message = "Agregada a favoritos con exito" });
            }
            return new OkObjectResult(new { state=0,message = "Ya hace parte de su lista de favoritos" });


        }
    }
}
