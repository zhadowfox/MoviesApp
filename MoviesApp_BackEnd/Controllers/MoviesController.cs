using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApp_BackEnd.Context;
using MoviesApp_BackEnd.Models;
using System.Net.Http;

namespace MoviesApp_BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        [HttpPost("addToFav")]
        public async Task<IActionResult> AddToFav(DbMoviesAppContext _dbcontext, UsersFavoriteMovies movie)

        {
            Console.WriteLine(movie);
            Console.WriteLine(movie.UserId);

            await _dbcontext.UsersFavoriteMovies.AddAsync(movie);
            await _dbcontext.SaveChangesAsync();
            return Ok(new { message=movie.Id});
        }
    }
}
