using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filip_Rares_Restaurants.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string Username { get; set; }
        public string Password { get; set; } // In a real app, store a password hash, not the password itself.
        public bool IsAdmin { get; set; }
    }
}