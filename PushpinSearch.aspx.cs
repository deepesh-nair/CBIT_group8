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
    public partial class PushpinSearch : System.Web.UI.Page
    {
        mysqlhandler _mysqlhandler = new mysqlhandler();
        DataTable dtSearch = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            string keyword = Request.QueryString["keyword"];
            //string sql = "SELECT DISTINCT description, CBtitle, name, link, Cbowner FROM (SELECT description, CBtitle, CBowner, link FROM (SELECT x1.CBowner, x1.CBtitle, x1.description, x1.tag, x1.link, y1.category FROM (SELECT pushpin.CBowner, pushpin.CBtitle, pushpin.description, pushpin.link, tags.tag FROM pushpin LEFT JOIN tags ON pushpin.CBowner=tags.CBowner AND pushpin.CBtitle=tags.CBtitle AND pushpin.link=tags.link) AS x1 LEFT JOIN (SELECT publicCB.owner, publicCB.title, corkboard.category FROM publicCB INNER JOIN corkboard ON publicCB.owner=corkboard.owner AND publicCB.title=corkboard.title) AS y1 ON x1.CBowner=y1.owner AND x1.CBtitle=y1.title) AS temp1 WHERE description LIKE '%"+keyword+"%' OR tag LIKE '%"+keyword+"%' OR category LIKE '%"+keyword+"%') AS z1 INNER JOIN user ON z1.CBowner=user.email ORDER BY description;";
            string sql = "SELECT DISTINCT description, CBtitle, name FROM (SELECT description, CBtitle, CBowner FROM (SELECT x1.CBowner, x1.CBtitle, x1.description, x1.tag, y1.category FROM (SELECT x0.CBowner, x0.CBtitle, x0.description, tags.tag FROM (SELECT CBowner, CBtitle, description, link FROM pushpin JOIN publicCB ON pushpin.CBowner = publicCB.owner AND pushpin.CBtitle = publicCB.title) AS x0 LEFT JOIN tags ON x0.CBowner=tags.CBowner AND x0.CBtitle=tags.CBtitle AND x0.link=tags.link) AS x1 LEFT JOIN (SELECT publicCB.owner, publicCB.title, corkboard.category FROM publicCB INNER JOIN corkboard ON publicCB.owner=corkboard.owner AND publicCB.title=corkboard.title) AS y1 ON x1.CBowner=y1.owner AND x1.CBtitle=y1.title) AS temp1 WHERE description LIKE '%"+keyword+"%' OR tag LIKE '%"+keyword+"%' OR category LIKE '%"+keyword+"%') AS z1 INNER JOIN user ON z1.CBowner=user.email ORDER BY description;";

            dtSearch = _mysqlhandler.SelectFromDB(sql);
            
            DataTable datasrc = new DataTable();
            datasrc = dtSearch.Copy();
            datasrc.Columns.RemoveAt(4);
            datasrc.Columns.RemoveAt(3);
            
            datasrc.Columns[0].ColumnName = "Pushpin Description";
            datasrc.Columns[1].ColumnName = "Corkboard";
            datasrc.Columns[2].ColumnName = "Owner";

            gvSearch.DataSource = datasrc;
            gvSearch.DataBind();

        }

        protected void gvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Attributes.Add("onmouseover", "this.style.cursor='pointer'");
                e.Row.Cells[0].Attributes.Add("onmousedown", "if(event.button==0){window.location='ViewPushpin.aspx?CBowner=" + dtSearch.Rows[e.Row.RowIndex][4].ToString() + "&CBtitle=" + dtSearch.Rows[e.Row.RowIndex][1].ToString() + "&link=" + dtSearch.Rows[e.Row.RowIndex][3].ToString() + "'}");
                e.Row.Cells[0].Font.Underline = true;
                e.Row.Cells[0].ForeColor = System.Drawing.Color.Blue;
                
                //e.Row.Attributes.Add("onmouseover", "this.style.cursor='pointer'");
                //e.Row.Attributes.Add("onmousedown", "if(event.button==0){window.location='ViewPushpin.aspx?CBowner=" + dtSearch.Rows[e.Row.RowIndex][4].ToString() + "&CBtitle=" + dtSearch.Rows[e.Row.RowIndex][1].ToString() + "&link=" + dtSearch.Rows[e.Row.RowIndex][3].ToString() + "'}");
            }
        }
    }
}