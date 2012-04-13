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
    public partial class ViewCorkboard : System.Web.UI.Page
    {
        public string CBowner, Cbtitle;
        mysqlhandler _mysqlhandler = new mysqlhandler();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            CBowner = Request.QueryString["CBowner"];
            Cbtitle = Request.QueryString["Cbtitle"];

            //get owner's name
            string sql = "SELECT name FROM user WHERE email='"+CBowner+"';";
            lblName.Text = (_mysqlhandler.SelectFromDB(sql).Rows[0][0]).ToString();



        }
    }
}