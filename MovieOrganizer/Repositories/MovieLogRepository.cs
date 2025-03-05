using Microsoft.EntityFrameworkCore;
using MovieOrganizer.Data;
using MovieOrganizer.Models.Domain;

namespace MovieOrganizer.Repositories
{
    public class MovieLogRepository : IMovieLogRepository
    {
        private readonly MovieDBContext movieDBContext;
        public MovieLogRepository(MovieDBContext movieDBContext)
        {
            this.movieDBContext = movieDBContext;
        }
        public async Task<MovieLog?> CreateAsync(MovieLog movieLog)
        {
            await movieDBContext.MovieLogs.AddAsync(movieLog);
            await movieDBContext.SaveChangesAsync();
            return movieLog;
        }

        public async Task<IEnumerable<MovieLog>> GetAllAsync()
        {
            return await movieDBContext.MovieLogs.ToListAsync();
        }

        public async Task<MovieLog?> UpdateAsync(MovieLog movieLog)
        {
            var existingMovieLog = await movieDBContext.MovieLogs.Include(x => x.Title).FirstOrDefaultAsync(x => x.Title == movieLog.Title);

            //if (existingMovieLog != null)
            //{
            //    existingMovieLog.MovieId = movieLog.MovieId;
            //    existingBlog.Author = blogPost.Author;
            //    existingBlog.PageTitle = blogPost.PageTitle;
            //    existingBlog.Content = blogPost.Content;
            //    existingBlog.ShortDescription = blogPost.ShortDescription;
            //    existingBlog.FeaturedImageUrl = blogPost.FeaturedImageUrl;
            //    existingBlog.UrlHandle = blogPost.UrlHandle;
            //    existingBlog.Visible = blogPost.Visible;
            //    existingBlog.PublishedDate = blogPost.PublishedDate;
            //    existingBlog.Tags = blogPost.Tags;
            //    existingBlog.Heading = blogPost.Heading;

            //    await movieDBContext.SaveChangesAsync();
            //    return existingBlog;
            //}
            return null;
        }

        public async Task<MovieLog?> DeleteAsync(Guid id)
        {
            var existingBlogPost = await movieDBContext.MovieLogs.FindAsync(id);

            if (existingBlogPost != null)
            {
                movieDBContext.MovieLogs.Remove(existingBlogPost);
                await movieDBContext.SaveChangesAsync();

                return existingBlogPost;
            }
            return null;
        }

        public Task<MovieLog?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
