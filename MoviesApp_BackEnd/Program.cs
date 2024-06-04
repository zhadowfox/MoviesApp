using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MoviesApp_BackEnd.Context;
using System.Text;
using System;
using MoviesApp_BackEnd.Interfaces;
using MoviesApp_BackEnd.Strategies;
using MoviesApp_BackEnd.Controllers;
using MoviesApp_BackEnd.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option =>
{
    option.AddPolicy("PoliciesForMoviesApp", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddScoped<IMoviesStrategies<long>, MyFavMoviesStrategy>();
builder.Services.AddScoped<IMoviesStrategies<UsersFavoriteMovies>, AddToFavStrategy>();
builder.Services.AddScoped<IMoviesStrategies<long>, DeleteFromFavStrategy>();
builder.Services.AddDbContext<DbMoviesAppContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnStr"));
});
builder.Services.AddAuthentication(x =>
{ 
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Aca_va_la_clave_secreta_para_tu_JWT_que_puede_ser_creada_e_importada_como_variable_de_entorno")),
        ValidateAudience = false,
        ValidateIssuer = false
    };
});




var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("PoliciesForMoviesApp");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
