using MovieOrganizer.Models.Domain;

namespace MovieOrganizer.Repositories
{
    public interface IMovieLogRepository
    {
        Task<MovieLog?> CreateAsync(MovieLog movieLog);
        Task<MovieLog?> UpdateAsync(MovieLog movieLog);
        Task<MovieLog?> DeleteAsync(int id);
        Task<MovieLog?> GetAsync(int id);
        Task<IEnumerable<MovieLog>> GetAllAsync();
    }
}
