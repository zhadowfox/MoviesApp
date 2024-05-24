using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApp_BackEnd.Context;
using MoviesApp_BackEnd.Interfaces;
using MoviesApp_BackEnd.Models;

namespace MoviesApp_BackEnd.Strategies
{
    public class SeeAnUserStrategy : IAdminStrategies
    {
        public async Task<IActionResult> Execute(DbMoviesAppContext _dbMovieContext, long id)

        {
            UsersPublicInfo userFinded = await _dbMovieContext.Users.Where(x=> x.Id == id).Select(x=> new UsersPublicInfo {
                Id=x.Id,
                Names= x.Names,
                LastNames=x.LastNames,
                Email=x.Email,
                IdRol = x.IdRol
            }).FirstOrDefaultAsync();

            if (userFinded == null)
                return new OkObjectResult(new { message = "Usuario no encontrado" });

            return new OkObjectResult(new {userInfo= userFinded, message="Usuario encontrado" });

        }
    }
}
