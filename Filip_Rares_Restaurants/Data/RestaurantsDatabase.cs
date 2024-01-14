using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Filip_Rares_Restaurants.Models;

namespace Filip_Rares_Restaurants.Data
{
    public class RestaurantsDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public RestaurantsDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Restaurants>().Wait();
        }

        public Task<List<Restaurants>> GetRestaurantsAsync()
        {
            return _database.Table<Restaurants>().ToListAsync();
        }

        public Task<Restaurants> GetRestaurantAsync(int id)
        {
            return _database.Table<Restaurants>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveRestaurantAsync(Restaurants restaurant)
        {
            if (restaurant.ID != 0)
            {
                return _database.UpdateAsync(restaurant);
            }
            else
            {
                return _database.InsertAsync(restaurant);
            }
        }

        public Task<int> DeleteRestaurantAsync(Restaurants restaurant)
        {
            return _database.DeleteAsync(restaurant);
        }
    }
}
