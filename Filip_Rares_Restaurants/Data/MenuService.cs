using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Filip_Rares_Restaurants.Models;


namespace Filip_Rares_Restaurants.Data
{
    public class MenuService
    {
        private SQLiteAsyncConnection _database;

        public MenuService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<MenuDish>().Wait();
        }

        public Task<List<MenuDish>> GetMenuItemsByRestaurantAsync(int restaurantId)
        {
            return _database.Table<MenuDish>()
                            .Where(i => i.RestaurantId == restaurantId)
                            .ToListAsync();
        }

        public Task<int> AddMenuItemAsync(MenuDish item)
        {
            return _database.InsertAsync(item);
        }
        public Task<int> DeleteMenuDishAsync(MenuDish dish)
        {
            return _database.DeleteAsync(dish);
        }

    }
  
}
