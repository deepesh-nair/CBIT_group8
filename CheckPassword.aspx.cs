using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using MySQLHandler;
using System.Data;
using System.Web.UI.WebControls;

namespace CBIT_group8
{
    public partial class CheckPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM privateCB WHERE Owner = '" + Request.QueryString["CBowner"] + "' AND Title = '" + Request.QueryString["CBtitle"] + "' AND Password = '" + txtpass.Text + "';";
            mysqlhandler _mysqlhandler = new mysqlhandler();
            if (_mysqlhandler.SelectFromDB(sql).Rows.Count > 0)
            {
                Session["hasPvtAccess"] = true;
                Response.Redirect("ViewCorkboard.aspx?CBowner=" + Request.QueryString["CBowner"] + "&CBtitle=" + Request.QueryString["CBtitle"]);                
            }
            else
                lblResult.Text = "Incorrect Password. Please try again.";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }
    }
}