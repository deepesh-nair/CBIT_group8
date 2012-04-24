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
            Session["hasPvtAccess"] = false;
            if ((bool)Session["isLoggedIn"] == false)
                Response.Redirect("Login.aspx");
            //user = Request.QueryString["user"];
            user = Session["user"].ToString();

            string sql = "SELECT name FROM `user` WHERE email='" + user + "';";
            DataTable dt = _mysqlhandler.SelectFromDB(sql);
            lblName.Text = dt.Rows[0][0].ToString();

            //string datetimeformat = "MMM d yyyy at HH:mm ";

            //sql = "SELECT DISTINCT CBtitle, name, email, datetime FROM (SELECT * FROM pushpin  WHERE CBOwner IN (SELECT Follows FROM follow WHERE email = '"+user+"') OR CBOwner = '"+user+"' OR CBTitle IN (SELECT CBTitle FROM watchList WHERE WatcherEmail = '"+user+"')) AS R INNER JOIN user ON R.CBowner=user.email ORDER BY DateTime DESC LIMIT 4;";
            sql = "SELECT DISTINCT CBtitle, name, email, datetime FROM (SELECT description, CBtitle, name, email, datetime FROM ( SELECT * FROM ( SELECT * FROM pushpin WHERE CBOwner IN (SELECT Follows FROM follow WHERE email = '"+user+"' OR CBOwner = '"+user+"' OR CBTitle IN (SELECT CBTitle FROM watchList WHERE WatcherEmail = '"+user+"') AND CBOwner IN (SELECT CBOwner FROM watchList WHERE WatcherEmail = '"+user+"'))) AS R INNER JOIN user ON R.CBowner=user.email) AS T WHERE (CBowner, CBtitle) IN (SELECT owner AS CBowner, title AS CBtitle FROM publicCB WHERE TRUE) ) AS S ORDER BY datetime DESC LIMIT 4;";
            recentCB = _mysqlhandler.SelectFromDB(sql);
            //recentCB.Columns.Add();

            DataTable recentCBdatasrc = new DataTable();
            recentCBdatasrc.Columns.Add();
            recentCBdatasrc.Columns.Add();
            for (int i=0; i<recentCB.Rows.Count;i++)
            {
                recentCBdatasrc.Rows.Add();
                recentCBdatasrc.Rows[i][0] = recentCB.Rows[i][0].ToString()+"\n\n Updated by "+recentCB.Rows[i][1].ToString()+" on " + recentCB.Rows[i][3].ToString();
                sql = "SELECT * FROM publicCB WHERE owner='" + recentCB.Rows[i][2].ToString() + "' AND title='" + recentCB.Rows[i][0].ToString() + "';";
                if (_mysqlhandler.SelectFromDB(sql).Rows.Count > 0)
                {
                    recentCBdatasrc.Rows[i][1] = "(Public)";
                    //recentCB.Rows[i][4] = "(Public)";
                }
                else
                {
                    recentCBdatasrc.Rows[i][1] = "(Private)";
                    //recentCB.Rows[i][4] = "(Private)";
                }
            }
            gvRecentCB.DataSource = recentCBdatasrc;
            gvRecentCB.DataBind();

            DataTable myCBdatasrc = new DataTable();
            sql = "SELECT title FROM corkboard WHERE owner='" + user + "' ORDER BY title;";
            myCB = _mysqlhandler.SelectFromDB(sql);

            if (myCB.Rows.Count == 0)
                lblMyCB.Text = "You Have No Corkboard";

            myCB.Columns.Add();
            foreach (DataRow row in myCB.Rows)
            {
                sql = "SELECT link FROM pushpin WHERE CBowner='" + user + "' AND CBtitle='" + row[0].ToString() + "';";
                row[1] = _mysqlhandler.SelectFromDB(sql).Rows.Count;
            }

            //sql = "SELECT CBtitle, COUNT(*) FROM pushpin pp WHERE pp.CBowner='"+user+"' GROUP BY CBtitle ORDER BY CBtitle;";
            //myCB = _mysqlhandler.SelectFromDB(sql);
                
            myCBdatasrc.Columns.Add();
            myCBdatasrc.Columns.Add();
            for (int i = 0; i < myCB.Rows.Count; i++)
            {
                myCBdatasrc.Rows.Add();
                myCBdatasrc.Rows[i][0] = myCB.Rows[i][0].ToString() + "\n\n with " + myCB.Rows[i][1].ToString() + " PushPin(s)";
                sql = "SELECT * FROM publicCB WHERE owner='" + user + "' AND title='" + myCB.Rows[i][0].ToString() + "';";
                if (_mysqlhandler.SelectFromDB(sql).Rows.Count > 0)
                {
                    myCBdatasrc.Rows[i][1] = "(Public)";
                    //recentCB.Rows[i][4] = "(Public)";
                }
                else
                {
                    myCBdatasrc.Rows[i][1] = "(Private)";
                    //recentCB.Rows[i][4] = "(Private)";
                }
            }                                                
            gvMyCB.DataSource = myCBdatasrc;
            gvMyCB.DataBind();
        }

        protected void gvRecentCB_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.cursor='pointer'"); 
                //if(recentCB.Rows[e.Row.RowIndex][4] == "(Public)")
                    e.Row.Attributes.Add("onmousedown", "if(event.button==0){window.location='ViewCorkboard.aspx?CBowner="+recentCB.Rows[e.Row.RowIndex][2].ToString()+"&CBtitle="+recentCB.Rows[e.Row.RowIndex][0].ToString()+"'}");
                //else
                    //e.Row.Attributes.Add("onmousedown", "if(event.button==0){window.location='CheckPassword.aspx?CBowner=" + recentCB.Rows[e.Row.RowIndex][2].ToString() + "&CBtitle=" + recentCB.Rows[e.Row.RowIndex][0].ToString() + "'}");
            }
        }

        protected void gvMyCB_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.cursor='pointer'"); 
                e.Row.Attributes.Add("onmousedown", "if(event.button==0){window.location='ViewCorkboard.aspx?CBowner=" + user + "&CBtitle=" + myCB.Rows[e.Row.RowIndex][0].ToString() + "'}");
            
            }
        }

        protected void btnAddCB_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewCorkboard.aspx?");
        }

        protected void btnPopularTags_Click(object sender, EventArgs e)
        {
            Response.Redirect("PopularTags.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("PushpinSearch.aspx?keyword=" + txtSearch.Text);
        }
    }
}