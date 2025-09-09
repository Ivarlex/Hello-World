using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using MenuPrincipal; // Agrega este using

namespace Hello_World.Vistas
{
    public partial class AdventureGamesPage : ContentPage
    {
        private readonly ServicioWeb _servicioWeb;

        public AdventureGamesPage()
        {
            InitializeComponent();
            _servicioWeb = ServicioWeb.Instance;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            string url = $"{_servicioWeb.Domain}juegos_Aventura.php";
            adventureGamesWebView.Source = new UrlWebViewSource
            {
                Url = url
            };
        }
    }
}

