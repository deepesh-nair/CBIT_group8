using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using MySQLHandler;
using System.Data;


namespace CBIT_group8
{
    public partial class Homepage : System.Web.UI.Page
    {
        public string user;
        mysqlhandler _mysqlhandler = new mysqlhandler();

        protected void Page_Load(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];
            string sql = "SELECT name FROM `user` WHERE email='" + user + "';";
            DataTable dt = _mysqlhandler.SelectFromDB(sql);
            lblName.Text = dt.Rows[0][0].ToString();
        }
    }
}