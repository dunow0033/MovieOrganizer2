using Microsoft.AspNetCore.Mvc;
using MovieOrganizer.Repositories;

namespace MovieOrganizer.Controllers
{
    public class MovieLogsController : Controller
    {
        private readonly IMovieLogRepository movieLogRepository;
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
    }
}
