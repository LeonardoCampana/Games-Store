using Microsoft.AspNetCore.Mvc;

namespace GamesStore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Autentication/Login.cshtml");
        }
    }
}
