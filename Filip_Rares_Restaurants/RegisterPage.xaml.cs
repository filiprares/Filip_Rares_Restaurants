namespace Filip_Rares_Restaurants;
using Filip_Rares_Restaurants.Models;
using System;



    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            // Extract user information from the UI
            var username = usernameEntry.Text;
            var password = passwordEntry.Text; // Password hashing should be applied in a real application
            var isAdmin = isAdminSwitch.IsToggled;

            // Create a user object
            var user = new User
            {
                Username = username,
                Password = password, // Ensure this is securely handled
                IsAdmin = isAdmin
            };

            // Save user to database (handle any exceptions/errors)
            var result = await App.DatabaseService.SaveUserAsync(user);

            // Check result and respond accordingly (e.g., navigate to login page or show error)
            if (result > 0)
            {
                // User saved successfully, navigate to login or main page
                await DisplayAlert("Success", "Registration successful", "OK");
                // Example navigation: await Shell.Current.GoToAsync("//LoginPage");
            }
            else
            {
                // Handle error (e.g., user already exists)
                await DisplayAlert("Error", "Registration failed", "OK");
            }
        }
    }

