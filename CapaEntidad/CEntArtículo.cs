using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CEntArtículo
    {
        public int IDArticulos { get; set; }
        public string NombreArticulos { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaIngreso { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
        public string UnidadMedidas { get; set; }
        public float PrecioCompra { get; set; }
        public float PrecioVenta { get; set; }
        public float Impuestos { get; set; }
        public string Imagen { get; set; }
        public int IDProveedor { get; set; }
        public int IDCategoria { get; set; }
        public Nullable<bool> Estado { get; set; }

        public string NombreProveedor { get; set; }
        public string NombreCategoria { get; set; }
    }
}
