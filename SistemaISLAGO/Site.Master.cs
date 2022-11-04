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

namespace SistemaISLAGO
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get connection string from web.config file  
            //string strcon = ConfigurationManager.ConnectionStrings["BDLago_01Entities2"].ConnectionString;
            ////create new sqlconnection and connection to database by using connection string from web.config file  
            //SqlConnection con = new SqlConnection(strcon);
            //con.Open();

        }
    }
}