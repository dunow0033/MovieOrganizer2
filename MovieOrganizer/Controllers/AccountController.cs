using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieOrganizer.Models.ViewModels;

namespace MovieOrganizer.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        //{
        //    var identityUser = new IdentityUser
        //    {
        //        UserName = registerViewModel.Username,
        //        Email = registerViewModel.Email
        //    };

        //    var identityResult = await User.CreateAsync
        //}
    }
}
