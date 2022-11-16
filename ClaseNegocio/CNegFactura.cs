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

        #region Guarda Producto en la Tabla Temporal
        public bool GuardaTMP(CEntDetalleFacturaTMP tmp)
        {
            CDatFactura d = new CDatFactura();
            return d.GuardaTMP(tmp);
        }
        #endregion

        #region Muestra Grid Detalle Temporal Factura
        public List<CEntDetalleFacturaTMP> MuestraTemporal(string user)
        {
            CDatFactura f = new CDatFactura();
            return f.MuestraTemporal(user);
        }
        #endregion

        #region Elimina Articulo en la tblDetalleVtaTemp
        public bool EliminaTemporal(int id)
        {
            CDatFactura f = new CDatFactura();
            return f.EliminaTemporal(id);
        }
        #endregion

        #region Cantidad Articulos Temporales
        public bool Cantidad(int cant, int id)
        {
            CDatFactura f = new CDatFactura();

            return f.Cantidad(cant, id);
        }
        #endregion
    }
}
