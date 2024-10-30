using System.ComponentModel.DataAnnotations;

namespace MovieOrganizer.Models.Domain
{
    public class MovieLog
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int MovieId { get; set; }
        public string Title { get; set; }

        [Required(ErrorMessage = "Comments are required")]
        public string Comments { get; set; }

        //public string Name
        //{
        //    get
        //    {
        //        return $"{User.Name}'s comment on {Movie.Title}";
        //    }
        //}
    }
}
