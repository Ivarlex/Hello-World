using Hello_World.Utilidades;
using MenuPrincipal;

namespace Hello_World.Vistas;

public partial class CategoryWebPage : ContentPage
{
    readonly string _fullUrl;
    bool _alerting;

    public CategoryWebPage(string fullUrl, string title)
    {
        InitializeComponent();
        Title = title;
        _fullUrl = fullUrl;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await TryLoadAsync();
    }

    async Task TryLoadAsync()
    {
        if (!NetGuard.IsOnline())
        {
            await Block("En Este momento no tienes conexion a internet");
            return;
        }

        // ping corto contra tu servidor:
        if (!await NetGuard.IsServerAliveAsync(ServicioWeb.Instance.UrlPingLigero))
        {
            await Block("En Este momento no tienes conexion a internet");
            return;
        }

        Spinner.IsVisible = true;
        WV.Source = _fullUrl;
    }


    void WV_Navigating(object s, WebNavigatingEventArgs e) => Spinner.IsVisible = true;

    async void WV_Navigated(object s, WebNavigatedEventArgs e)
    {
        Spinner.IsVisible = false;
        if (e.Result != WebNavigationResult.Success)
            await Block("En Este momento no tienes conexion a internet");
    }

    async Task Block(string msg)
    {
        if (_alerting) return;
        _alerting = true;
        WV.Source = "about:blank";
        await DisplayAlert("Conexión", msg, "OK");
        _alerting = false;
    }
}
