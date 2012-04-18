using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySQLHandler;

//using MySql.Data;
//using MySql.Data.MySqlClient;
using System.Data;

namespace CBIT_group8
{
    public partial class Login : System.Web.UI.Page
    {
        mysqlhandler _mysqlhandler = new mysqlhandler();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["user"] = string.Empty;
            Session["isLoggedIn"] = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM user WHERE email ='"+txtEmail.Text+"' AND pin='"+txtPIN.Text+"';";
            DataTable result = _mysqlhandler.SelectFromDB(sql);

            if (result.Rows.Count > 0)
            {
                Session["user"] = txtEmail.Text;
                Session["isLoggedIn"] = true;
                Session["hasPvtAccess"] = false;
                Response.Redirect("Homepage.aspx");                
            }
            else
                lblResult.Text = "Login Failed! Please try again.";
        }
        
    }
}