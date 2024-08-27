using GamesStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesStore.Data
{
    public class ProductRegisterDbContext : DbContext
    {
        public ProductRegisterDbContext(DbContextOptions<ProductRegisterDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
    }
}
