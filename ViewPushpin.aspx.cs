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
    public partial class ViewPushpin : System.Web.UI.Page
    {
        public string CBowner, CBtitle, PPlink;
        mysqlhandler _mysqlhandler = new mysqlhandler();

        protected void Page_Load(object sender, EventArgs e)
        {
            CBowner = Request.QueryString["CBowner"];
            CBtitle = Request.QueryString["CBtitle"];
            PPlink = Request.QueryString["link"].Replace(" ","%20");

            //Get CBowner name
            string sql = "SELECT name FROM user WHERE email='" + CBowner + "';";
            lblName.Text = (_mysqlhandler.SelectFromDB(sql).Rows[0][0]).ToString();

            //Get Pushpin DateTime
            sql = "SELECT datetime FROM pushpin WHERE CBowner='"+CBowner+"' AND CBtitle='"+CBtitle+"' AND link='"+PPlink+"';";
            lblDateTime.Text = (_mysqlhandler.SelectFromDB(sql).Rows[0][0]).ToString();

            hlCbtitle.Text = CBtitle;
            hlCbtitle.NavigateUrl = "ViewCorkboard.aspx?CBowner="+CBowner+"&CBtitle="+CBtitle;

            hlImage.ImageUrl = PPlink;
            hlImage.NavigateUrl = PPlink;

            //get description
            sql = "SELECT description FROM pushpin WHERE CBowner='"+CBowner+"' AND CBtitle='"+CBtitle+"' AND link='"+PPlink+"';";
            lblDesc.Text = (_mysqlhandler.SelectFromDB(sql).Rows[0][0]).ToString();

            //get tags
            sql = "SELECT tag FROM tags WHERE CBowner = '"+CBowner+"' AND CBtitle = '"+CBtitle+"' AND link = '"+PPlink+"' ORDER BY tag;";
            DataTable dttags = _mysqlhandler.SelectFromDB(sql);
            lblTags.Text = getStringFromTable(dttags);

            //get Likes
            sql = "	SELECT u.name FROM likes l JOIN user u ON l.email = u.email WHERE l.CBowner = '"+CBowner+"' AND l.CBtitle = '"+CBtitle+"' AND l.link = '"+PPlink+"';";
            DataTable dtLikes = _mysqlhandler.SelectFromDB(sql);
            lblLikes.Text = getStringFromTable(dtLikes);

            //getComments
            sql = "SELECT c.comment, c.datetime, u.name FROM comments c JOIN user u ON u.email = c.email WHERE c.CBowner = '"+CBowner+"' AND c.CBtitle = '"+CBtitle+"' AND c.link = '"+PPlink+"' ORDER BY c.datetime DESC;";
            DataTable dtcomments = _mysqlhandler.SelectFromDB(sql);
            DataTable datasrc = new DataTable();
            datasrc.Columns.Add();
            datasrc.Columns.Add();

            for (int i = 0; i < dtcomments.Rows.Count; i++)
            {
                datasrc.Rows.Add();
                datasrc.Rows[i][0] = dtcomments.Rows[i][2];
                datasrc.Rows[i][1] = dtcomments.Rows[i][0];
            }
            gvComments.DataSource = datasrc;
            gvComments.DataBind();
        }

        string getStringFromTable(DataTable dt)
        {
            string csv = string.Empty;
            for (int i=0; i < dt.Rows.Count; i++)
            {
                csv = csv + dt.Rows[i][0].ToString();

                if (i != dt.Rows.Count - 1)
                    csv = csv + ", ";
            }
            return csv;
        }
    }
}