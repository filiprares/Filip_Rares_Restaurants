using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filip_Rares_Restaurants.Models
{
    public class MenuDish
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int RestaurantId { get; set; }  // Foreign key to Restaurant
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


    }
}