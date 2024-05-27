using Microsoft.AspNetCore.Mvc;
using MoviesApp_BackEnd.Context;
using MoviesApp_BackEnd.Models;


namespace MoviesApp_BackEnd.Interfaces
{
    public interface IUserStrategies
    {
        Task<IActionResult> Execute(DbMoviesAppContext context, Users userObj);

    }
}
