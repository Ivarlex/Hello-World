using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace Hello_World.Vistas;

public partial class StartupPage : ContentPage
{
    public StartupPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await Task.Delay(500);

        if (Preferences.ContainsKey("UsuarioId"))
        {
            Application.Current.Windows[0].Page = new NavigationPage(new MainPage());
        }
        else
        {
            Application.Current.Windows[0].Page = new NavigationPage(new LoginPage());
        }
    }
}
