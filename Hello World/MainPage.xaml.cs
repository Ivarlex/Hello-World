using Hello_World.Vistas;
using Microsoft.Maui.Controls;

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
#if !WINDOWS
            // Navegación solo para plataformas que soportan PushAsync (Android, iOS, etc.)
            switch (cellId)
            {
                case "ActionGames":
                    await Navigation.PushAsync(new ActionGamesPage());
                    break;
                case "AdventureGames":
                    await Navigation.PushAsync(new AdventureGamesPage());
                    break;
                case "StrategyGames":
                    await Navigation.PushAsync(new StrategyGamesPage());
                    break;
                case "SportsGames":
                    await Navigation.PushAsync(new SportsGamesPage());
                    break;
                case "Offers":
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
#else
            // Acción alternativa para Windows (por ejemplo, mostrar un mensaje)
            await DisplayAlert("Windows", $"Función no disponible en Windows. Seleccionaste: {cellId}", "OK");
#endif
        }
    }
}