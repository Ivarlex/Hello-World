using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using MenuPrincipal;

namespace Hello_World.Vistas
{
    public partial class ActionGamesPage : ContentPage
    {
        private readonly ServicioWeb _servicioWeb;

        public ActionGamesPage()
        {
            InitializeComponent();
            _servicioWeb = ServicioWeb.Instance; // Cambiado para usar la instancia singleton
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            string url = $"{_servicioWeb.Domain}juegos_por_genero.php"; // Cambiado para usar la propiedad pública 'Domain'
            actionGamesWebView.Source = new UrlWebViewSource
            {
                Url = url
            };
        }
    }
}