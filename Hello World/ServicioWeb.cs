using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPrincipal
{
    public sealed class ServicioWeb
    {
        private static readonly ServicioWeb _instance = new();
        public static ServicioWeb Instance => _instance;
        private ServicioWeb() { }

        // Ajusta a tu IP/carpeta XAMPP
        private const string _base = "http://192.168.100.7/MAUIWeb/";
        public string Domain => _base;

        // APIs (carpeta /api en tu servidor)
        private string Api(string p) => $"{Domain}api/{p}";
        public string UrlLogin => Api("login.php");
        public string UrlRegistro => Api("registro.php");
        public string UrlPerfil => Api("perfil.php");
        public string UrlQuienesSomos => Api("quienes_somos.php");


        // Web (categorías)
        public string UrlAdventure => $"{Domain}adventure_games.php";
        public string UrlStrategy => $"{Domain}estrategia.php";
        public string UrlAction => $"{Domain}action_games.php";
        public string UrlSports => $"{Domain}sports_games.php";

        // Utilidades
        public string UrlPromosApi => $"{Domain}consulta_promociones.php";
        public string UrlTerminos => $"{Domain}consulta_terminos.php";
        public string UrlOfertasJsonRemoto => $"{Domain}ofertas_juegos.json";

        // Usado por CategoryWebPage para "ping" corto
        public string UrlPingLigero => $"{Domain}api/ping.php";

    }

    //public string dominio { get; } = "http://10.150.13.13/php/";
    //public string dominio { get; } = "http://10.150.31.117/MAUIWeb/";
    //public string dominio { get; } = "http://192.168.1.15/php/";
    //public string dominio { get; } = "http://192.168.1.9/php/";
}
    

