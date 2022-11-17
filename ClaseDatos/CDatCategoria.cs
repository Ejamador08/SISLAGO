using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;

namespace ClaseDatos
{
    public class CDatCategoria
    {
        BDLago_01Entities6 context = new BDLago_01Entities6();

        #region C >> Create >> Insertar
        //public bool GuardaNuevaCategoria(CEntArtículo nuevo)
        //{

        //}
        #endregion

        #region R >> Read >> Seleccionar
        public List<CEntCategoria> MuestraCategoria()
        {
            var Consulta = (from cat in context.tblCategoria
                            where cat.Estado == true
                            orderby cat.IDCategoria descending
                            select new CEntCategoria
                            {
                                IDCategoria = cat.IDCategoria,
                                NombCategoria = cat.NombCategoria,
                                Descripcion = cat.Descripcion,
                                Imagen = cat.Imagen,
                                Estado = cat.Estado
                            }).ToList();
            return Consulta;
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
