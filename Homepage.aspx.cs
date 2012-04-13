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
    public partial class Homepage : System.Web.UI.Page
    {
        public string user;
        mysqlhandler _mysqlhandler = new mysqlhandler();
        DataTable recentCB = new DataTable();
        DataTable myCB = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["isLoggedIn"] == false)
                Response.Redirect("Login.aspx");
            //user = Request.QueryString["user"];
            user = Session["user"].ToString();

            string sql = "SELECT name FROM `user` WHERE email='" + user + "';";
            DataTable dt = _mysqlhandler.SelectFromDB(sql);
            lblName.Text = dt.Rows[0][0].ToString();

            sql = "SELECT DISTINCT CBtitle, name, email FROM (SELECT * FROM pushpin  WHERE CBOwner IN (SELECT Follows FROM follow WHERE email = '"+user+"') OR CBOwner = '"+user+"' OR CBTitle IN (SELECT CBTitle FROM watchList WHERE WatcherEmail = '"+user+"')) AS R INNER JOIN user ON R.CBowner=user.email ORDER BY DateTime DESC LIMIT 4;";
            recentCB = _mysqlhandler.SelectFromDB(sql);
            DataTable recentCBdatasrc = new DataTable();
            recentCBdatasrc.Columns.Add();
            for (int i=0; i<recentCB.Rows.Count;i++)
            {
                recentCBdatasrc.Rows.Add();
                recentCBdatasrc.Rows[i][0] = recentCB.Rows[i][0].ToString()+"\n\n Uploaded by "+recentCB.Rows[i][1].ToString();
            }
            gvRecentCB.DataSource = recentCBdatasrc;
            gvRecentCB.DataBind();

            sql = "SELECT CBtitle, COUNT(*) FROM pushpin pp WHERE pp.CBowner='"+user+"' GROUP BY CBtitle ORDER BY CBtitle;";
            myCB = _mysqlhandler.SelectFromDB(sql);
            DataTable myCBdatasrc = new DataTable();
            myCBdatasrc.Columns.Add();
            for (int i = 0; i < myCB.Rows.Count; i++)
            {
                myCBdatasrc.Rows.Add();
                myCBdatasrc.Rows[i][0] = myCB.Rows[i][0].ToString() + "\n\n with " + myCB.Rows[i][1].ToString()+" PushPin(s)";
            }
            gvMyCB.DataSource = myCBdatasrc;
            gvMyCB.DataBind();
        }

        protected void gvRecentCB_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmousedown", "if(event.button==0){window.location='ViewCorkboard.aspx?user="+recentCB.Rows[e.Row.RowIndex][2].ToString()+"&CBtitle="+recentCB.Rows[e.Row.RowIndex][0].ToString()+"'}");
            }
        }

        protected void gvMyCB_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmousedown", "if(event.button==0){window.location='ViewCorkboard.aspx?user=" + user + "&CBtitle=" + myCB.Rows[e.Row.RowIndex][0].ToString() + "'}");
            }
        }
    }
}