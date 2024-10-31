﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MovieOrganizer.Models.Domain
{
    public class User : IdentityUser<int>
    {
        //public User(string userName) : base(userName)
        //{
        //}

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public ICollection<MovieLog> MovieLogs { get; set; } = new List<MovieLog>();
        
        //public ICollection<Movie> Movies {  get; set; } = new List<Movie>();

        //public User()
        //{
        //    MovieLogs = new List<MovieLog>();
        //    Movies = new List<Movie>();
        //}
    }
}
