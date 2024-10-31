using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MovieOrganizer.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace MovieOrganizer.Data
{
    public class MovieDBContext : IdentityDbContext<User, IdentityRole<int>, int>
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
                .HasOne(ml => ml.User)
                .WithMany(u => u.MovieLogs)
                .HasForeignKey(ml => ml.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<MovieLog>()
            //    .HasKey(ml => new { ml.Title, ml.User });

            //modelBuilder.Entity<MovieLog>()
            //    .HasOne(ml => ml.User)
            //    .WithMany(m => m.MovieLogs)
            //    .HasForeignKey(m => m.UserId);

            //modelBuilder.Entity<MovieLog>()
            //    .HasOne(ml => ml.User)
            //    .WithMany(u => u.MovieLogs)
            //    .HasForeignKey(m => m.UserId);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
      

        modelBuilder.Entity<Movie>()
               .HasData(new List<Movie>()
               {
                   new()
                    {
                        Id = 1,
                        Title = "The Matrix",
                        Category = "Action",
                        Rating = "R"
                    },
                   new()
                    {
                        Id = 2,
                        Title = "The Rock",
                        Category = "Action",
                        Rating = "R"
                    },
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

            modelBuilder.Entity<MovieLog>()
               .HasData(new List<MovieLog>()
               {
                    new()
                    {
                        Id = 1,
                        UserId = 2,
                        MovieId = 4,
                        Title = "Gladiator",
                        Comments = "Great Action"
                    },
                    new()
                    {
                        Id = 2,
                        UserId = 2,
                        MovieId = 2,
                        Title = "The Rock",
                        Comments = "Sean Connery was great"
                    },
                    new()
                    {
                        Id = 3,
                        UserId = 2,
                        MovieId = 1,
                        Title = "The Matrix",
                        Comments = "Great Special Effects"
                    },
                    new()
                    {
                        Id = 4,
                        UserId = 2,
                        MovieId = 6,
                        Title = "Beetlejuice",
                        Comments = "Michael Keaton was hilarious"
                    },
                    new()
                    {
                        Id = 5,
                        UserId = 3,
                        MovieId = 7,
                        Title = "Ghostbusters",
                        Comments = "Great comedy and special effects"
                    }
               });

            var hasher = new PasswordHasher<User>();

            modelBuilder.Entity<User>()
               .HasData(new List<User>()
               {
                   new()
                    {
                        Id = 1,
                        Name = "Chris",
                        Email ="chris@gmail.com",
                        PasswordHash = hasher.HashPassword(null, "56gtYH123dftg")
                    },
                    new()
                    {
                        Id = 2,
                        Name = "Dan",
                        Email ="dan@gmail.com",
                        PasswordHash = hasher.HashPassword(null, "kjiTH67dfWDs23")
                    },
                    new()
                    {
                        Id = 3,
                        Name = "Tom",
                        Email ="tom@gmail.com",
                        PasswordHash = hasher.HashPassword(null, "5kjiki87ghHY67")
                    }
               });
        }
    }
}
