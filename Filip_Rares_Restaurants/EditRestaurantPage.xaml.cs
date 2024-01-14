using System;
using Filip_Rares_Restaurants.Models;
using Microsoft.Maui.Controls;

namespace Filip_Rares_Restaurants
{
    public partial class EditRestaurantPage : ContentPage
    {
        private Restaurants _restaurant;

        public EditRestaurantPage(Restaurants restaurant)
        {
            InitializeComponent();
            _restaurant = restaurant;
            this.BindingContext = restaurant;
            LoadRestaurantDetails();
        }

        private void LoadRestaurantDetails()
        {
            nameEntry.Text = _restaurant.Nume;
            addressEntry.Text = _restaurant.Adresa;
            descriptionEntry.Text = _restaurant.Descriere;
            hoursEntry.Text = _restaurant.OrarFunctionare;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Update restaurant details
            _restaurant.Nume = nameEntry.Text;
            _restaurant.Adresa = addressEntry.Text;
            _restaurant.Descriere = descriptionEntry.Text;
            _restaurant.OrarFunctionare = hoursEntry.Text;

            // Save to database
            await App.Database.SaveRestaurantAsync(_restaurant);
            await DisplayAlert("Success", "Restaurant updated successfully", "OK");
            await Navigation.PopAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
