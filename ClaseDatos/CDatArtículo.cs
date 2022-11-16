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
        BDLago_01Entities1 context = new BDLago_01Entities1();

        //List<CEntArtículo> articulo = new List<CEntArtículo>();


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
            art.Impuestos = nuevo.Impuestos;
            art.Existencia = nuevo.Existencia;
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
                            where art.Estado == true
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
                                Existencia=art.Existencia,
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
            art.Impuestos = nuevo.Impuestos;
            art.Existencia = nuevo.Existencia;
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
                            where art.Estado == true
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
                                Existencia = art.Existencia,
                                Imagen = art.Imagen,
                                IDProveedor = art.IDProveedor,
                                IDCategoria = art.IDCategoria,
                                Estado = art.Estado,

                                NombreProveedor = p.NombNegocio,
                                NombreCategoria = c.NombCategoria
                            }).Take(cant).ToList();
            return Consulta;
        }
        #endregion

        #region Muestra Artículo por ID
        public CEntArtículo MuestraArticuloxID(int id)
        {
            tblArticulo article = context.tblArticulo.FirstOrDefault(x => x.IDArticulos == id);


            CEntArtículo art = new CEntArtículo();

            if (article != null)
            {
                art.IDArticulos = article.IDArticulos;
                art.NombreArticulos = article.NombreArticulos;
                art.Descripcion = article.Descripcion;
                art.FechaIngreso = article.FechaIngreso;
                art.FechaVencimiento = article.FechaVencimiento;
                art.UnidadMedidas = article.UnidadMedidas;
                art.PrecioCompra = article.PrecioCompra;
                art.PrecioVenta = article.PrecioVenta;
                art.Impuestos = article.Impuestos;
                art.Existencia = article.Existencia;
                art.IDProveedor = article.IDProveedor;
                art.IDCategoria = article.IDCategoria;
                art.Estado = article.Estado;
            }

            return art;
        }
        #endregion

        #region Dar de Baja a un Artículo
        public bool BajaArticulo(int id)
        {
            tblArticulo art = context.tblArticulo.FirstOrDefault(x => x.IDArticulos == id);

            art.Estado = false;

            context.SaveChanges();

            return true;
        }
        #endregion

        #region Dar de Alta a un Artículo
        public bool AltaArticulo(int id)
        {
            tblArticulo art = context.tblArticulo.FirstOrDefault(x => x.IDArticulos == id);

            art.Estado = true;

            context.SaveChanges();

            return true;
        }
        #endregion

        #region Muestra Articulos Inactivos
        public List<CEntArtículo> MuestraArticulosInactivos()
        {
            var Consulta = (from art in context.tblArticulo
                            join p in context.tblProveedor on art.IDProveedor equals p.IDProveedor
                            join c in context.tblCategoria on art.IDCategoria equals c.IDCategoria
                            orderby art.IDArticulos descending
                            where art.Estado == false
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
                                Existencia = art.Existencia,
                                Imagen = art.Imagen,
                                IDProveedor = art.IDProveedor,
                                IDCategoria = art.IDCategoria,
                                Estado = art.Estado,

                                NombreProveedor = p.NombNegocio,
                                NombreCategoria = c.NombCategoria
                            }).ToList();

            return Consulta;
        }
        #endregion

        #region Muestra Articulos Activos por Nombre
        public List<CEntArtículo> ArticulosActivosxNombre(string nombre)
        {
            var Consulta = (from art in context.tblArticulo
                            join p in context.tblProveedor on art.IDProveedor equals p.IDProveedor
                            join c in context.tblCategoria on art.IDCategoria equals c.IDCategoria
                            orderby art.IDArticulos descending
                            where art.NombreArticulos.Contains(nombre)
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
                                Existencia = art.Existencia,
                                Imagen = art.Imagen,
                                IDProveedor = art.IDProveedor,
                                IDCategoria = art.IDCategoria,
                                Estado = art.Estado,

                                NombreProveedor = p.NombNegocio,
                                NombreCategoria = c.NombCategoria
                            }).ToList();

            return Consulta;
        }
        #endregion

        #region Muestra Articulos Inactivos por Nombre
        public List<CEntArtículo> ArticulosInactivosxNombre(string nombre)
        {
            var Consulta = (from art in context.tblArticulo
                            join p in context.tblProveedor on art.IDProveedor equals p.IDProveedor
                            join c in context.tblCategoria on art.IDCategoria equals c.IDCategoria
                            orderby art.IDArticulos descending
                            where art.NombreArticulos.Contains(nombre)
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
                                Existencia = art.Existencia,
                                Imagen = art.Imagen,
                                IDProveedor = art.IDProveedor,
                                IDCategoria = art.IDCategoria,
                                Estado = art.Estado,

                                NombreProveedor = p.NombNegocio,
                                NombreCategoria = c.NombCategoria
                            }).ToList();

            return Consulta;
        }
        #endregion

        #region Muestra articulo x ID para facturar
        public List<CEntArtículo> ArticuloxIDFactura(int id)
        {
            var consulta = (from a in context.tblArticulo
                            where a.IDArticulos==id
                            select new CEntArtículo
                            {
                                IDArticulos = a.IDArticulos,
                                NombreArticulos = a.NombreArticulos,
                                Descripcion = a.Descripcion,
                                FechaIngreso = a.FechaIngreso,
                                FechaVencimiento = a.FechaVencimiento,
                                UnidadMedidas = a.UnidadMedidas,
                                PrecioCompra = a.PrecioCompra,
                                PrecioVenta = a.PrecioVenta,
                                Impuestos = a.Impuestos,
                                Existencia = a.Existencia,
                                Imagen = a.Imagen,
                                IDProveedor = a.IDProveedor,
                                IDCategoria = a.IDCategoria,
                                Estado = a.Estado
                            }).ToList();

            return consulta;
        }
        #endregion

        #region Muestra Articulo para Factura
        public List<CEntArtículo> MuestraArticuloFactura(int id)
        {
            var consulta=(from art in context.tblArticulo
                          join p in context.tblProveedor on art.IDProveedor equals p.IDProveedor
                          join c in context.tblCategoria on art.IDCategoria equals c.IDCategoria
                          orderby art.IDArticulos descending
                          where art.Estado == true
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
                              Existencia = art.Existencia,
                              Imagen = art.Imagen,
                              IDProveedor = art.IDProveedor,
                              IDCategoria = art.IDCategoria,
                              Estado = art.Estado,

                              NombreProveedor = p.NombNegocio,
                              NombreCategoria = c.NombCategoria
                          }).ToList();
            return consulta;
        }
        #endregion
    }
}
