using Microsoft.AspNetCore.Mvc;

namespace GamesStore.Controllers
{
    public class PageProductsController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/ProductsAdd/Index.cshtml");
        }

    }
}
