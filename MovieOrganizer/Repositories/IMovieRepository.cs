using MovieOrganizer.Models.Domain;

namespace MovieOrganizer.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie?> CreateAsync(Movie movie);
        Task<IEnumerable<Movie>> GetAllAsync();
    }
}
