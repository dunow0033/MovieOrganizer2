using MovieOrganizer.Models.Domain;

namespace MovieOrganizer.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie?> CreateAsync(Movie movie);
        Task<Movie?> GetAsync(int id);
        Task<IEnumerable<Movie>> GetAllAsync();
    }
}
