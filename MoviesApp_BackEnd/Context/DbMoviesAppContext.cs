using Microsoft.EntityFrameworkCore;
using MoviesApp_BackEnd.Models;

namespace MoviesApp_BackEnd.Context
{
    public class DbMoviesAppContext :DbContext
    {
        public DbMoviesAppContext(DbContextOptions<DbMoviesAppContext> options):base(options)
        {

                
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<MovieStarsRating> MovieStarsRatings { get; set; }
        public DbSet<UsersFavoriteMovies> UsersFavoriteMovies { get; set; }
        public DbSet<UsersRoles> UsersRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("users");
            modelBuilder.Entity<MovieStarsRating>().ToTable("MovieStarsRatings");
            modelBuilder.Entity<UsersFavoriteMovies>().ToTable("UsersFavoriteMovies");
            modelBuilder.Entity<UsersRoles>().ToTable("UsersRoles");
            
        }
    }
}
