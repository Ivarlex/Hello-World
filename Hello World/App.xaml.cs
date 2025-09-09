using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using Hello_World.Vistas;

namespace Hello_World;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        Page rootPage;

        if (Preferences.ContainsKey("UsuarioId"))
        {
            rootPage = new NavigationPage(new MainPage());
        }
        else
        {
            rootPage = new NavigationPage(new LoginPage());
        }

        return new Window(rootPage);
    }
}

//protected override Window CreateWindow(IActivationState? activationState)
//{
//  return new Window(new NavigationPage(new MainPage()));
//}
