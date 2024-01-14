using System;
using Filip_Rares_Restaurants.Models;
using Filip_Rares_Restaurants.Data;
using Microsoft.Maui.Controls;


namespace Filip_Rares_Restaurants
{
    public partial class ListEntryPage : ContentPage
    {
        private RestaurantsDatabase _database;
        private List<Restaurants> _allRestaurants; // Field to hold all restaurants

        public ListEntryPage()
        {
            InitializeComponent();
            _database = App.Database; // Ensure App.Database is initialized
            LoadRestaurants();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _allRestaurants = await _database.GetRestaurantsAsync(); // Load all restaurants
            UpdateRestaurantList(_allRestaurants); // Update the list view
        }

        private async void LoadRestaurants()
        {
            _allRestaurants = await _database.GetRestaurantsAsync(); // Load all restaurants
            UpdateRestaurantList(_allRestaurants); // Update the list view
        }

        private void UpdateRestaurantList(List<Restaurants> restaurants)
        {
            listView.ItemsSource = restaurants;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = e.NewTextValue?.ToLower() ?? string.Empty;
            var filteredRestaurants = _allRestaurants.Where(r => r.Nume.ToLower().Contains(searchText)).ToList();
            UpdateRestaurantList(filteredRestaurants);
        }


        async void OnAddRestaurantClicked(object sender, EventArgs e)
        {
            // Assuming AppInfo.CurrentUser.IsAdmin is a flag indicating if the user is an admin
            if (AppInfo.CurrentUser.IsAdmin)
            {
                // Navigate to the page to add a new restaurant
                await Navigation.PushAsync(new AddRestaurantPage());
            }
            else
            {
                await DisplayAlert("Access Denied", "You do not have permission to add restaurants.", "OK");
            }
        }

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var restaurant = (Restaurants)button.BindingContext;
            await NavigateToEditRestaurant(restaurant);
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var restaurant = (Restaurants)button.BindingContext;
            await AttemptToDeleteRestaurant(restaurant);
        }


        private async Task NavigateToEditRestaurant(Restaurants restaurant)
        {
            if (AppInfo.CurrentUser.IsAdmin)
            {
                await Navigation.PushAsync(new EditRestaurantPage(restaurant));
            }
            else
            {
                await DisplayAlert("Access Denied", "You do not have permission to edit restaurants.", "OK");
            }
        }
        private async void OnMenuButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var selectedRestaurant = (Restaurants)button.CommandParameter;

            if (selectedRestaurant != null)
            {
                await Navigation.PushAsync(new MenuPage(selectedRestaurant.ID)); // Pass the restaurant's ID
            }
        }

        private async Task AttemptToDeleteRestaurant(Restaurants restaurant)
        {
            if (AppInfo.CurrentUser.IsAdmin)
            {
                bool confirmDelete = await DisplayAlert("Confirm Delete", "Do you want to delete this restaurant?", "Yes", "No");
                if (confirmDelete)
                {
                    await _database.DeleteRestaurantAsync(restaurant);
                    listView.ItemsSource = await _database.GetRestaurantsAsync(); // Refresh the list
                }
            }
            else
            {
                await DisplayAlert("Access Denied", "You do not have permission to delete restaurants.", "OK");
            }
        }
        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            // Clear any stored user information
            Preferences.Clear(); // Using MAUI Essentials to clear preferences, which might store user info

            // If using secure storage (for tokens etc.), clear that as well
            SecureStorage.RemoveAll();

            // If there's any active session or authentication token, invalidate it
            // This could be an API call to your backend to logout the user, for example:
            // await myApiService.LogoutAsync();

            Application.Current.MainPage = new LoginPage();

            // Optionally, display a confirmation or information message
            await DisplayAlert("Logged Out", "You have been successfully logged out.", "OK");
        }




            async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new RestaurantDetailPage
                {
                    BindingContext = e.SelectedItem as Restaurants
                });
            }
        }
    }
}
