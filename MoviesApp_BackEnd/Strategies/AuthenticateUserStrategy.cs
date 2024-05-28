using Microsoft.AspNetCore.Mvc;
using MoviesApp_BackEnd.Context;
using MoviesApp_BackEnd.Interfaces;
using MoviesApp_BackEnd.Models;
using MoviesApp_BackEnd.Helpers;


using Microsoft.EntityFrameworkCore;


namespace MoviesApp_BackEnd.Strategies
{


    public class AuthenticateUserStrategy : IUserStrategies
    {

        public async Task<IActionResult> Execute(DbMoviesAppContext _dbcontext, Users userObj)
        {


            Users user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.Email == userObj.Email);



            if (user == null)
                return new NotFoundObjectResult(new { message = "*El usuario no existe o no ha sido registrado aun, revisa el nombre de usuario que estas ingresando" });
            if (!PasswordHashing.ValidatePassword(userObj.Password, user.Password))
                return new NotFoundObjectResult(new { message = "*La contraseña  es incorrecta, revisa que se haya escrito correctamente" });

            user.Token = TokenController.CreateJWT(user);





            return new OkObjectResult(new { token = user.Token, message = "El inicio de sesión ha sido exitoso"});


        }

   
    }
}
