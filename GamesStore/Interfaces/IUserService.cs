using GamesStore.Data;
using GamesStore.Models;

namespace GamesStore.Interfaces
{
    public interface IUserService
    {
        Task AddUserAsync(User user);
    }

    public class UserService : IUserService, IDisposable
    {
        private readonly UserRegisterDbContext _context;

        public UserService(UserRegisterDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            using (_context)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
