using System.ComponentModel.DataAnnotations;

namespace MovieOrganizer.Models.Domain
{
    public class MovieLog
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        [Required(ErrorMessage = "Comments are required")]
        public string Comments { get; set; }

        public string Name
        {
            get
            {
                return $"{User.Name}'s comment on {Movie.Title}";
            }
        }
    }
}
