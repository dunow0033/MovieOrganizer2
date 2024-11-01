using Microsoft.AspNetCore.Mvc;
using MovieOrganizer.Models.Domain;
using MovieOrganizer.Models.ViewModels;
using MovieOrganizer.Repositories;

namespace MovieOrganizer.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
            
        }
        public async Task<IActionResult> Index()
        {
            var movies = await movieRepository.GetAllAsync();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieRequest createMovieRequest)
        {
            var movie = new Movie
            {
                Title = createMovieRequest.Title,
                Category = createMovieRequest.Category,
                Rating = createMovieRequest.Rating
            };

            await movieRepository.CreateAsync(movie);

            //return View
            return RedirectToAction("Index");
        }

        [HttpGet]
        //[ActionName("Details")]
        public async Task<IActionResult> Show(int movieId) 
        {
            var movie = await movieRepository.GetByIdAsync(movieId);

            if(movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
    }
}
