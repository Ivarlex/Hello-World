using Hello_World.Modelos;
using Newtonsoft.Json;

namespace Hello_World.Vistas;

public partial class NewsPage : ContentPage
{
    public NewsPage()
    {
        InitializeComponent();
        _ = LoadAsync();
    }

    async Task LoadAsync()
    {
        try
        {
            using var s = await FileSystem.OpenAppPackageFileAsync("news.json");
            using var r = new StreamReader(s);
            var json = await r.ReadToEndAsync();
            var items = JsonConvert.DeserializeObject<List<NewsItem>>(json) ?? new();
            NewsList.ItemsSource = items.OrderByDescending(i => i.Fecha).ToList();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Noticias", $"No se pudieron cargar.\n{ex.Message}", "OK");
        }
    }
}
