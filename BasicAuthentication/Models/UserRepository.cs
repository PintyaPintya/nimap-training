﻿namespace BasicAuthentication.Models
{
    public interface IUserRepository
    {
        Task<bool> ValidateUser(string username, string password);
        Task<List<User>> GetAllUsers();
    }
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>
        {
            new User { Id = 1, Username = "admin", Password = "admin" },
            new User { Id = 2, Username = "user", Password = "user" },
        };

        public async Task<bool> ValidateUser(string username, string password)
        {
            await Task.Delay(100);
            return users.Any(u => u.Username == username && u.Password == password);
        }

        public async Task<List<User>> GetAllUsers()
        {
            await Task.Delay(100);
            return users.ToList();
        }
    }
}