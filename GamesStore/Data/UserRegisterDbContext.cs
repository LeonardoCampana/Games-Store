using GamesStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesStore.Data
{
    public class UserRegisterDbContext : DbContext
    {
        public UserRegisterDbContext(DbContextOptions<UserRegisterDbContext> options) : base(options) 
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
