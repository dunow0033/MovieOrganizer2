using MovieOrganizer.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace MovieOrganizer.Models.ViewModels
{
    public class EditMovieLogRequest
    {
		public Guid Id { get; set; }

		public Guid UserId { get; set; }
        public User User { get; set; }

		public Guid MovieId { get; set; }
		public string Title { get; set; }

		[Required(ErrorMessage = "Comments are required")]
		public string Comments { get; set; }

		//public Guid Id { get; set; }
		//public Guid UserId { get; set; }
		//public User User { get; set; }

		//public Guid MovieId { get; set; }
		//public string Title { get; set; }

		//[Required(ErrorMessage = "Comments are required")]
		//public string Comments { get; set; }
	}
}
