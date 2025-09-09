using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World.Modelos
{
    public class LoginResponse
    {
        public string status { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public UserData data { get; set; } = new();
    }

    public class UserData
    {
        public int id_usuario { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string correo { get; set; } = string.Empty;
    }

    public class ErrorResponse
    {
        public string message { get; set; } = string.Empty;
    }
}
