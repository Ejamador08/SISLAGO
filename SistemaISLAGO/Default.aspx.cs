using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

using CapaEntidad;
using ClaseNegocio;

namespace SistemaISLAGO
{
    public partial class _Default : Page
    {
        public void MuestraUltimosArticulos()
        {
            var art = new CNegArticulo();
            ListarArticulos.DataSource = art.MuestraXCantidad(4);
            ListarArticulos.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                MuestraUltimosArticulos();
            }
        }
    }
}