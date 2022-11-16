using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using ClaseDatos;

namespace ClaseNegocio
{
    public class  CNegFactura
    {
        #region Última Factura
        public int UltimaFactura()
        {
            CDatFactura f = new CDatFactura();
            return f.UltimaFactura();
        }
        #endregion
    }
}
