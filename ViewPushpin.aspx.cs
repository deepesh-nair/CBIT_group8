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
        public string CBowner, CBtitle, PPlink, user;
        mysqlhandler _mysqlhandler = new mysqlhandler();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            user = Session["user"].ToString();
            CBowner = Request.QueryString["CBowner"];
            CBtitle = Request.QueryString["CBtitle"];
            PPlink = Request.QueryString["link"].Replace(" ", "%20");

            if (!IsPostBack)
            {
                //Get CBowner name
                string sql = "SELECT name FROM user WHERE email='" + CBowner + "';";
                lblName.Text = (_mysqlhandler.SelectFromDB(sql).Rows[0][0]).ToString();

                // Determine if the user is already following the CorkBoard owner
                sql = "SELECT * FROM follow WHERE email = '" + user + "' AND follows = '" + CBowner + "';";
                DataTable resultFollow = _mysqlhandler.SelectFromDB(sql);

                // If he is, then disable the Follow button and make it read Following 
                if (resultFollow.Rows.Count > 0)
                {
                    btnFollow.Text = "Following";
                    btnFollow.Enabled = false;
                }

                //Get Pushpin DateTime
                sql = "SELECT datetime FROM pushpin WHERE CBowner='" + CBowner + "' AND CBtitle='" + CBtitle + "' AND link='" + PPlink + "';";
                lblDateTime.Text = (_mysqlhandler.SelectFromDB(sql).Rows[0][0]).ToString();

                hlCbtitle.Text = CBtitle;
                hlCbtitle.NavigateUrl = "ViewCorkboard.aspx?CBowner=" + CBowner + "&CBtitle=" + CBtitle;

                hlImage.ImageUrl = PPlink;
                hlImage.NavigateUrl = PPlink;

                //get description
                sql = "SELECT description FROM pushpin WHERE CBowner='" + CBowner + "' AND CBtitle='" + CBtitle + "' AND link='" + PPlink + "';";
                lblDesc.Text = (_mysqlhandler.SelectFromDB(sql).Rows[0][0]).ToString();

                //get tags
                sql = "SELECT tag FROM tags WHERE CBowner = '" + CBowner + "' AND CBtitle = '" + CBtitle + "' AND link = '" + PPlink + "' ORDER BY tag;";
                DataTable dttags = _mysqlhandler.SelectFromDB(sql);
                lblTags.Text = getStringFromTable(dttags);

                getLikes();

                getComments();
            }
        }

        void getLikes()
        {
            //Check if user and CBowner are same
            if(user==CBowner)          
                btnLike.Enabled = false;            
            
            //check if user already Likes this PP
            string sql = "SELECT * FROM likes l WHERE l.email='" + user + "' AND l.CBowner = '" + CBowner + "' AND l.CBtitle = '" + CBtitle + "' AND l.link = '" + PPlink + "';";
            if ((_mysqlhandler.SelectFromDB(sql).Rows.Count > 0))
                btnLike.Text = "Unlike";
            else
                btnLike.Text = "Like";

            //get Likes
            sql = "	SELECT u.name FROM likes l JOIN user u ON l.email = u.email WHERE l.CBowner = '" + CBowner + "' AND l.CBtitle = '" + CBtitle + "' AND l.link = '" + PPlink + "';";
            DataTable dtLikes = _mysqlhandler.SelectFromDB(sql);
            lblLikes.Text = getStringFromTable(dtLikes);
        }

        void getComments()
        {
            txtComment.Text = string.Empty;
            //getComments
            string sql = "SELECT c.comment, c.datetime, u.name FROM comments c JOIN user u ON u.email = c.email WHERE c.CBowner = '" + CBowner + "' AND c.CBtitle = '" + CBtitle + "' AND c.link = '" + PPlink + "' ORDER BY c.datetime DESC;";
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

        protected void btnComment_Click(object sender, EventArgs e)
        {           
            string datetimeFormat = "yyyy-MM-dd HH:mm:ss";
            string sql = "INSERT INTO  `comments` (email ,CBowner ,CBtitle ,link,datetime,comment) VALUES ('"+user+"',  '"+CBowner+"',  '"+CBtitle+"', '"+PPlink+"', '"+DateTime.Now.ToString(datetimeFormat)+"', '"+txtComment.Text+"');";
            _mysqlhandler.InsertIntoDB(sql);
            getComments();

        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            if (btnLike.Text == "Like")
                sql = "INSERT INTO  likes (email ,CBowner ,CBtitle ,link) VALUES ('" + user + "',  '" + CBowner + "',  '" + CBtitle + "', '" + PPlink + "');";
            else
                sql = "DELETE FROM likes WHERE email='" + user + "' AND CBowner = '" + CBowner + "' AND CBtitle = '" + CBtitle + "' AND link = '" + PPlink + "';";
            _mysqlhandler.InsertIntoDB(sql);
            getLikes();
        }

        protected void btnFollow_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO follow (email, follows) VALUES ('" + user
                 + "','" + CBowner + "');";
            _mysqlhandler.InsertIntoDB(sql);

            // disable the Follow button and make it read Following
            btnFollow.Text = "Following";
            btnFollow.Enabled = false;
        }


    }
}