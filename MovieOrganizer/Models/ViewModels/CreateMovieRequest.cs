using System.ComponentModel.DataAnnotations;

namespace MovieOrganizer.Models.ViewModels
{
    public class CreateMovieRequest
    {
        //public Guid Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Rating { get; set; }
    }
}
