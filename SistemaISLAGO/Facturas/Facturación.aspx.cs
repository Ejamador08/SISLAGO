using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaEntidad;
using ClaseNegocio;

namespace SistemaISLAGO.Facturas
{
    public partial class Facturación : System.Web.UI.Page
    {
        List<CEntDetalleFacturaTMP> DetalleTemporal = new List<CEntDetalleFacturaTMP>();

        CEntDetalleFacturaTMP DetalleTmp = new CEntDetalleFacturaTMP();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MVFacturacion.ActiveViewIndex = 0;
                txtfecha.Text = DateTime.Now.ToShortDateString();
                txtcodigo.Text = string.Format("{0:FAC000000}", UltimaFactura());

                //GridTemporal(HttpContext.Current.User.Identity.Name);
                GridTemporal("elias08");
            }
        }

        #region Número de Factura
        public int UltimaFactura()
        {
            CNegFactura f = new CNegFactura();
            int NFact = f.UltimaFactura();
            return (NFact + 1);
        }

        #endregion

        protected void btnagreararticulofactura_Click(object sender, EventArgs e)
        {
            MVFacturacion.ActiveViewIndex = 1;
            CEntArtículo ent = new CEntArtículo();
            LlenaGridArticuloMV1(ent.IDArticulos);
        }

        #region Guarda Articulo Temporal previo a realizar Factura
        public void AgregaArticuloFacturaTMP()
        {
            var ent = new CEntDetalleFacturaTMP();
            var neg = new CNegFactura();

            if (int.Parse(txtExistencia.Text) < int.Parse(txtCantidad.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Advertencia!', 'No hay existencia para la cantidad deseada', 'warning');", true);
                txtCantidad.Text = "";
                txtCantidad.Focus();
            }
            else if (int.Parse(txtCantidad.Text) <= 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Advertencia!', 'No se aceptan numeros negativos', 'warning');", true);
                txtCantidad.Text = "";
                txtCantidad.Focus();
            }
            else
            {
                ent.IDFactura = int.Parse(HiddenFieldArticulo.Value);
                ent.PrecioVenta = Convert.ToSingle(txtprecio.Text);
                ent.Cantidad = int.Parse(txtCantidad.Text);
                ent.Garantia = txtgarantia.Text;

                if (CheckDescuento.Checked)
                {
                    ent.Descuento = ((int.Parse(txtprecio.Text) * int.Parse(txtCantidad.Text)) * (Convert.ToSingle(DropDescuento.SelectedValue)) / 100);
                }
                else
                {
                    ent.Descuento = 0;
                }
                float sub;

                sub = Convert.ToSingle(int.Parse(txtprecio.Text) * int.Parse(txtCantidad.Text) - (ent.Descuento));

                ent.Subtotal = sub;

                int stock = int.Parse(txtExistencia.Text) - int.Parse(txtCantidad.Text);

                txtExistencia.Text = stock.ToString();

                ent.Username = "elias08";

                neg.GuardaTMP(ent);
            }
        }
        #endregion

        #region Carga Grid Temporal
        public void GridTemporal(string user)
        {
            var neg = new CNegFactura();

            var art = neg.MuestraTemporal(user);

            txttotalventa.Text = art.Sum(sub => sub.Subtotal).ToString();
            txtdescapli.Text= string.Format("C$: {0:0.00}", art.Sum(sa => sa.Descuento)).ToString();

            foreach (var item in art)
            {
                DetalleTemporal.Add(item);
            }
            GridViewDetalle.DataSource = DetalleTemporal;
            GridViewDetalle.DataBind();
        }
        #endregion


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                return;
            }
            AgregaArticuloFacturaTMP();
            txtCantidad.Text = "";
            txttotalventa.Visible = true;
            btnCancelar.Visible = true;
            DetalleTmp.Username = "elias08";
            GridTemporal("elias08");
        }

        protected void GridViewArticuloFactura_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

                int indice = row.RowIndex;

                string codigo = "";

                try
                {
                    codigo = GridViewArticuloFactura.DataKeys[indice].Value.ToString();
                }
                catch (Exception)
                {
                    throw;
                }

                CNegArticulo art = new CNegArticulo();

                if (e.CommandName == "agregar")
                {
                    var lista = art.ArticuloxIDFactura(Convert.ToInt32(codigo));

                    foreach (var item in lista)
                    {
                        HiddenFieldArticulo.Value = item.IDArticulos.ToString();
                        txtarticulo.Text = item.NombreArticulos.ToString();
                        txtprecio.Text = item.PrecioVenta.ToString();
                        txtExistencia.Text = item.Existencia.ToString();
                    }
                    MVFacturacion.ActiveViewIndex = 0;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GridViewArticuloFactura_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerrow = GridViewArticuloFactura.BottomPagerRow;

                DropDownList pagelist = (DropDownList)pagerrow.Cells[0].FindControl("DropArticuloFactura");

                Label pagelabel = (Label)pagerrow.Cells[0].FindControl("lblfin");

                if (pagelist != null)
                {
                    for (int i = 0; i < GridViewArticuloFactura.PageCount - 1; i++)
                    {
                        int pagenumber = i + 1;

                        ListItem item = new ListItem(pagenumber.ToString());

                        if (i == GridViewArticuloFactura.PageIndex)
                        {
                            item.Selected = true;
                        }
                        pagelist.Items.Add(item);
                    }
                }
                if (pagelist != null)
                {
                    int currentpage = GridViewArticuloFactura.PageIndex + 1;

                    pagelabel.Text= "Página " + currentpage.ToString() + " de " + GridViewArticuloFactura.PageCount.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Llenar grid articulo para factura
        public void LlenaGridArticuloMV1(int id)
        {
            var neg = new CNegArticulo();
            GridViewArticuloFactura.DataSource = neg.MuestraArticuloFactura(id);
            GridViewArticuloFactura.DataBind();
        }
        #endregion

        protected void DropArticuloFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerrow = GridViewArticuloFactura.BottomPagerRow;

                DropDownList pagelist = (DropDownList)pagerrow.Cells[0].FindControl("DropArticuloFactura");

                GridViewArticuloFactura.PageIndex = pagelist.SelectedIndex;

                var ent = new CEntArtículo();

                LlenaGridArticuloMV1(ent.IDArticulos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnRealizarfactura_Click(object sender, EventArgs e)
        {

        }

        protected void CBDolar_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void txtdolarrecibido_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtcordobasrecibido_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GridViewDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            int indice = row.RowIndex;

            int codigo = Convert.ToInt32(GridViewDetalle.DataKeys[indice].Value);

            var neg = new CNegFactura();

            if (e.CommandName=="Eliminar")
            {
                bool rpta = neg.EliminaTemporal(codigo);
                if (rpta)
                {
                    GridTemporal("elias08");
                }
            }
            if (e.CommandName=="Disminuir")
            {
                int ctd = Convert.ToInt32(GridViewDetalle.Rows[indice].Cells[2].Text);

                TextBox restar = (TextBox)GridViewDetalle.Rows[indice].FindControl("txtdisminuir");

                int count = int.Parse(restar.Text);

                if (count >= ctd)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('No se puede disminuir');", true);
                }
                else
                {
                    var tmp = new CNegFactura();

                    tmp.Cantidad(count, codigo);

                    GridTemporal("elias08");
                }
            }
        }

        protected void GridViewDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType==DataControlRowType.DataRow)
                {
                    string ctd = e.Row.Cells[2].Text;

                    TextBox txt = (TextBox)e.Row.FindControl("txtdisminuir");

                    Button btn = (Button)e.Row.FindControl("btndisminuir");

                    if (Convert.ToInt32(ctd)==1)
                    {
                        btn.Enabled = false;
                        txt.Enabled = false;
                        e.Row.ToolTip = "No está permitido disminuir la cantidad de este artículo";
                    }
                    else
                    {
                        btn.Enabled = true;
                        txt.Enabled = true;
                        e.Row.ToolTip = "";
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}