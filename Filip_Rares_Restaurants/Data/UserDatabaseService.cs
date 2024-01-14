using System;
using System.Threading.Tasks;
using SQLite;
using Filip_Rares_Restaurants.Models;

namespace Filip_Rares_Restaurants.Data
{
    public class UserDatabaseService
    {
        private SQLiteAsyncConnection database;

        public UserDatabaseService(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<User>().Wait();
        }

        public Task<int> SaveUserAsync(User user)
        {
            // Check if the user already exists
            var existingUser = database.Table<User>().Where(u => u.Username == user.Username).FirstOrDefaultAsync().Result;
            if (existingUser != null)
            {
                // User already exists, so you might want to update or handle accordingly
                // For simplicity, let's just return -1 indicating the user already exists
                return Task.FromResult(-1);
            }

            return database.InsertAsync(user);
        }

        public Task<User> GetUserAsync(string username)
        {
            return database.Table<User>().Where(u => u.Username == username).FirstOrDefaultAsync();
        }

       
    }
}
