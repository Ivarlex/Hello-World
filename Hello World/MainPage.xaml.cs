using Hello_World.Vistas;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace Hello_World;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCellTapped(object sender, EventArgs e)
    {
        if (sender is View view && view.GestureRecognizers[0] is TapGestureRecognizer tapGesture)
        {
            string cellId = tapGesture.CommandParameter?.ToString();

            switch (cellId)
            {
                case "ActionGames":
                    await Navigation.PushAsync(
                        new CategoryWebPage(MenuPrincipal.ServicioWeb.Instance.UrlAction, "Acción"));
                    break;
                case "AdventureGames":
                    await Navigation.PushAsync(
                        new CategoryWebPage(MenuPrincipal.ServicioWeb.Instance.UrlAdventure, "Aventura"));
                    break;
                case "StrategyGames":
                    await Navigation.PushAsync(
                        new CategoryWebPage(MenuPrincipal.ServicioWeb.Instance.UrlStrategy, "Estrategia"));
                    break;
                case "SportsGames":
                    await Navigation.PushAsync(
                        new CategoryWebPage(MenuPrincipal.ServicioWeb.Instance.UrlSports, "Deportes"));
                    break;
                case "Promociones":
                    await Navigation.PushAsync(new OffersPage());
                    break;
                case "Cart":
                    await Navigation.PushAsync(new CartPage());
                    break;
                case "Profile":
                    await Navigation.PushAsync(new ProfilePage());
                    break;
                case "Support":
                    await Navigation.PushAsync(new SupportPage());
                    break;
                default:
                    await DisplayAlert("Error", "Opción no reconocida", "OK");
                    break;
            }
        }
    }

    private async void btnCerrarSesion_Clicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Cerrar sesión", "¿Estás seguro de que deseas cerrar sesión?", "Sí", "Cancelar");
        if (confirm)
        {
            Preferences.Clear();
            Application.Current.Windows[0].Page = new NavigationPage(new LoginPage());
        }
    }
}
