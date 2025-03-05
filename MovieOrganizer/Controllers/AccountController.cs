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
            //Console.WriteLine($"Username: {registerViewModel.UserName}");
            //Console.WriteLine($"Email: {registerViewModel.Email}");
            //Console.WriteLine($"Password: {registerViewModel.Password}");

            if (ModelState.IsValid)
			{
				var user = new User
				{
					UserName = registerViewModel.UserName,
					Email = registerViewModel.Email,
                };

				//Console.WriteLine($"UserName: {user.UserName}");
				//Console.WriteLine($"Email: {user.Email}");
				//Console.WriteLine($"Password: {registerViewModel.Password}");

				var identityResult = await userManager.CreateAsync(user, registerViewModel.Password);

				if (identityResult.Succeeded)
				{
					//return RedirectToAction("Register");
					await signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction("Index", "Movies");
				}
				else
				{
					foreach (var error in identityResult.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}
            }

			//if (identityResult.Succeeded)
			//{
			//	var roleIdentityResult = await userManager.AddToRoleAsync(user, "User");

			//	if (roleIdentityResult.Succeeded)
			//	{
			//		//return RedirectToAction("Register");
			//		await signInManager.SignInAsync(user, isPersistent: false);

			//		return RedirectToAction("Index", "Movies");
			//	}
			//}
			//else
			//{
			//	foreach (var error in identityResult.Errors)
			//	{
			//		ModelState.AddModelError(string.Empty, error.Description);
			//	}
			//}

			return View(registerViewModel);
		}

		[HttpGet]
		public IActionResult Login()
        {
            var model = new LoginViewModel
            {
               
            };

            return View(model);
        }


		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(loginViewModel);
			}

            var user = await userManager.FindByNameAsync(loginViewModel.UserName);

            if (user == null)
            {
                // User not found
                ModelState.AddModelError(string.Empty, "Invalid username.");
                return View(loginViewModel);
            }

            var signInResult = await signInManager.PasswordSignInAsync(loginViewModel.UserName,
				loginViewModel.Password, false, false);

			if (signInResult != null && signInResult.Succeeded)
			{
				//if (!string.IsNullOrWhiteSpace(loginViewModel.ReturnUrl))
				//{
				//	return Redirect(loginViewModel.ReturnUrl);
				//}

				return RedirectToAction("Index", "Movies");
			}

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "User account locked out.");
            }
            else if (signInResult.IsNotAllowed)
            {
                ModelState.AddModelError(string.Empty, "User account not allowed.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid password.");
            }

			return View(loginViewModel);
		}

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
