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

            //get CBowner's name
            string sql = "SELECT name FROM user WHERE email='"+CBowner+"';";
            lblName.Text = (_mysqlhandler.SelectFromDB(sql).Rows[0][0]).ToString();

            //get  CB category
            sql = "SELECT category from corkboard WHERE owner='"+CBowner+"' and title='"+Cbtitle+"';";
            lblCategory.Text = (_mysqlhandler.SelectFromDB(sql).Rows[0][0]).ToString();

            lblCBtitle.Text = Cbtitle;

            sql = "SELECT datetime from pushpin WHERE CBowner='"+CBowner+"' AND CBtitle='"+Cbtitle+"' ORDER BY datetime DESC LIMIT 1;";
            lblDateTime.Text = (_mysqlhandler.SelectFromDB(sql).Rows[0][0]).ToString();

            sql = "SELECT link FROM pushpin WHERE CBowner='" + CBowner + "' AND CBtitle='" + Cbtitle + "';";
            DataTable links = _mysqlhandler.SelectFromDB(sql);

            for (int i = 0; i < links.Rows.Count; i++)
            {
                HyperLink dynamicimage = new HyperLink();
                dynamicimage.ImageUrl = links.Rows[i][0].ToString();
                dynamicimage.NavigateUrl = "ViewPushpin.aspx?CBowner=" + CBowner + "&Cbtitle=" + Cbtitle + "&link=" + links.Rows[i][0].ToString();
                dynamicimage.Text = "Dead Image URL :x";
                phImageHolder.Controls.Add(dynamicimage);
            }

            sql="SELECT COUNT(*) FROM watchList WHERE CBowner='"+CBowner+"' AND CBtitle='"+Cbtitle+"';";
            lblWatchers.Text = (_mysqlhandler.SelectFromDB(sql).Rows[0][0]).ToString();

            if (CBowner == Session["user"].ToString())
                btnWatch.Enabled = false;
        }
    }
}