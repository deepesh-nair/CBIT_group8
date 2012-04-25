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
        public string CBowner, Cbtitle, user;
        mysqlhandler _mysqlhandler = new mysqlhandler();
        
        protected void Page_Load(object sender, EventArgs e)
        {
                       
            user = Session["user"].ToString();
            CBowner = Request.QueryString["CBowner"];
            Cbtitle = Request.QueryString["Cbtitle"];

            if(!IsPostBack)
            {
                CheckForPrivateCB();

                //btnAddPp.CssClass = ".imagemargin";

                //get CBowner's name
                string sql = "SELECT name FROM user WHERE email='"+CBowner+"';";
                lblName.Text = (_mysqlhandler.SelectFromDB(sql).Rows[0][0]).ToString();

                //get  CB category
                sql = "SELECT category from corkboard WHERE owner='"+CBowner+"' and title='"+Cbtitle+"';";
                lblCategory.Text = (_mysqlhandler.SelectFromDB(sql).Rows[0][0]).ToString();

                lblCBtitle.Text = Cbtitle;            

                //Check if user and CBowner is same 
                if (user == CBowner)
                {
                    btnAddPp.Enabled = true;
                    btnWatch.Enabled = false;
                    btnFollow.Enabled = false;
                }
                else
                {
                    btnAddPp.Enabled = false;
                    //btnWatch.Enabled = true;
                   // btnFollow.Enabled = true;
                }

                // Determine if the user is already following the CorkBoard owner
                sql = "SELECT * FROM follow WHERE email = '" + user + "' AND follows = '" + CBowner + "';";
                DataTable resultFollow = _mysqlhandler.SelectFromDB(sql);
            
                // If he is, then disable the Follow button and make it read Following 
                if (resultFollow.Rows.Count > 0)
                {
                    btnFollow.Text = "Following";
                    btnFollow.Enabled = false;
                }

                // Determine if the user is already watching the CorkBoard 
                sql = "SELECT * FROM watchList WHERE watcherEmail = '" + user + "' AND CBowner = '" + CBowner + 
                    "' AND Cbtitle = '" + Cbtitle + "';";
                DataTable resultWatch = _mysqlhandler.SelectFromDB(sql);
            
                // If he is, then disable the Watch button and make it read watching 
                if (resultWatch.Rows.Count > 0)
                {
                    btnWatch.Text = "Watching";
                    btnWatch.Enabled = false;
                }

                //get number of watchers
                sql = "SELECT COUNT(*) FROM watchList WHERE CBowner='" + CBowner + "' AND CBtitle='" + Cbtitle + "';";
                lblWatchers.Text = (_mysqlhandler.SelectFromDB(sql).Rows[0][0]).ToString();

                //if (CBowner == Session["user"].ToString())
                    //btnWatch.Enabled = false;
            
                //next funxtions require at least one pushpin on CB, so check for this condition
                sql = "SELECT COUNT(*) FROM pushpin WHERE CBowner='" + CBowner + "' AND CBtitle='" + Cbtitle + "' GROUP BY CBtitle;";
                if (_mysqlhandler.SelectFromDB(sql).Rows.Count > 0)
                {
                    //get datetime of last update
                    sql = "SELECT datetime from pushpin WHERE CBowner='" + CBowner + "' AND CBtitle='" + Cbtitle + "' ORDER BY datetime DESC LIMIT 1;";
                    lblDateTime.Text = (_mysqlhandler.SelectFromDB(sql).Rows[0][0]).ToString();

                    //get all pushpin links
                    sql = "SELECT link FROM pushpin WHERE CBowner='" + CBowner + "' AND CBtitle='" + Cbtitle + "';";
                    DataTable links = _mysqlhandler.SelectFromDB(sql);

                    for (int i = 0; i < links.Rows.Count; i++)
                    {
                        /*HyperLink dynamicimage = new HyperLink();
                        dynamicimage.ImageUrl = links.Rows[i][0].ToString();                        
                        dynamicimage.NavigateUrl = "ViewPushpin.aspx?CBowner=" + CBowner + "&Cbtitle=" + Cbtitle + "&link=" + links.Rows[i][0].ToString();
                        dynamicimage.Text = "Dead Image URL :x";
                        dynamicimage.CssClass = "image";*/

                        ImageButton dynamicimage = new ImageButton();
                        dynamicimage.ImageUrl = links.Rows[i][0].ToString();
                        dynamicimage.PostBackUrl = "ViewPushpin.aspx?CBowner=" + CBowner + "&Cbtitle=" + Cbtitle + "&link=" + links.Rows[i][0].ToString();
                        dynamicimage.Height = Unit.Pixel(300);
                        dynamicimage.Width = Unit.Pixel(300);
                        dynamicimage.CssClass = "image";

                        phImageHolder.Controls.Add(dynamicimage);                        
                    }
                }
            }          
        }

        protected void CheckForPrivateCB()
        {
            string sql = "SELECT * FROM privateCB WHERE owner='"+CBowner+"' AND title='"+Cbtitle+"';";
            if (_mysqlhandler.SelectFromDB(sql).Rows.Count > 0)
            {
                btnWatch.Enabled = false;
                if ((bool)Session["hasPvtAccess"] == false)
                    Response.Redirect("CheckPassword.aspx?CBowner=" + CBowner + "&Cbtitle=" + Cbtitle);
            }
        }

        protected void btnAddPp_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddPushpin.aspx?CBtitle=" + Cbtitle);
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

        protected void btnWatch_Click(object sender, EventArgs e)
        {

            string sql = "INSERT INTO watchList (watcherEmail, CBowner, CBtitle) VALUES ('" +
                user + "','" + CBowner + "','" + Cbtitle + "');";
            _mysqlhandler.InsertIntoDB(sql);

            btnWatch.Text = "Watching";
            btnWatch.Enabled = false;

            //get number of watchers
            sql = "SELECT COUNT(*) FROM watchList WHERE CBowner='" + CBowner + "' AND CBtitle='" + Cbtitle + "';";
            lblWatchers.Text = (_mysqlhandler.SelectFromDB(sql).Rows[0][0]).ToString();
        
        }

    }
}