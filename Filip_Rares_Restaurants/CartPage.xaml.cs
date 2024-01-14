namespace Filip_Rares_Restaurants;
using Filip_Rares_Restaurants.Models.Filip_Rares_Restaurants.Models;

public partial class CartPage : ContentPage
{
    public CartPage()
    {
        InitializeComponent();
        cartItemsCollectionView.ItemsSource = App.Cart.Items;
        UpdateCartDisplay();
    }

    private void UpdateCartDisplay()
    {
        cartItemsCollectionView.ItemsSource = App.Cart.Items;
        totalPriceLabel.Text = $"Total Price: {App.Cart.GetTotalPrice():C}";
    }
    private async void OnRemoveItemClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var cartItemToRemove = (CartItem)button.CommandParameter;

        // Confirm remove action
        bool confirm = await DisplayAlert("Confirm Remove", $"Are you sure you want to remove {cartItemToRemove.DishName} from the cart?", "Yes", "No");
        if (confirm)
        {
            // This assumes you have a method in your App.Cart to remove an item by its DishId
            App.Cart.RemoveItem(cartItemToRemove.DishId);

            // Refresh the cart's collection view
            cartItemsCollectionView.ItemsSource = null;
            cartItemsCollectionView.ItemsSource = App.Cart.Items;
        }
        UpdateCartDisplay();
    }


    //  private async void OnCheckoutClicked(object sender, EventArgs e)
    //{
    // Navigate to CheckoutPage
    //  await Navigation.PushAsync(new CheckoutPage());
    //}
}
