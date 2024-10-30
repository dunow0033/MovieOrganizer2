using Microsoft.AspNetCore.Mvc;
using MovieOrganizer.Models.Domain;
using MovieOrganizer.Models.ViewModels;
using MovieOrganizer.Repositories;
using System.ComponentModel.DataAnnotations;

namespace MovieOrganizer.Controllers
{
    public class MovieLogsController : Controller
    {
        private readonly IMovieLogRepository movieLogRepository;

        public MovieLogsController(IMovieLogRepository movieLogRepository)
        {
            this.movieLogRepository = movieLogRepository;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await movieLogRepository.GetAllAsync();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
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
