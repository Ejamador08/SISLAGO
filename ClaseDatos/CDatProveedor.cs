using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;

namespace ClaseDatos
{
    public class CDatProveedor
    {
        BDLago_01Entities2 context = new BDLago_01Entities2();

        #region C >> Create >> Insertar
        //public bool GuardaNuevaProveedor(CEntArtículo nuevo)
        //{

        //}
        #endregion

        #region R >> Read >> Seleccionar
        public List<CEntProveedor> MuestraProveedor()
        {
            var Consulta = (from pro in context.tblProveedor
                            where pro.Estado == true
                            orderby pro.IDProveedor descending
                            select new CEntProveedor
                            {
                                IDProveedor=pro.IDProveedor,
                                NombNegocio=pro.NombNegocio,
                                Direccion=pro.Direccion,
                                Telefono=pro.Telefono,
                                Correo=pro.Correo,
                                Fax=pro.Fax,
                                Municipio=pro.Municipio,
                                Departamento=pro.Departamento,
                                Imagen=pro.Imagen,
                                Estado=pro.Estado
                            }).ToList();
            return Consulta;
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
