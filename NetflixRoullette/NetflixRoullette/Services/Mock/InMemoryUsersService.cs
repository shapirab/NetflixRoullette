using NetflixRoullette.Models;
using NetflixRoullette.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixRoullette.Services.Mock
{
    public class InMemoryUsersService : IUserService
    {
        private List<User> _users;
        public InMemoryUsersService()
        {
            _users = new List<User>()
            {
                new User{ Id = 1, FirstName = "Yami", LastName = "Shapira", Username = "yami", Password = "123"},
                new User{ Id = 2, FirstName = "Liat", LastName = "Margalit", Username = "liati", Password= "456"},
                new User{ Id = 3, FirstName = "Moshe", LastName = "Fridman", Username = "mosh", Password = "999"}
            };

        }
        public async Task<bool> AddUserAsync(User user)
        {
            _users.Add(user);
            return true;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            User userToRemove = await GetUserByIdAsync(userId);
            _users.Remove(userToRemove);
            return true;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return _users;
        }

        public async Task<User> GetUserByCredentials(string username, string password)
        {
            return _users.Where(user => user.Username == username && user.Password == password).FirstOrDefault();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return _users.Where(user => user.Id == userId).FirstOrDefault();
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            User userToUpdate = await GetUserByIdAsync(user.Id);
            if (userToUpdate != null)
            {
                userToUpdate.Username = user.Username;
                userToUpdate.Password = user.Password;
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
                return true;
            }
            return false;
        }
    }
}
