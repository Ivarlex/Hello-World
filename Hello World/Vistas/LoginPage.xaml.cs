using MenuPrincipal;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Hello_World.Modelos;

namespace Hello_World.Vistas;

public partial class LoginPage : ContentPage
{
    private readonly HttpClient _httpClient = new();
    private readonly ServicioWeb _servicio = ServicioWeb.Instance;

    public LoginPage()
    {
        InitializeComponent();
    }

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        string correo = txtCorreo.Text;
        string contrasena = txtContrasena.Text;

        if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contrasena))
        {
            await DisplayAlert("Error", "Ingrese correo y contraseña válidos", "OK");
            return;
        }

        try
        {
            var loginData = new { correo, contrasena };
            var response = await _httpClient.PostAsJsonAsync(_servicio.UrlLogin, loginData);
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<LoginResponse>(content);

            if (result?.status == "success")
            {
                // Después de parsear LoginResponse y validar que result.status == "success"
                Preferences.Set("isLoggedIn", true);
                Preferences.Set("UsuarioId", result.data.id_usuario);   // opcional pero útil
                Preferences.Set("userName", result.data.nombre);
                Preferences.Set("userEmail", result.data.correo);

                // Navega al Home como ya lo haces:
                Application.Current.Windows[0].Page = new NavigationPage(new MainPage());
            }
            else
            {
                await DisplayAlert("Error", result?.message ?? "Credenciales incorrectas", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error de conexión: {ex.Message}", "OK");
        }
    }

    public class LoginResponse
    {
        public string status { get; set; } = "";
        public string message { get; set; } = "";
        public UserData data { get; set; } = new();
    }

    public class UserData
    {
        public int id_usuario { get; set; }
        public string nombre { get; set; } = "";
        public string correo { get; set; } = "";
    }
}