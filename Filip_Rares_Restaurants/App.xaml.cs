using System;
using Filip_Rares_Restaurants.Data;

using System.IO;
using Filip_Rares_Restaurants.Models.Filip_Rares_Restaurants.Models;

namespace Filip_Rares_Restaurants
{
    public partial class App : Application
    {
        static RestaurantsDatabase database;
        static UserDatabaseService databaseService;
        static MenuService menuService;
        public static Cart Cart { get; set; }

        public static RestaurantsDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new RestaurantsDatabase(GetDbPath("Restaurants.db3"));
                }
                return database;
            }
        }

        public static UserDatabaseService DatabaseService
        {
            get
            {
                if (databaseService == null)
                {
                    databaseService = new UserDatabaseService(GetDbPath("UserSQLite.db3"));
                }
                return databaseService;
            }
        }

        public static MenuService MenuService
        {
            get
            {
                if (menuService == null)
                {
                    menuService = new MenuService(GetDbPath("MenuItems.db3"));
                }
                return menuService;
            }
        }

        public App()
        {
            InitializeComponent();
            Cart = new Cart();

            MainPage = new AppShell();
        }

        private static string GetDbPath(string databaseFileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), databaseFileName);
        }
    }
}
