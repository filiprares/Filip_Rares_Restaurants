namespace Filip_Rares_Restaurants;
using Filip_Rares_Restaurants.Data;
using Filip_Rares_Restaurants.Models;
using Filip_Rares_Restaurants.Models.Filip_Rares_Restaurants.Models;

public partial class MenuPage : ContentPage
{
    private readonly int _restaurantId;
    public bool IsAdmin => AppInfo.CurrentUser.IsAdmin;

    public MenuPage(int restaurantId)
    {
        InitializeComponent();
        _restaurantId = restaurantId;
        BindingContext = this;
    }
    private async void OnDeleteDishClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var dishToDelete = (MenuDish)button.CommandParameter;

        // Confirm delete action
        bool confirm = await DisplayAlert("Confirm Delete", $"Are you sure you want to delete {dishToDelete.Name}?", "Yes", "No");
        if (confirm)
        {
            await App.MenuService.DeleteMenuDishAsync(dishToDelete);
            // Refresh the items
            menuItemsCollectionView.ItemsSource = await App.MenuService.GetMenuItemsByRestaurantAsync(_restaurantId);
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        menuItemsCollectionView.ItemsSource = await App.MenuService.GetMenuItemsByRestaurantAsync(_restaurantId);
    }
    private void OnAddToCartClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var dish = (MenuDish)button.BindingContext;

        var cartItem = new CartItem
        {
            DishId = dish.Id,
            DishName = dish.Name,
            Price = dish.Price,
            Quantity = 1 // or any quantity logic you wish to implement
        };

        // Assuming you have a Cart instance accessible, e.g., in your App class
        App.Cart.AddItem(cartItem);

        // Optionally, give feedback to the user that the item was added
        DisplayAlert("Added to Cart", $"{dish.Name} added to your cart.", "OK");
    }
    private async void OnViewCartClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CartPage());
    }
    private async void OnAddNewDishClicked(object sender, EventArgs e)
    {
        // Navigate to AddDishPage, passing the restaurant ID
        await Navigation.PushAsync(new AddDishPage(_restaurantId));
    }
}
