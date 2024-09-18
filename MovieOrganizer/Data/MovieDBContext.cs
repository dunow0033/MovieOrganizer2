using Microsoft.EntityFrameworkCore;
using MovieOrganizer.Models;

namespace MovieOrganizer.Data
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
