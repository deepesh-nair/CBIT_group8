﻿using System;
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
        public string user;

        protected void Page_Load(object sender, EventArgs e)
        {
            string sqlCategory = "SELECT name FROM category";
            DataTable result = _mysqlhandler.SelectFromDB(sqlCategory);
            foreach(DataRow r in result.Rows)
                ddlCategory.Items.Add(r[0].ToString());
            user = Session["user"].ToString();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            string sql = "INSERT INTO  corkboard (owner,title,lastupdate,category) VALUES ('" + user +
                    "','" + txtTitle.Text + "',NULL,'" + ddlCategory.SelectedItem.ToString() + "');";
            if (_mysqlhandler.InsertIntoDB(sql) == 0)
            {

                if (rbPublic.Checked == true)
                {
                    sql = "INSERT INTO  publicCB (owner,title) VALUES ('" + user + "', '" + txtTitle.Text + "');";
                    _mysqlhandler.InsertIntoDB(sql);
                }
                else
                {
                    sql = "INSERT INTO  privateCB (owner,title,password) VALUES ('" + user + "','" + txtTitle.Text + "','" + txtPassword.Text + "');";
                    _mysqlhandler.InsertIntoDB(sql);
                }
                Response.Redirect("ViewCorkboard.aspx?CBowner="+user+"&Cbtitle="+txtTitle.Text);
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('There was a error in your entry, please try again!!');</script>");
                txtPassword.Text = string.Empty;
                txtTitle.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtPassword.Enabled = false;
                rbPublic.Checked = true;
            }
            
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