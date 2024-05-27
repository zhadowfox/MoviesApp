using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApp_BackEnd.Context;
using MoviesApp_BackEnd.Models;
using MoviesApp_BackEnd.Helpers;
using MoviesApp_BackEnd.Strategies;
using MoviesApp_BackEnd.Interfaces;
using Microsoft.AspNetCore.Authorization;
namespace MoviesApp_BackEnd.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController :ControllerBase
    {
        private readonly DbMoviesAppContext _dbMoviesAppContext;
        public AdminController(DbMoviesAppContext dbMoviesAppContext)
        {
            _dbMoviesAppContext = dbMoviesAppContext;
        }

        private async Task<IActionResult> ExecuteStrategy(IAdminStrategies strategy, long idUser=0)
        {
            return await strategy.Execute(_dbMoviesAppContext, idUser);
        }
        //[Authorize]
        [HttpGet("listofusers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return await ExecuteStrategy(new SeeAllUsersStrategy());
        }

        //[Authorize]

        [HttpGet("userinfo/{id}")]
        public async Task<IActionResult> GetAnUser(long id)
        {
            return await ExecuteStrategy(new SeeAnUserStrategy(), id);
        }

    }
}
