using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

using CapaEntidad;

namespace ClaseDatos
{
    public class CDatFacturacion
    {
        BDLago_01Entities2 context = new BDLago_01Entities2();

        #region Última Factura
        public int UltimaFactura()
        {
            try
            {
                return context.tblFactura.Max(x => x.IDFactura);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        #region Actividades en tabla Temporal


        #region Muestra Grid Detalle Temporal Factura
        public List<CEntDetalleFacturaTMP> MuestraTemporal(string user)
        {
            List<CEntDetalleFacturaTMP> lista = new List<CEntDetalleFacturaTMP>();

            var consulta = (from dt in context.tblDetFacturaTMP
                            join a in context.tblArticulo on dt.IDArticulos equals a.IDArticulos
                            where dt.Username == user
                            orderby dt.IDDetFacturaTMP descending
                            select new CEntDetalleFacturaTMP
                            {
                                IDDetFacturaTMP = dt.IDDetFacturaTMP,
                                Cantidad = dt.Cantidad,
                                Subtotal = dt.Subtotal,
                                Total = dt.Total,
                                IDArticulos = dt.IDArticulos,
                                IDFactura = dt.IDFactura,
                                IDUsuario = dt.IDUsuario,
                                Estado = dt.Estado,
                                PrecioVenta = dt.PrecioVenta,
                                Descuento = dt.Descuento,
                                Garantia = dt.Garantia,
                                Username = dt.Username
                            }).ToList();
            foreach (var item in consulta)
            {
                lista.Add(new CEntDetalleFacturaTMP
                {
                    IDDetFacturaTMP = item.IDDetFacturaTMP,
                    Cantidad = item.Cantidad,
                    Subtotal = Convert.ToSingle(item.PrecioVenta * item.Cantidad) - item.Descuento,
                    Total = item.Total,
                    IDArticulos = item.IDArticulos,
                    IDFactura = item.IDFactura,
                    IDUsuario = item.IDUsuario,
                    Estado = item.Estado,
                    PrecioVenta = item.PrecioVenta,
                    Descuento = item.Descuento,
                    Garantia = item.Garantia,
                    Username = item.Username
                });
            }
            return lista;
        }
        #endregion

        #region Guarda Producto en la Tabla Temporal
        public bool GuardaTMP(CEntDetalleFacturaTMP tmp)
        {
            try
            {
                tblDetFacturaTMP detalle = new tblDetFacturaTMP();

                if (!context.tblDetFacturaTMP.Any(x => x.IDArticulos == tmp.IDArticulos))
                {
                    detalle.IDDetFacturaTMP = tmp.IDDetFacturaTMP;
                    detalle.Cantidad = tmp.Cantidad;
                    detalle.Subtotal = tmp.Subtotal;
                    detalle.Total = tmp.Total;
                    detalle.IDArticulos = tmp.IDArticulos;
                    detalle.IDFactura = tmp.IDFactura;
                    detalle.IDUsuario = tmp.IDUsuario;
                    detalle.Estado = tmp.Estado;
                    detalle.PrecioVenta = tmp.PrecioVenta;
                    detalle.Descuento = tmp.Descuento;
                    detalle.Garantia = tmp.Garantia;
                    detalle.Username = tmp.Username;

                    context.tblDetFacturaTMP.Add(detalle);
                }
                else
                {
                    detalle = context.tblDetFacturaTMP.FirstOrDefault(x => x.IDArticulos == tmp.IDArticulos);
                    detalle.PrecioVenta = tmp.PrecioVenta;
                    detalle.Cantidad = tmp.Cantidad;
                    detalle.Username = tmp.Username;
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Cantidad Articulos Temporales
        public bool Cantidad(int cant, int id)
        {
            tblDetFacturaTMP det = new tblDetFacturaTMP();

            det = context.tblDetFacturaTMP.FirstOrDefault(x => x.IDDetFacturaTMP == id);

            det.Cantidad = det.Cantidad - cant;

            context.SaveChanges();

            return true;
        }
        #endregion

        #region Elimina Articulo en la tblDetalleVtaTemp
        public bool EliminaTemporal(int id)
        {
            try
            {
                tblDetFacturaTMP tmp = context.tblDetFacturaTMP.FirstOrDefault(x => x.IDArticulos == id);

                context.tblDetFacturaTMP.Remove(tmp);

                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #endregion

        #region Realizar Factura Fisica
        public bool FacturarTransaccion(CEntFactura fact, string user)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    tblFactura vta = new tblFactura()
                    {
                        Fecha = fact.Fecha,
                        NombCompCliente = fact.NombCompCliente,
                        IDUsuario = fact.IDUsuario,
                        Total = fact.Total,

                        Anulada = fact.Anulada
                    };
                    context.tblFactura.Add(vta);
                    context.SaveChanges();

                    var detalletmp = context.tblDetFacturaTMP.Where(d => d.Username == user).ToList();

                    foreach (var item in detalletmp)
                    {
                        tblArticulo extraer = context.tblArticulo.Where(d => d.IDArticulos == item.IDArticulos).FirstOrDefault();
                        extraer.IDArticulos = extraer.IDArticulos;
                        extraer.PrecioCompra = extraer.PrecioCompra;
                        extraer.PrecioVenta = extraer.PrecioVenta;
                        extraer.Existencia = Convert.ToInt32(extraer.Existencia - item.Cantidad);
                    }

                    foreach (var tmp in detalletmp)
                    {
                        var final = new tblDetFactura
                        {
                            IDFactura = vta.IDFactura,
                            IDArticulos = Convert.ToInt32(tmp.IDArticulos),
                            PrecioVenta = tmp.PrecioVenta,
                            Cantidad = Convert.ToInt32(tmp.Cantidad),
                            Descuento = tmp.Descuento,
                            SubTotal = Convert.ToSingle(tmp.Subtotal),
                            Garantia = tmp.Garantia
                        };
                        context.tblDetFactura.Add(final);
                        context.tblDetFacturaTMP.Remove(tmp);

                        context.SaveChanges();
                    }
                    scope.Complete();
                    return true;
                }
                catch (Exception)
                {
                    scope.Dispose();
                    return false;
                }
            }
        }
        #endregion
    }
}
