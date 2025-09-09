using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace Hello_World.Vistas;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
    }

    bool _reminded;
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        bool logged = Preferences.Get("isLoggedIn", false) || Preferences.ContainsKey("UsuarioId");
        if (!logged)
        {
            if (_reminded) return;
            _reminded = true;
            await DisplayAlert("Perfil", "Inicia sesión por favor", "OK");
            await Navigation.PushAsync(new LoginPage());
            _reminded = false;
            return;
        }

        // Lee los datos con fallback a las otras claves
        lblNombre.Text = Preferences.Get("userName", Preferences.Get("UsuarioNombre", ""));
        lblCorreo.Text = Preferences.Get("userEmail", Preferences.Get("UsuarioCorreo", ""));
    }

    private async void btnCerrarSesion_Clicked(object sender, EventArgs e)
    {
        Preferences.Remove("isLoggedIn");
        Preferences.Remove("UsuarioId");
        Preferences.Remove("userName");
        Preferences.Remove("userEmail");
        Application.Current.Windows[0].Page = new NavigationPage(new LoginPage());
    }
}
