using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApp_BackEnd.Context;
using MoviesApp_BackEnd.Models;
using MoviesApp_BackEnd.Helpers;
using MoviesApp_BackEnd.Strategies;
using MoviesApp_BackEnd.Interfaces;



namespace MoviesApp_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DbMoviesAppContext _dbMoviesAppContext;
        public UserController(DbMoviesAppContext dbMoviesAppContext)
        {
            _dbMoviesAppContext = dbMoviesAppContext;

        }


        private async Task<IActionResult> ExecuteStrategy(IUserStrategies strategy, Users userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }

            return await strategy.Execute(_dbMoviesAppContext, userObj);
        }


        [HttpPost("authenticate")]

        public async Task<IActionResult> AuthenticateUser([FromBody] Users userObj)
        {
            return await ExecuteStrategy(new AuthenticateUserStrategy(), userObj);
        }


       
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] Users userObj)
        {
            return await ExecuteStrategy(new SignUpUserStrategy(), userObj);

        }

    }
}
