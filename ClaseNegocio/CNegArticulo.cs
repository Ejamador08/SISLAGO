using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using ClaseDatos;

namespace ClaseNegocio
{
    public class CNegArticulo
    {
        #region C >> Create >> Insertar
        public bool GuardaNuevoArticulo(CEntArtículo nuevo)
        {
            CDatArtículo art = new CDatArtículo();
            return art.GuardaNuevoArticulo(nuevo);
        }
        #endregion

        #region R >> Read >> Seleccionar
        public List<CEntArtículo> MuestraArticulos()
        {
            CDatArtículo art = new CDatArtículo();
            return art.MuestraArticulos();
        }
        #endregion

        #region U >> Update >> Actualizar
        public bool ActualizaArticulo(CEntArtículo nuevo)
        {
            CDatArtículo art = new CDatArtículo();
            return art.ActualizaArticulo(nuevo);
        }
        #endregion

        #region D >> Delete >> Eliminar
        public bool EliminaArticulo(int id)
        {
            CDatArtículo art = new CDatArtículo();
            return art.EliminaArticulo(id);
        }
        #endregion

        #region Muestra X cantidad de Artículos
        public List<CEntArtículo> MuestraXCantidad(int cant)
        {
            var art = new CDatArtículo();
            return art.MuestraXCantidad(cant);
        }
        #endregion
    }
}
