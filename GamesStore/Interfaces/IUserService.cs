using GamesStore.Data;
using GamesStore.Models;

namespace GamesStore.Interfaces
{
    public interface IUserService
    {
        Task AddUserAsync(User user);
        Task<bool> ValidateUser(string email, string password);
    }
}
