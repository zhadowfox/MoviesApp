using Microsoft.AspNetCore.Mvc;
using MoviesApp_BackEnd.Context;
using MoviesApp_BackEnd.Interfaces;
using MoviesApp_BackEnd.Models;
using MoviesApp_BackEnd.Helpers;



namespace MoviesApp_BackEnd.Strategies
{


    public class SignUpUserStrategy : IUserStrategies
    {
        public async Task<IActionResult> Execute(DbMoviesAppContext _dbcontext, Users userObj)
        {

            if (await EmailChecker.CheckIfEmailExist(_dbcontext, userObj.Email))
                return new BadRequestObjectResult(new { message = "El correo ya esta en uso" });




            if (userObj == null)
                return new NotFoundObjectResult(new { message = "Error al crear el usuario, faltan datos" });

            userObj.Password = PasswordHashing.HashPassword(userObj.Password);
            await _dbcontext.Users.AddAsync(userObj);
            await _dbcontext.SaveChangesAsync();
            return new OkObjectResult(new { message = "Usuario Registrado con exito" });




        }


    }
}
