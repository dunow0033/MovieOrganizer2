using Microsoft.EntityFrameworkCore;
using MovieOrganizer.Models.Domain;

namespace MovieOrganizer.Data
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<MovieLog> MovieLogs { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieLog>()
                .HasKey(ml => new { ml.MovieId, ml.UserId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
