using Filip_Rares_Restaurants.Models;
using Filip_Rares_Restaurants.Data;
using Microsoft.Maui.Controls;

namespace Filip_Rares_Restaurants
{
    public partial class AddRestaurantPage : ContentPage
    {
        public AddRestaurantPage()
        {
            InitializeComponent();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var newRestaurant = new Restaurants
            {
                Nume = nameEntry.Text,
                Adresa = addressEntry.Text,
                Descriere = descriptionEntry.Text,
                OrarFunctionare = hoursEntry.Text
            };

            await App.Database.SaveRestaurantAsync(newRestaurant);

            // Optionally, display a confirmation message or navigate back to the list page
            await DisplayAlert("Success", "Restaurant added successfully", "OK");
            await Navigation.PopAsync(); // Go back to the previous page
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // Go back to the previous page without saving
        }
    }
}

