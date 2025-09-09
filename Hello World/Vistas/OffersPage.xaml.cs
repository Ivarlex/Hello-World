using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using Hello_World.Modelos;

namespace Hello_World.Vistas
{
    public partial class OffersPage : ContentPage
    {
        public OffersPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                using var s = await FileSystem.OpenAppPackageFileAsync("ofertas_juegos.json");
                using var r = new StreamReader(s);
                var json = await r.ReadToEndAsync();

                var items = JsonConvert.DeserializeObject<List<JuegoPromocion>>(json) ?? new();
                OffersList.ItemsSource = items
                    .Where(x => x.en_oferta)
                    .OrderByDescending(x => x.fecha_fin)
                    .ToList();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ofertas", $"No se pudieron cargar.\n{ex.Message}", "OK");
            }
        }
    }
}
