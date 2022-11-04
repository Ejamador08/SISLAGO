using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using ClaseDatos;

namespace ClaseNegocio
{
    public class CNegCategoria
    {
        #region C >> Create >> Insertar
        //public bool GuardaNuevaCategoria(CEntArtículo nuevo)
        //{

        //}
        #endregion

        #region R >> Read >> Seleccionar
        public List<CEntCategoria> MuestraCategoria()
        {
            CDatCategoria cat = new CDatCategoria();
            return cat.MuestraCategoria();
        }
        #endregion

        #region U >> Update >> Actualizar
        //public bool ActualizaCateegoria(CEntArtículo nuevo)
        //{

        //}
        #endregion

        #region D >> Delete >> Eliminar
        //public bool EliminaCategoria(int id)
        //{

        //}
        #endregion
    }
}
