using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CEntUsuarios
    {
        public int IDUsuario { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public string Imagen { get; set; }
        public int IDEmpleado { get; set; }
        public Nullable<bool> Estado { get; set; }
    }
}
