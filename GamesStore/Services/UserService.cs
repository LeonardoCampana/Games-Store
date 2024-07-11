using GamesStore.Data;
using GamesStore.Models;
using GamesStore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GamesStore.Services
{
    public class UserService : IUserService, IDisposable
    {
        private readonly UserRegisterDbContext _context;

        public UserService(UserRegisterDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateUser(string email, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
            return user != null;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
