using System.ComponentModel.DataAnnotations;

namespace MovieOrganizer.Models.ViewModels
{
    public class MovieViewModel
    {
        public string Title { get; set; }

        public string Category { get; set; }

        public string Rating { get; set; }
    }
}
