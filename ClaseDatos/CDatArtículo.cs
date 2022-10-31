using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;

namespace ClaseDatos
{
    public class CDatArtículo
    {
        BDLago_01Entities2 context = new BDLago_01Entities2();

        List<CEntArtículo> articulo = new List<CEntArtículo>();


        #region C >> Create >> Insertar
        public bool GuardaNuevoArticulo(CEntArtículo nuevo)
        {
            tblArticulo art = new tblArticulo();

            art.IDArticulos = nuevo.IDArticulos;
            art.NombreArticulos = nuevo.NombreArticulos;
            art.Descripcion = nuevo.Descripcion;
            art.FechaIngreso = nuevo.FechaIngreso;
            art.FechaVencimiento = nuevo.FechaVencimiento;
            art.UnidadMedidas = nuevo.UnidadMedidas;
            art.PrecioCompra = nuevo.PrecioCompra;
            art.PrecioVenta = nuevo.PrecioVenta;
            art.Imagen = nuevo.Imagen;
            art.IDProveedor = nuevo.IDProveedor;
            art.IDCategoria = nuevo.IDCategoria;
            art.Estado = nuevo.Estado;

            context.tblArticulo.Add(art);
            context.SaveChanges();

            return true;
        }
        #endregion

        #region R >> Read >> Seleccionar
        public List<CEntArtículo> MuestraArticulos()
        {
            var Consulta = (from art in context.tblArticulo
                            join p in context.tblProveedor on art.IDProveedor equals p.IDProveedor
                            join c in context.tblCategoria on art.IDCategoria equals c.IDCategoria
                            orderby art.IDArticulos descending
                            where art.Estado.Equals("A")
                            select new CEntArtículo
                            {
                                IDArticulos=art.IDArticulos,
                                NombreArticulos=art.NombreArticulos,
                                Descripcion=art.Descripcion,
                                FechaIngreso=art.FechaIngreso,
                                FechaVencimiento=art.FechaVencimiento,
                                UnidadMedidas=art.UnidadMedidas,
                                PrecioCompra=art.PrecioCompra,
                                PrecioVenta=art.PrecioVenta,
                                Impuestos=art.Impuestos,
                                Imagen=art.Imagen,
                                IDProveedor=art.IDProveedor,
                                IDCategoria=art.IDCategoria,
                                Estado=art.Estado,

                                NombreProveedor=p.NombNegocio,
                                NombreCategoria=c.NombCategoria
                            }).ToList();

            return Consulta;
        }
        #endregion

        #region U >> Update >> Actualizar
        public bool ActualizaArticulo(CEntArtículo nuevo)
        {
            tblArticulo art = context.tblArticulo.FirstOrDefault(x => x.IDArticulos == nuevo.IDArticulos);

            art.IDArticulos = nuevo.IDArticulos;
            art.NombreArticulos = nuevo.NombreArticulos;
            art.Descripcion = nuevo.Descripcion;
            art.FechaIngreso = nuevo.FechaIngreso;
            art.FechaVencimiento = nuevo.FechaVencimiento;
            art.UnidadMedidas = nuevo.UnidadMedidas;
            art.PrecioCompra = nuevo.PrecioCompra;
            art.PrecioVenta = nuevo.PrecioVenta;
            art.Imagen = nuevo.Imagen;
            art.IDProveedor = nuevo.IDProveedor;
            art.IDCategoria = nuevo.IDCategoria;
            art.Estado = nuevo.Estado;

            context.SaveChanges();

            return true;
        }
        #endregion

        #region D >> Delete >> Eliminar
        public bool EliminaArticulo(int id)
        {
            tblArticulo art = context.tblArticulo.FirstOrDefault(x => x.IDArticulos == id);

            context.tblArticulo.Remove(art);
            context.SaveChanges();

            return true;
        }
        #endregion

        #region Muestra X cantidad de Artículos
        public List<CEntArtículo> MuestraXCantidad(int cant)
        {
            var Consulta = (from art in context.tblArticulo
                            join p in context.tblProveedor on art.IDProveedor equals p.IDProveedor
                            join c in context.tblCategoria on art.IDCategoria equals c.IDCategoria
                            where art.Estado.Equals("A")
                            orderby art.IDArticulos descending
                            select new CEntArtículo
                            {
                                IDArticulos = art.IDArticulos,
                                NombreArticulos = art.NombreArticulos,
                                Descripcion = art.Descripcion,
                                FechaIngreso = art.FechaIngreso,
                                FechaVencimiento = art.FechaVencimiento,
                                UnidadMedidas = art.UnidadMedidas,
                                PrecioCompra = art.PrecioCompra,
                                PrecioVenta = art.PrecioVenta,
                                Impuestos = art.Impuestos,
                                Imagen=art.Imagen,
                                IDProveedor = art.IDProveedor,
                                IDCategoria = art.IDCategoria,
                                Estado = art.Estado,

                                NombreProveedor = p.NombNegocio,
                                NombreCategoria = c.NombCategoria
                            }).Take(cant).ToList();
            return Consulta;
        }
        #endregion
    }
}
