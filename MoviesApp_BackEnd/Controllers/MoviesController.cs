using Microsoft.AspNetCore.Mvc;
using MoviesApp_BackEnd.Context;
using MoviesApp_BackEnd.Interfaces;
using MoviesApp_BackEnd.Models;
using System.Threading.Tasks;

namespace MoviesApp_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesStrategies<long> _moviesStrategyByUserId;
        private readonly IMoviesStrategies<UsersFavoriteMovies> _moviesStrategyByMovie;
        private readonly IMoviesStrategies<long> _deleteFavoriteMovieStrategy;
        private readonly DbMoviesAppContext _dbcontext;

        public MoviesController(
            IMoviesStrategies<long> moviesStrategyByUserId,
            IMoviesStrategies<UsersFavoriteMovies> moviesStrategyByMovie,
            IMoviesStrategies<long> deleteFavoriteMovieStrategy,
            DbMoviesAppContext dbcontext)
        {
            _moviesStrategyByUserId = moviesStrategyByUserId;
            _moviesStrategyByMovie = moviesStrategyByMovie;
            _deleteFavoriteMovieStrategy = deleteFavoriteMovieStrategy;
            _dbcontext = dbcontext;
        }

        [HttpGet("GetFavoriteMovies")]
        public async Task<IActionResult> GetFavoriteMovies(long userId)
        {
            return await ExecuteStrategy(userId);
        }

        [HttpPost("AddFavoriteMovie")]
        public async Task<IActionResult> AddFavoriteMovie(UsersFavoriteMovies movie)
        {
            return await ExecuteStrategy(movie);
        }

        [HttpDelete("DeleteFavoriteMovie")]
        public async Task<IActionResult> DeleteFavoriteMovie(long EntryId)
        {
            return await ExecuteStrategyForDeletion(EntryId);
        }

        private async Task<IActionResult> ExecuteStrategy<T>(T parameter)
        {
            if (parameter is long userId)
            {
                return await _moviesStrategyByUserId.Execute(_dbcontext, userId);
            }
            else if (parameter is UsersFavoriteMovies movie)
            {
                return await _moviesStrategyByMovie.Execute(_dbcontext, movie);
            }
            else
            {
                return new BadRequestObjectResult(new { state = 0, message = "Invalid parameter type" });
            }
        }

        private async Task<IActionResult> ExecuteStrategyForDeletion<T>(T parameter)
        {
            if (parameter is long EntryId)
            {
                return await _deleteFavoriteMovieStrategy.Execute(_dbcontext, EntryId);
            }
            else
            {
                return new BadRequestObjectResult(new { state = 0, message = "Invalid parameter type" });
            }
        }
    }
}
