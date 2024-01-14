using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Filip_Rares_Restaurants.Models
{
    public class Restaurants
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(100), Unique]
        public string Nume { get; set; }
        [MaxLength(150)]
        public string Adresa { get; set; }
        [MaxLength(250), Unique]
        public string Descriere {  get; set; }
        [MaxLength(150)]
        public string OrarFunctionare { get; set; } 
  
    }
}
