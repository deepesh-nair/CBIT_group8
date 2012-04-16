using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySQLHandler;
using System.Data;

//the CSV should be 20 characters or less

namespace CBIT_group8
{
    public partial class AddPushpin : System.Web.UI.Page
    {
        mysqlhandler _mysqlhandler = new mysqlhandler();
        public string user;
        public string CBtitle;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the user and CBtitle from the session variables
            user = Session["user"].ToString();
            CBtitle = Request.QueryString["CBtitle"];
        }

        /// <summary>
        /// Upon clicking the Add button, a new pushpin gets created and its details get added to 
        /// the PushPin table 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string sql = string.Empty; 
                /*= "SELECT * FROM pushpin WHERE CBowner ='" + user + "' AND CBtitle = '" +
                CBtitle + "' AND link = '" + txtURL.Text + "';";
            DataTable result = _mysqlhandler.SelectFromDB(sql);
        
            // If the datatable has an entry in it, it implies that the image already exists in the database
            if (result.Rows.Count > 0)
            {
                txtURL.Text = "";
                txtDesc.Text = "";
                txtDesc.Text = "";
                Response.Write("<script type='text/javascript'>alert('This pushpin already exists!!');</script>");
            }*/

            //else
            
                string strTags = txtTags.Text;

                // Removing spaces
                strTags.Replace(" ", "");

                // Populate the string array with the comma separated values in the textbox.
                string[] tags = strTags.Split(',');
                //int lenTagExceed = 1;
                /*foreach (string tag in tags)
                {
                    if (tag.Length > 20)
                    {
                        lenTagExceed = 0;
                        break;
                    }
                }*/

                //if (lenTagExceed == 1)
                
                    // Store the length of the array in tagsLen
                    int tagsLen = tags.Length;

                    // Used to format the date-time 
                    string datetimeformat = "yyyy-MM-dd HH:mm:ss";

                    // This string holds the SQL for insertion into the PushPin table
                    sql = "INSERT INTO pushpin (CBowner,CBtitle,link,datetime,description) VALUES ('" +
                        user + "','" + CBtitle + "','" + txtURL.Text + "','" + DateTime.Now.ToString(datetimeformat) + 
                        "','" + txtDesc.Text + "');";
                    _mysqlhandler.InsertIntoDB(sql);

                    // Check for the number of tags inserted, 
                    // If its greater than 0, insert rows into the Tags Table
                    if (tagsLen > 0)
                    {
                        sql = "INSERT INTO  tags (CBowner, CBtitle ,link, tag) VALUES ('" +
                        user + "','" + CBtitle + "','" + txtURL.Text + "','";

                        // Iterate though the tags array and append the tag name to the sql string 
                        // and insert into the Tags table
                        foreach (string tag in tags)
                        {
                            _mysqlhandler.InsertIntoDB(sql + tag + "');");
                        }
                    }
                    Response.Redirect("Homepage.aspx");
                            
        }
    }
}
