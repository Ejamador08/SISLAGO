using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using ClaseDatos;

namespace ClaseNegocio
{
    public class CNegProveedor
    {

        #region C >> Create >> Insertar
        //public bool GuardaNuevaProveedor(CEntArtículo nuevo)
        //{

        //}
        #endregion

        #region R >> Read >> Seleccionar
        public List<CEntProveedor> MuestraProveedor()
        {
            CDatProveedor p = new CDatProveedor();
            return p.MuestraProveedor();
        }
        #endregion

        #region U >> Update >> Actualizar
        //public bool ActualizaProveedor(CEntArtículo nuevo)
        //{

        //}
        #endregion

        #region D >> Delete >> Eliminar
        //public bool EliminaProveedor(int id)
        //{

        //}
        #endregion
    }
}
