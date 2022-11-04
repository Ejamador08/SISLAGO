using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CEntCategoria
    {
        public int IDCategoria { get; set; }
        public string NombCategoria { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public Nullable<bool> Estado { get; set; }
    }
}
