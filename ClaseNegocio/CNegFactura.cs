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
            CDatFacturacion f = new CDatFacturacion();
            return f.UltimaFactura();
        }
        #endregion

        #region Guarda Producto en la Tabla Temporal
        public bool GuardaTMP(CEntDetalleFacturaTMP tmp)
        {
            CDatFacturacion f = new CDatFacturacion();
            return f.GuardaTMP(tmp);
        }
        #endregion

        #region Muestra Grid Detalle Temporal Factura
        public List<CEntDetalleFacturaTMP> MuestraTemporal(string user)
        {
            CDatFacturacion f = new CDatFacturacion();
            return f.MuestraTemporal(user);
        }
        #endregion

        #region Elimina Articulo en la tblDetalleVtaTemp
        public bool EliminaTemporal(int id)
        {
            CDatFacturacion f = new CDatFacturacion();
            return f.EliminaTemporal(id);
        }
        #endregion

        #region Cantidad Articulos Temporales
        public bool Cantidad(int cant, int id)
        {
            CDatFacturacion f = new CDatFacturacion();

            return f.Cantidad(cant, id);
        }
        #endregion
    }
}
