using Azure;
using Microsoft.EntityFrameworkCore;
using MovieOrganizer.Data;
using MovieOrganizer.Models.Domain;

namespace MovieOrganizer.Repositories
{
    
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDBContext movieDBContext;

        public MovieRepository(MovieDBContext movieDBContext)
        {
            this.movieDBContext = movieDBContext;
        }

        public async Task<Movie?> GetAsync(int id)
        {
            return await movieDBContext.Movies
                .Include(m => m.MovieLogs)
                .ThenInclude(ml => ml.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await movieDBContext.Movies.ToListAsync();
        }

        public async Task<Movie?> CreateAsync(Movie movie)
        {
            await movieDBContext.Movies.AddAsync(movie);
            await movieDBContext.SaveChangesAsync();
            return movie;
        }
    }
}
