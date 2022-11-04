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

        #region Muestra Artículo por ID
        public CEntArtículo MuestraArticuloxID(int id)
        {
            CDatArtículo art = new CDatArtículo();

            return art.MuestraArticuloxID(id);
        }
        #endregion

        #region Dar de Baja a un Artículo
        public bool BajaArticulo(int id)
        {
            CDatArtículo a = new CDatArtículo();

            return a.BajaArticulo(id);
        }
        #endregion

        #region Dar de Alta a un Artículo
        public bool AltaArticulo(int id)
        {
            CDatArtículo a = new CDatArtículo();

            return a.AltaArticulo(id);
        }
        #endregion

        #region Muestra Articulos Inactivos
        public List<CEntArtículo> MuestraArticulosInactivos()
        {
            CDatArtículo art = new CDatArtículo();

            return art.MuestraArticulosInactivos();
        }
        #endregion

        #region Muestra Articulos Activos por Nombre
        public List<CEntArtículo> ArticulosActivosxNombre(string nombre)
        {
            CDatArtículo art = new CDatArtículo();

            return art.ArticulosActivosxNombre(nombre);
        }
        #endregion

        #region Muestra Articulos Inactivos por Nombre
        public List<CEntArtículo> ArticulosInactivosxNombre(string nombre)
        {
            CDatArtículo art = new CDatArtículo();

            return art.ArticulosInactivosxNombre(nombre);
        }
        #endregion
    }
}
