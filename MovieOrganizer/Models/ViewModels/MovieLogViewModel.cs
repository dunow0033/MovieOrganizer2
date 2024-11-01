using MovieOrganizer.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace MovieOrganizer.Models.ViewModels
{
    public class MovieLogViewModel
    {
        public User User { get; set; }
        public Guid MovieId { get; set; }

        [Required]
        public string Comments { get; set; }
        //public string DisplayName => $"{User}'s comment on {Title}:";
    }
}
