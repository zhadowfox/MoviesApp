using Microsoft.AspNetCore.Mvc;
using MoviesApp_BackEnd.Context;
using MoviesApp_BackEnd.Models;

namespace MoviesApp_BackEnd.Interfaces
{
    public interface IMoviesStrategies<T>
    {
        Task<IActionResult> Execute(DbMoviesAppContext context, T parameter);
        
        

    }
}
