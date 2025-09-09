using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World.Modelos
{
    public class JuegoPromocion   // <- era internal
    {
        public int id_juego { get; set; }
        public string nombre { get; set; } = "";
        public string genero { get; set; } = "";
        public string descripcion { get; set; } = "";
        public decimal precio { get; set; }
        public bool en_oferta { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public string imagen_url { get; set; } = "";
    }
}
