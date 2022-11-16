using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CEntDetalleFacturaTMP
    {
        public int IDdetFactTMP { get; set; }
        public int Cantidad { get; set; }
        public float Subtotal { get; set; }
        public float Total { get; set; }
        public int IDArticulos { get; set; }
        public int IDFactura { get; set; }
        public int IDUsuario { get; set; }
        public bool Estado { get; set; }
        public float PrecioVenta { get; set; }
        public float Descuento { get; set; }
        public string Garantia { get; set; }
        public string Username { get; set; }
    }
}
