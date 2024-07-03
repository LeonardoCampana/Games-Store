using Microsoft.AspNetCore.Mvc;

namespace GamesStore.Controllers
{
    public class AutenticationController : Controller
    {
        public IActionResult Login()
        {
            return View("~/Views/Autentication/Login.cshtml");
        }

        public IActionResult Register()
        {
            return View("~/Views/Autentication/Register.cshtml");
        }
    }
}
