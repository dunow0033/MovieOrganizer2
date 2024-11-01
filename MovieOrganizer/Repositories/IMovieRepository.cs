using MovieOrganizer.Models.Domain;

namespace MovieOrganizer.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie?> CreateAsync(Movie movie);
        Task<Movie?> GetByIdAsync(Guid id);
        Task<IEnumerable<Movie>> GetAllAsync();
    }
}
