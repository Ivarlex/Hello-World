using MenuPrincipal;
using Microsoft.Maui.Controls;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Hello_World.Modelos;

namespace Hello_World.Vistas;

public partial class RegistroPage : ContentPage
{
    private readonly HttpClient _httpClient = new();
    private readonly ServicioWeb _servicio = ServicioWeb.Instance;

    public RegistroPage()
    {
        InitializeComponent();
    }

    private async void btnRegistrar_Clicked(object sender, EventArgs e)
    {
        if (!ValidarCampos())
            return;

        ToggleLoading(true);

        try
        {
            var registroData = new
            {
                nombre = txtNombre.Text!.Trim(),
                correo = txtCorreo.Text!.Trim().ToLower(),
                contrasena = txtContrasena.Text!
            };

            var json = JsonSerializer.Serialize(registroData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_servicio.UrlRegistro, content);
            var responseText = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<RegistroResponse>(responseText);

                if (result?.status == "success")
                {
                    await DisplayAlert("Éxito", "Cuenta creada correctamente", "OK");
                    await Navigation.PopAsync(); // Volver al login
                }
                else
                {
                    await DisplayAlert("Error", result?.message ?? "Error al registrar", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Error en el servidor", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error inesperado: {ex.Message}", "OK");
        }
        finally
        {
            ToggleLoading(false);
        }
    }

    private bool ValidarCampos()
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            DisplayAlert("Error", "El nombre es obligatorio", "OK");
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtCorreo.Text) || !txtCorreo.Text.Contains("@"))
        {
            DisplayAlert("Error", "Ingrese un correo válido", "OK");
            return false;
        }

        if (txtContrasena.Text != txtConfirmarContrasena.Text)
        {
            DisplayAlert("Error", "Las contraseñas no coinciden", "OK");
            return false;
        }

        if (txtContrasena.Text.Length < 6)
        {
            DisplayAlert("Error", "La contraseña debe tener al menos 6 caracteres", "OK");
            return false;
        }

        return true;
    }

    private void ToggleLoading(bool isLoading)
    {
        loadingIndicator.IsVisible = isLoading;
        loadingIndicator.IsRunning = isLoading;
        btnRegistrar.IsEnabled = !isLoading;
    }
}