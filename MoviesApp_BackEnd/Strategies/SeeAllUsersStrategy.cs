using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApp_BackEnd.Context;
using MoviesApp_BackEnd.Interfaces;
using MoviesApp_BackEnd.Models;

namespace MoviesApp_BackEnd.Strategies
{
    public class SeeAllUsersStrategy : IAdminStrategies
    {
        public async Task<IActionResult> Execute(DbMoviesAppContext _dbContext, long id = 0)
        {
            List<UsersPublicInfo> usersList = await _dbContext.Users.Select(x => new UsersPublicInfo {
                Id = x.Id,
                Names = x.Names,
                LastNames = x.LastNames,
                Email = x.Email,
                IdRol =x.IdRol

            }).ToListAsync();
            return new OkObjectResult(new {  listOfUsers = await _dbContext.Users.ToListAsync() , message = "Ok, lista de todos los usuarios" });

        }
    }
}
