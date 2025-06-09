using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using MenuPrincipal; // Agrega este using

namespace Hello_World.Vistas
{
    public partial class StrategyGamesPage : ContentPage
    {
        private readonly ServicioWeb _servicioWeb;

        public StrategyGamesPage()
        {
            InitializeComponent();
            _servicioWeb = new ServicioWeb();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            string url = $"{_servicioWeb.dominio}juegos_estrategia.php";
            strategyGamesWebView.Source = new UrlWebViewSource
            {
                Url = url
            };
        }


    }
}