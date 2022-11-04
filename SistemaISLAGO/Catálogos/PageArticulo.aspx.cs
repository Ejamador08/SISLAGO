using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaEntidad;
using ClaseNegocio;
using System.IO;

namespace SistemaISLAGO.Catálogos
{
    public partial class PageArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MVArticulo.ActiveViewIndex = 0;
                LlenarGridListadoPrincipal();
                CIngreso.Visible = false;
                CVencimiento.Visible = false;
                LlenaCategorias();
                LlenaProveedores();
            }
        }

        /*
         * MÉTODOS
        */
        public void LlenarGridListadoPrincipal()
        {
            var grilla = new CNegArticulo();
            GridViewArticulo.DataSource = grilla.MuestraArticulos();
            GridViewArticulo.DataBind();
        }

        protected void DropArto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvr = GridViewArticulo.BottomPagerRow;
                DropDownList pagelist = (DropDownList)gvr.Cells[0].FindControl("DropArto");
                GridViewArticulo.PageIndex = pagelist.SelectedIndex;
                LlenarGridListadoPrincipal();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void GridViewArticulo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //defino la variable row para conocer el control tipo boton en la fila
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            //Se obtiene e indice de la fila en donde dimos click
            int indice = row.RowIndex;
            //Obtenemos el valor del campo de la tabla (ID) de donde dimos click
            int codigo = Convert.ToInt32(GridViewArticulo.DataKeys[indice].Value);

            CEntArtículo entarticle = new CEntArtículo();
            CNegArticulo negarticle = new CNegArticulo();

            if (e.CommandName== "cmdEditar")
            {
                entarticle = negarticle.MuestraArticuloxID(codigo);

                txtCodigo.Text = entarticle.IDArticulos.ToString();
                txtNombre.Text = entarticle.NombreArticulos;
                txtdescripcion.Text = entarticle.Descripcion;
                txtfingreso.Text = entarticle.FechaIngreso.ToString();
                txtfvencimiento.Text = entarticle.FechaVencimiento.ToString();
                txtmedida.Text = entarticle.UnidadMedidas;
                txtpcompra.Text = entarticle.PrecioCompra.ToString();
                txtpventa.Text = entarticle.PrecioVenta.ToString();
                txtimpuesto.Text = entarticle.Impuestos.ToString();
                DropProveedor.SelectedValue = entarticle.IDProveedor.ToString();
                DropCategoria.SelectedValue = entarticle.IDCategoria.ToString();
                HiddenField1.Value = entarticle.Imagen;
                Preview.ImageUrl = HiddenField1.Value;
                chkEstado.Checked = Convert.ToBoolean(entarticle.Estado);

                MVArticulo.ActiveViewIndex = 1;

                btnGuardar.Enabled = false;
                btnGuardar.Visible = false;

                btnActualizar.Enabled = true;
                btnActualizar.Visible = true;

                btncanactu.Enabled = true;
                btncanactu.Visible = true;
            }
            if (e.CommandName=="cmdEliminar")
            {
                negarticle.BajaArticulo(codigo);

                LlenarGridListadoPrincipal();
            }
        }        

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            MVArticulo.ActiveViewIndex = 1;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MVArticulo.ActiveViewIndex = 0;
        }

        #region Acciones botones nuevo articulo
        public void LimpiaControles()
        {
            txtNombre.Text = string.Empty;
            txtdescripcion.Text = string.Empty;
            txtfingreso.Text = string.Empty;
            txtfvencimiento.Text = string.Empty;
            txtmedida.Text = string.Empty;
            txtpcompra.Text = string.Empty;
            txtpventa.Text = string.Empty;
            txtimpuesto.Text = string.Empty;
        }
        #endregion

        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            MVArticulo.ActiveViewIndex = 1;
            btnActualizar.Visible = false;
            btncanactu.Visible = false;
            btnGuardar.Visible = true;
            btnGuardar.Enabled = true;
            LimpiaControles();
        }

        protected void btnIrlista_Click(object sender, EventArgs e)
        {
            MVArticulo.ActiveViewIndex = 0;
        }

        protected void ImgCalendario_Click(object sender, ImageClickEventArgs e)
        {
            if (CIngreso.Visible==false)
            {
                CIngreso.Visible = true;
            }
            else
            {
                CIngreso.Visible = false;
            }
        }

        protected void CIngreso_SelectionChanged(object sender, EventArgs e)
        {
            txtfingreso.Text = CIngreso.SelectedDate.ToString();
            CIngreso.Visible = false;
        }

        protected void imgfvencim_Click(object sender, ImageClickEventArgs e)
        {
            if (CVencimiento.Visible == false)
            {
                CVencimiento.Visible = true;
            }
            else
            {
                CVencimiento.Visible = false;
            }
        }

        protected void CVencimiento_SelectionChanged(object sender, EventArgs e)
        {
            txtfvencimiento.Text = CVencimiento.SelectedDate.ToString();
            CVencimiento.Visible = false;
        }

        #region Métodos para Guardar Registros

        #region Guardar Ruta de la imagen
        public string RutaImagen()
        {
            //Declaración de Variables
            bool fileOK = false;
            string Rpta = "";
            string ruta = Server.MapPath("~/Content/img/Artículos/");

            //evento TRY...CATCH
            try
            {
                if (FileUploadArticulo.HasFile)
                {
                    string Extension= Path.GetExtension(FileUploadArticulo.FileName).ToLower();
                    string[] ExtValida = { ".jpg", ".png", ".gif", ".jpeg" };

                    //ciclo for
                    for (int i = 0; i < ExtValida.Length; i++)
                    {
                        if (Extension==ExtValida[i])
                        {
                            fileOK = true;
                        }
                        if (fileOK)
                        {
                            string NombreImg = FileUploadArticulo.FileName.ToString();
                            FileUploadArticulo.PostedFile.SaveAs(ruta + NombreImg);
                            HiddenField1.Value = "/Content/img/Artículos/" + NombreImg;
                            Rpta = "Subida con éxito";
                        }
                        else
                        {
                            HiddenField1.Value = "/Content/img/Artículos/ArticleDefault.png";
                            Rpta = "Eror al Guardar la Imagen";
                        }
                    }
                }
                else
                {
                    HiddenField1.Value = "/Content/img/Artículos/ArticleDefault.png";
                    Rpta = "Eror al Guardar la Imagen";
                }
                return Rpta;
            }
            catch (Exception)
            {

                return Rpta;
            }
        }
        #endregion

        #region Guarda Nuevo Artículo
        public bool GuardarNuevoArticulo()
        {
            bool Rpta;

            CEntArtículo article = new CEntArtículo();

            article.NombreArticulos = txtNombre.Text.Trim();
            article.Descripcion = txtdescripcion.Text.Trim();
            article.FechaIngreso = Convert.ToDateTime(txtfingreso.Text.Trim());
            article.FechaVencimiento = Convert.ToDateTime(txtfvencimiento.Text.Trim());
            article.UnidadMedidas = txtmedida.Text.Trim();
            article.PrecioCompra = Convert.ToSingle(txtpcompra.Text.Trim());
            article.PrecioVenta = Convert.ToSingle(txtpventa.Text.Trim());
            article.Impuestos = Convert.ToSingle(txtimpuesto.Text.Trim());
            article.IDProveedor = Convert.ToInt32(DropProveedor.SelectedValue);
            article.IDCategoria = Convert.ToInt32(DropCategoria.SelectedValue);
            RutaImagen();
            article.Imagen = HiddenField1.Value;
            article.Estado = chkEstado.Checked;

            CNegArticulo g = new CNegArticulo();

            Rpta = g.GuardaNuevoArticulo(article);
            return Rpta;
        }
        #endregion

        #region Llena DropBox para las Categorias
        public void LlenaCategorias()
        {
            var cat = new CNegCategoria();
            DropCategoria.DataSource = cat.MuestraCategoria();
            DropCategoria.DataValueField = "IDCategoria";
            DropCategoria.DataTextField = "NombCategoria";
            DropCategoria.DataBind();
        }

        #endregion

        #region Llena DropBox para los Proveedores
        public void LlenaProveedores()
        {
            var pro = new CNegProveedor();
            DropProveedor.DataSource = pro.MuestraProveedor();
            DropProveedor.DataValueField = "IDProveedor";
            DropProveedor.DataTextField = "NombNegocio";
            DropProveedor.DataBind();
        }
        #endregion

        #endregion

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            MVArticulo.ActiveViewIndex = 0;
            if (GuardarNuevoArticulo())
            {
                LlenarGridListadoPrincipal();
                txtBuscar.Text = "";
                RutaImagen();
            }
        }

        protected void DropArto_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerrow = GridViewArticulo.BottomPagerRow;

                DropDownList pagelist = (DropDownList)pagerrow.Cells[0].FindControl("DropArto");

                GridViewArticulo.PageIndex = pagelist.SelectedIndex;

                LlenarGridListadoPrincipal();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GridViewArticulo_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerow = GridViewArticulo.BottomPagerRow;

                DropDownList pagelist = (DropDownList)pagerow.Cells[0].FindControl("DropArto");

                Label pagelabel = (Label)pagerow.Cells[0].FindControl("lblArtoPageOf");

                if (pagelist != null)
                {
                    for (int i = 0; i <= GridViewArticulo.PageCount - 1; i++)
                    {
                        int pagenum = i + 1;

                        ListItem item = new ListItem(pagenum.ToString());

                        if (i==GridViewArticulo.PageIndex)
                        {
                            item.Selected = true;
                        }
                        pagelist.Items.Add(item);
                    }
                }
                if (pagelabel != null)
                {
                    int currentpage = GridViewArticulo.PageIndex + 1;

                    pagelabel.Text = "Página " + currentpage.ToString() + " de " + GridViewArticulo.PageCount.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Metodo que permite la Actualización de Registros
        public bool ActualizaArticulo()
        {
            var art = new CEntArtículo();

            art.IDArticulos = Convert.ToInt32(txtCodigo.Text);
            art.NombreArticulos = txtNombre.Text;
            art.Descripcion = txtdescripcion.Text;
            art.FechaIngreso = Convert.ToDateTime(txtfingreso.Text);
            art.FechaVencimiento = Convert.ToDateTime(txtfvencimiento.Text);
            art.UnidadMedidas = txtmedida.Text;
            art.PrecioCompra = Convert.ToSingle(txtpcompra.Text);
            art.PrecioVenta = Convert.ToSingle(txtpventa.Text);
            art.Impuestos = Convert.ToSingle(txtimpuesto.Text);
            art.IDProveedor = Convert.ToInt32(DropProveedor.Text);
            art.IDCategoria = Convert.ToInt32(DropCategoria.Text);
            RutaImagen();
            art.Imagen = HiddenField1.Value;
            art.Estado = chkEstado.Checked;

            var actualiza = new CNegArticulo();

            bool Rpta = actualiza.ActualizaArticulo(art);

            return Rpta;
        }
        #endregion

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            MVArticulo.ActiveViewIndex = 0;

            if (ActualizaArticulo())
            {
                LlenarGridListadoPrincipal();
                txtBuscar.Text = string.Empty;
                RutaImagen();
            }
            LimpiaControles();
        }

        protected void btncanactu_Click(object sender, EventArgs e)
        {
            LimpiaControles();
            MVArticulo.ActiveViewIndex = 0;
            txtBuscar.Text = string.Empty;
            btnActualizar.Visible = false;
            btncanactu.Visible = false;
            btnGuardar.Visible = true;
        }

        protected void btnactivos_Click(object sender, EventArgs e)
        {
            MVArticulo.ActiveViewIndex = 0;
            LlenarGridListadoPrincipal();
        }

        protected void btnnew_Click(object sender, EventArgs e)
        {
            MVArticulo.ActiveViewIndex = 1;
            btnActualizar.Visible = false;
            btncanactu.Visible = false;
            btnGuardar.Visible = true;
            btnGuardar.Enabled = true;
            LimpiaControles();
        }

        protected void btninactivos_Click(object sender, EventArgs e)
        {
            MVArticulo.ActiveViewIndex = 2;
            LlenaGridInactivos();
        }

        #region Buscar Articulos Inactivos
        public void BuscaArticulosInactivos(string nombre)
        {
            var neg = new CNegArticulo();

            GvInactivos.DataSource = neg.ArticulosInactivosxNombre(nombre);

            GvInactivos.DataBind();
        }
        #endregion

        protected void btnbuscainactivos_Click(object sender, EventArgs e)
        {
            BuscaArticulosInactivos(txtbuscainactivos.Text.Trim());
        }

        #region Llena las Grid con los Articulos Inactivos
        public void LlenaGridInactivos()
        {
            var neg = new CNegArticulo();

            GvInactivos.DataSource = neg.MuestraArticulosInactivos();
            GvInactivos.DataBind();
        }
        #endregion

        protected void GvInactivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row=(GridViewRow)(((Button)e.CommandSource).NamingContainer);

            int indice = row.RowIndex;

            int codigo = Convert.ToInt32(GvInactivos.DataKeys[indice].Value);

            CEntArtículo ent = new CEntArtículo();

            CNegArticulo neg = new CNegArticulo();

            if (e.CommandName == "cmdrestaurar")
            {
                neg.AltaArticulo(codigo);
                LlenaGridInactivos();
            }
        }

        protected void GvInactivos_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GvInactivos.BottomPagerRow;
                
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("dropinactivos");

                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("lblfininactivos");

                if (pageList != null)
                {
                    for (int i = 0; i < GvInactivos.PageCount - 1; i++)
                    {
                        int pagenum = i + 1;

                        ListItem item = new ListItem(pagenum.ToString());

                        if (i == GvInactivos.PageIndex)
                        {
                            item.Selected = true;
                        }
                        pageList.Items.Add(item);
                    }
                }
                if (pageList != null)
                {
                    int currentpage = GvInactivos.PageIndex + 1;

                    pageLabel.Text = "Página " + currentpage.ToString() + " de " + GvInactivos.PageCount.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void dropinactivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GvInactivos.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("dropinactivos");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GvInactivos.PageIndex = pageList.SelectedIndex;
                //------------------------------
                LlenaGridInactivos();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        #region Buscar Articulos Inactivos
        public void BuscaArticulosActivos(string nombre)
        {
            var neg = new CNegArticulo();

            GridViewArticulo.DataSource = neg.ArticulosActivosxNombre(nombre);

            GridViewArticulo.DataBind();
        }
        #endregion

        protected void btnBuscarActivos_Click(object sender, EventArgs e)
        {
            BuscaArticulosActivos(txtBuscar.Text.Trim());
        }
    }
}