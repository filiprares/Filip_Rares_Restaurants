namespace Filip_Rares_Restaurants;
using Filip_Rares_Restaurants.Models;
public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var username = usernameEntry.Text;
        var password = passwordEntry.Text; // This should be a hashed password in a real app

        var user = await App.DatabaseService.GetUserAsync(username);

        if (user != null && user.Password == password) // Password comparison; use hash comparison in real apps
        {
            AppInfo.CurrentUser = user;
            // Login successful, navigate to the main page or dashboard
            Application.Current.MainPage = new AuthenticatedShell();
            // For example: await Navigation.PushAsync(new MainPage());

            // You can also store the user's session or role as needed
        }
        else
        {
            // Login failed, show error message
            await DisplayAlert("Login Failed", "Invalid username or password.", "OK");
        }
    }
}
