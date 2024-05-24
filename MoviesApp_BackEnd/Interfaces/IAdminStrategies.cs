

using Microsoft.AspNetCore.Mvc;
using MoviesApp_BackEnd.Context;
using MoviesApp_BackEnd.Models;


namespace MoviesApp_BackEnd.Interfaces
{
    public interface IAdminStrategies
    {
        Task<IActionResult> Execute(DbMoviesAppContext context, long idUser = 0);

    }
}

