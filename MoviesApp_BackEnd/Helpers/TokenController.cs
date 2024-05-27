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
            var key = Encoding.ASCII.GetBytes("Aca_va_la_clave_secreta_para_tu_JWT_que_puede_ser_creada_e_importada_como_variable_de_entorno");
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
