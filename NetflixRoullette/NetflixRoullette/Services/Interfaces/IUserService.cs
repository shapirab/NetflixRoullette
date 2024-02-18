using NetflixRoullette.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetflixRoullette.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
        Task<bool> UpdateUserAsync(User user);
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByCredentials(string username, string password);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
