using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieOrganizer.Data;

namespace MovieOrganizer.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Rating { get; set; }

        public static Movie MostComments(MovieDBContext context)
        {
            return context.Movies
                .Select(m => new
                {
                    Id = m.Id,
                    Movie = m.Title,
                    MovieCount = m.MovieLogs.Count
                })
                .OrderByDescending(m => m.MovieCount)
                .FirstOrDefault()?.Movie;
        }

    }
}
