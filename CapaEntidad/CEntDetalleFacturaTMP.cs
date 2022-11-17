using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CEntDetalleFacturaTMP
    {
        public int IDDetFacturaTMP { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<float> Subtotal { get; set; }
        public Nullable<float> Total { get; set; }
        public Nullable<int> IDArticulos { get; set; }
        public Nullable<int> IDFactura { get; set; }
        public Nullable<int> IDUsuario { get; set; }
        public Nullable<bool> Estado { get; set; }
        public Nullable<float> PrecioVenta { get; set; }
        public Nullable<float> Descuento { get; set; }
        public string Garantia { get; set; }
        public string Username { get; set; }

        public string NombreArticulo { get; set; }
    }
}
