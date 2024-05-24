using MoviesApp_BackEnd.Models;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;

namespace MoviesApp_BackEnd.Helpers
{
    public class TokenController
    {
        public static string CreateJWT(Users user)

        {
            string Rol = "Cliente";
            if (user.IdRol == 1)
                Rol = "Admin";

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("movies_secret_d...........................................dsadasda....");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role,Rol),
                new Claim ("names",user.Names.ToString()),
                new Claim ("lastnames",user.Names.ToString()),
                new Claim("Email", user.Email),
                new Claim("UserId", user.Id.ToString()),
                new Claim("IdRol", user.IdRol.ToString())
            });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            return jwtTokenHandler.WriteToken(token);
        }
    }
}
