using GamesStore.Interfaces;
using GamesStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GamesStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddUserAsync(user);
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (await _userService.ValidateUser(email, password))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email ou senha inválidos.");
                return View("~/Views/Autentication/Login.cshtml");
            }
        }
    }
}
