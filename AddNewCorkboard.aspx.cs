using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySQLHandler;
using System.Data;

namespace CBIT_group8
{
    
    public partial class AddNewCorkboard : System.Web.UI.Page
    {
        mysqlhandler _mysqlhandler = new mysqlhandler();

        protected void Page_Load(object sender, EventArgs e)
        {
            string sqlCategory = "SELECT name FROM category";
            DataTable result = _mysqlhandler.SelectFromDB(sqlCategory);
            foreach(DataRow r in result.Rows)
                ddlCategory.Items.Add(r[0].ToString());
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }

        protected void rbPrivate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrivate.Checked == true)
                txtPassword.Enabled = true;
        }

        protected void rbPublic_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPublic.Checked == true)
                txtPassword.Enabled = false;
        }
    }
}