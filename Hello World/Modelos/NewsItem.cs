using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World.Modelos;
public class NewsItem
{
    public string Titulo { get; set; } = "";
    public string Subtitulo { get; set; } = "";
    public string Imagen { get; set; } = "";
    public string Contenido { get; set; } = "";
    public DateTime Fecha { get; set; }
}
