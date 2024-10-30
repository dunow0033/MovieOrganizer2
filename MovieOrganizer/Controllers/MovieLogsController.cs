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
        public MovieLogsController(IMovieLogRepository movieLogRepository, IMovieRepository movieRepository)
        {
            this.movieLogRepository = movieLogRepository;
            this.movieRepository = movieRepository;
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
            var movieLog = new MovieLog
            {
                User = movieLogViewModel.User,
                Title = movieLogViewModel.Title,
                Comments = movieLogViewModel.Comments,
            };

            await movieLogRepository.CreateAsync(movieLog);

            return RedirectToAction("Index");
        }
    }
}
