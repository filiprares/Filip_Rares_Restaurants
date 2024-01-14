namespace Filip_Rares_Restaurants;

public partial class WelcomePage : ContentPage
{
    public WelcomePage()
    {
        InitializeComponent();
        BindingContext = new WelcomePageViewModel();
    }
}

public class WelcomePageViewModel
{
    public Command NavigateToLoginCommand { get; }
    public Command NavigateToRegisterCommand { get; }

    public WelcomePageViewModel()
    {
        NavigateToLoginCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(LoginPage)));
        NavigateToRegisterCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(RegisterPage)));
    }
}
