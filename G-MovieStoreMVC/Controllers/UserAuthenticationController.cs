using G_MovieStoreMVC.Models.DTO;
using G_MovieStoreMVC.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace G_MovieStoreMVC.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService authService;

        public UserAuthenticationController(IUserAuthenticationService authService)
        {
            this.authService = authService;
        }

        // GET: Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await authService.RegisterAsync(model);
            if (result.StatusCode == 1)
            {
                TempData["msg"] = "Registration successful!";
                return RedirectToAction(nameof(Login)); // Redirect to the Login page after successful registration
            }
            else
            {
                TempData["msg"] = result.Message;
                return View(model);
            }
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await authService.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Index", "Home"); // Redirect to Home page after successful login
            }
            else
            {
                TempData["msg"] = result.Message; // Display the error message
                return View(model); // Stay on the login page
            }
        }

        // GET: Logout
        public async Task<IActionResult> Logout()
        {
            await authService.LogoutAsync();
            return RedirectToAction(nameof(Login)); // Redirect to Login page after logout
        }
    }
}
