using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieOrganizer.Models.Domain;
using MovieOrganizer.Models.ViewModels;
using MovieOrganizer.Repositories;
using System.ComponentModel.DataAnnotations;

namespace MovieOrganizer.Controllers
{
    public class MovieLogsController : Controller
    {
        private readonly IMovieLogRepository movieLogRepository;
        private readonly IMovieRepository movieRepository;
        private readonly UserManager<User> userManager;

        public MovieLogsController(
            IMovieLogRepository movieLogRepository, 
            IMovieRepository movieRepository,
            UserManager<User> userManager)
        {
            this.movieLogRepository = movieLogRepository;
            this.movieRepository = movieRepository;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await movieLogRepository.GetAllAsync();
            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var movies = await movieRepository.GetAllAsync();
            ViewBag.MovieList = movies.Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Title,
            }).ToList();

            ViewData["Errors"] = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieLogViewModel movieLogViewModel)
        {
            var selectedMovie = await movieRepository.GetByIdAsync(movieLogViewModel.MovieId);
            var existingUser = await userManager.FindByIdAsync(2.ToString());

            var movieLog = new MovieLog
            {
                //User = movieLogViewModel.User,
                User = existingUser,
                //UserId = movieLogViewModel.User.Id,
                UserId = existingUser.Id,
                Title = selectedMovie.Title,
                MovieId = movieLogViewModel.MovieId,
                Comments = movieLogViewModel.Comments,
            };

            await movieLogRepository.CreateAsync(movieLog);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid movieId)
        {
            var existingMovie = await movieRepository.GetByIdAsync(movieId);
            if (existingMovie == null)
            {
                return NotFound();
            }

            ViewData["Title"] = $"Update {existingMovie.Title} Log";
            return View(existingMovie);
        }
    }
}
