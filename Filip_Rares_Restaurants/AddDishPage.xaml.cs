namespace Filip_Rares_Restaurants;
using Filip_Rares_Restaurants.Models;

public partial class AddDishPage : ContentPage
{
    private readonly int _restaurantId;

    public AddDishPage(int restaurantId)
    {
        InitializeComponent();
        _restaurantId = restaurantId;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var newDish = new MenuDish
        {
            RestaurantId = _restaurantId,
            Name = nameEntry.Text,
            Description = descriptionEntry.Text,
            Price = decimal.Parse(priceEntry.Text) // Add validation for correct parsing
        };

        await App.MenuService.AddMenuItemAsync(newDish);
        await DisplayAlert("Success", "New dish added to the menu.", "OK");
        await Navigation.PopAsync(); // Navigate back to the MenuPage
    }
}
