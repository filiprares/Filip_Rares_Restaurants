using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filip_Rares_Restaurants.Models
{
    using System.Collections.Generic;
    using System.Linq;

    namespace Filip_Rares_Restaurants.Models
    {
        // Represents an individual item in the cart
        public class CartItem
        {
            public int DishId { get; set; }
            public string DishName { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; } = 1;
        }

        // Represents the shopping cart
        public class Cart
        {
            public List<CartItem> Items { get; set; } = new List<CartItem>();

            // Adds an item to the cart
            public void AddItem(CartItem item)
            {
                var existingItem = Items.FirstOrDefault(i => i.DishId == item.DishId);
                if (existingItem != null)
                {
                    // Item exists, increase quantity
                    existingItem.Quantity += 1;
                }
                else
                {
                    // New item, add to cart
                    Items.Add(item);
                }
            }

            // Removes an item from the cart
            public void RemoveItem(int dishId)
            {
                var itemToRemove = Items.FirstOrDefault(i => i.DishId == dishId);
                if (itemToRemove != null)
                {
                    Items.Remove(itemToRemove);
                }
            }

            // Updates the quantity of a specific item in the cart
            public void UpdateItemQuantity(int dishId, int quantity)
            {
                var item = Items.FirstOrDefault(i => i.DishId == dishId);
                if (item != null)
                {
                    item.Quantity = quantity;
                }
            }

            // Calculates the total price of all items in the cart
            public decimal GetTotalPrice()
            {
                return Items.Sum(item => item.Price * item.Quantity);
            }

            // Clears all items from the cart
            public void ClearCart()
            {
                Items.Clear();
            }
        }
    }

}
