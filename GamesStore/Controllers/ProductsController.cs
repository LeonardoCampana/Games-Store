using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using GamesStore.Models;
using GamesStore.Data;

public class ProductsController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly ProductRegisterDbContext _context;

    public ProductsController(ProductRegisterDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        if (ModelState.IsValid)
        {
            if (product.ImageFile != null)
            {
                // Crie o caminho para salvar o arquivo
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                Directory.CreateDirectory(uploadsFolder);
                string fileName = Path.GetFileName(product.ImageFile.FileName);
                string filePath = Path.Combine(uploadsFolder, fileName);

                // Salve o arquivo
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(stream);
                }

                // Defina o caminho da imagem no banco de dados
                product.PathImage = $"/images/{fileName}";
            }

            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(product);
    }
}
