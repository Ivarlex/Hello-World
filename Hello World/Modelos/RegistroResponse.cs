using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World.Modelos;

public class RegistroResponse
{
    public string status { get; set; } = string.Empty;
    public string message { get; set; } = string.Empty;
    public int? user_id { get; set; }
}
