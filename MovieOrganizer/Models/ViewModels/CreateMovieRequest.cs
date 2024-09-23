using System.ComponentModel.DataAnnotations;

namespace MovieOrganizer.Models.ViewModels
{
    public class CreateMovieRequest
    {
        public string Title { get; set; }

        public string Category { get; set; }

        public string Rating { get; set; }
    }
}
