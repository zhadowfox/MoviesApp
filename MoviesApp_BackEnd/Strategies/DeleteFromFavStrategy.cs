using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApp_BackEnd.Context;
using MoviesApp_BackEnd.Interfaces;
using MoviesApp_BackEnd.Models;

namespace MoviesApp_BackEnd.Strategies
{
    public class DeleteFromFavStrategy:IMoviesStrategies<long>
    {
        public async Task<IActionResult> Execute(DbMoviesAppContext _dbcontext, long id)

        {
  

            
            UsersFavoriteMovies favoriteMovie = await _dbcontext.UsersFavoriteMovies.FindAsync(id);
            if (favoriteMovie == null)
            {
                return new NotFoundObjectResult(new { state = 0, message = "Entrada no encontrada" });
            }

            _dbcontext.UsersFavoriteMovies.Remove(favoriteMovie);
            await _dbcontext.SaveChangesAsync();

            return new OkObjectResult(new { state = 1, message = "Pelicula eliminada de tus favoritos" });


        }
    }
}
