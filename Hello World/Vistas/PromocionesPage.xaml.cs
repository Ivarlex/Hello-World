using System;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using Hello_World;
using System.Threading.Tasks;
using Hello_World.Modelos;
using System.Reflection;

namespace Hello_World.Vistas
{
    public partial class PromocionesPage : ContentPage
    {
        public PromocionesPage()
        {
            InitializeComponent();
            dpkFecha.Date = DateTime.Now; // Fecha actual por defecto (16/06/2025)
        }

        private async void btnConsultar_Clicked(object sender, EventArgs e)
        {
            indicador.IsRunning = true;
            indicador.IsVisible = true;

            try
            {
                var fechaSeleccionada = dpkFecha.Date;
                var ofertas = await LoadOfertasFromJson();
                var promocionesActivas = ofertas.Where(o => o.en_oferta &&
                                                           o.fecha_inicio <= fechaSeleccionada &&
                                                           o.fecha_fin >= fechaSeleccionada).ToList();
                lstPromociones.ItemsSource = promocionesActivas;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error al cargar las ofertas: " + ex.Message, "OK");
            }
            finally
            {
                indicador.IsRunning = false;
                indicador.IsVisible = false;
            }
        }

        private async Task<List<JuegoPromocion>> LoadOfertasFromJson()
        {
            using var s = await FileSystem.OpenAppPackageFileAsync("ofertas_juegos.json");
            using var r = new StreamReader(s);
            var json = await r.ReadToEndAsync();
            return JsonConvert.DeserializeObject<List<JuegoPromocion>>(json) ?? new();
        }
    }
}