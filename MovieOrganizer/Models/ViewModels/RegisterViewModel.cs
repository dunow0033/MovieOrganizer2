using System.ComponentModel.DataAnnotations;

namespace MovieOrganizer.Models.ViewModels
{
	public class RegisterViewModel
	{
		[Required]
		public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

		[Required]
		[MinLength(6, ErrorMessage = "Password has to be at least 6 characters")]
		public string Password { get; set; }
	}
}
