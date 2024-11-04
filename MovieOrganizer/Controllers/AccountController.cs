using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieOrganizer.Models.ViewModels;
using MovieOrganizer.Models.Domain;

namespace MovieOrganizer.Controllers
{
    public class AccountController : Controller
    {
		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;

		public AccountController(UserManager<User> userManager,
			SignInManager<User> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		[HttpGet]
        public IActionResult Register()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
		{
			var user = new User
			{
				UserName = registerViewModel.Username,
				Email = registerViewModel.Email
			};

			var identityResult = await userManager.CreateAsync(user, registerViewModel.Password);

			if (identityResult.Succeeded)
			{
				var roleIdentityResult = await userManager.AddToRoleAsync(user, "User");

				if (roleIdentityResult.Succeeded)
				{
					//return RedirectToAction("Register");
					await signInManager.SignInAsync(user, isPersistent: false);

					return RedirectToAction("Index", "Movies");
				}
			}
			else
			{
				foreach (var error in identityResult.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}

			return View(registerViewModel);
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			var signInResult = await signInManager.PasswordSignInAsync(loginViewModel.Username,
				loginViewModel.Password, false, false);

			if (signInResult != null && signInResult.Succeeded)
			{
				//if (!string.IsNullOrWhiteSpace(loginViewModel.ReturnUrl))
				//{
				//	return Redirect(loginViewModel.ReturnUrl);
				//}

				return RedirectToAction("Index", "Movies");
			}

			ModelState.AddModelError(string.Empty, "Invalid username or password.");

			return View();
		}
	}
}
