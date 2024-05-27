using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace MoviesApp_BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        [HttpGet("getmoviedata")]
        public async Task<IActionResult> GetMovies()
        {

            var clientn = new HttpClient();

            var response = await clientn.GetAsync("https://api.themoviedb.org/3/movie/550?api_key=85e18972fb774cd3a6c31b623a82b854");
            var json_respuesta = response.Content.ReadAsStringAsync();

            return Ok(json_respuesta);

        }
    }
}
