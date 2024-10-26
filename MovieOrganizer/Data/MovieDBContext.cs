using Microsoft.EntityFrameworkCore;
using MovieOrganizer.Models.Domain;
using System.ComponentModel.DataAnnotations;

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

            modelBuilder.Entity<MovieLog>()
                .HasOne(ml => ml.Movie)
                .WithMany(m => m.MovieLogs)
                .HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<MovieLog>()
                .HasOne(ml => ml.User)
                .WithMany(u => u.MovieLogs)
                .HasForeignKey(m => m.UserId);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
               .HasData(new List<Movie>()
               {
                    new()
                    {
                        Id = 3,
                        Title = "The Terminator",
                        Category = "Action",
                        Rating = "R"
                    },
                    new()
                    {
                        Id = 4,
                        Title = "Gladiator",
                        Category = "Action",
                        Rating = "R"
                    },
                    new()
                    {
                        Id = 5,
                        Title = "The Departed",
                        Category = "Action",
                        Rating = "R"
                    },
                    new()
                    {
                        Id = 6,
                        Title = "Beetlejuice",
                        Category = "Comedy",
                        Rating = "PG"
                    },
                    new()
                    {
                        Id = 7,
                        Title = "Ghostbusters",
                        Category = "Comedy",
                        Rating = "PG"
                    }
               });

        }
    }
}
