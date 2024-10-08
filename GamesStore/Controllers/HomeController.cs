// HomeController.cs
using GamesStore.Data;
using GamesStore.Models;
using GamesStore.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GamesStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductRegisterDbContext _context;

        public HomeController(ILogger<HomeController> logger, ProductRegisterDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Home()
        {
            var products = await _context.Product.ToListAsync();
            return View("~/Views/Home/Index.cshtml", products);
        }

        public IActionResult Privacy()
        {
            return View("~/Views/Home/Privacy.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}