using GamesStore.Interfaces;
using GamesStore.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
