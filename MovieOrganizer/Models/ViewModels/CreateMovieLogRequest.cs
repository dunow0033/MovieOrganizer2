using MovieOrganizer.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace MovieOrganizer.Models.ViewModels
{
    public class CreateMovieLogRequest
    {
		[Required]
		public User User { get; set; }

		[Required]
		public Guid MovieId { get; set; }

		[Required]
		public string Comments { get; set; }
	}
}
