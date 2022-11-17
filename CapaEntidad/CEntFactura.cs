using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CEntFactura
    {
        public int IDFactura { get; set; }
        public System.DateTime Fecha { get; set; }
        public string NombCompCliente { get; set; }
        public float Total { get; set; }
        public string Anulada { get; set; }
        public Nullable<int> IDUsuario { get; set; }
    }
}
