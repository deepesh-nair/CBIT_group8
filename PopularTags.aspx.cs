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
    public partial class PopularTags : System.Web.UI.Page
    {
        mysqlhandler _mysqlhandler = new mysqlhandler();
        DataTable dtTags = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "	SELECT tag, COUNT(link) AS \"NumPushpins\", COUNT(DISTINCT CBtitle) AS \"NumUniqueCB\" FROM (SELECT * FROM corkboard INNER JOIN (SELECT pushpin.CBowner, pushpin.CBtitle, pushpin.link, pushpin.datetime, pushpin.description, tags.tag FROM pushpin INNER JOIN tags ON pushpin.CBowner=tags.CBowner AND pushpin.link=tags.link AND pushpin.CBtitle=tags.CBtitle) AS pushpins ON pushpins.CBowner=corkboard.owner AND pushpins.CBtitle=corkboard.title) AS temp GROUP BY tag ORDER BY NumPushpins DESC LIMIT 5;";
            dtTags = _mysqlhandler.SelectFromDB(sql);
            dtTags.Columns[0].ColumnName = "Tag";
            dtTags.Columns[1].ColumnName = "Pushpins";
            dtTags.Columns[2].ColumnName = "Unique Corkboards";

            gvTags.DataSource = dtTags;
            gvTags.DataBind();
        }

        protected void gvTags_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Attributes.Add("onmouseover", "this.style.cursor='pointer'");
                e.Row.Cells[0].Attributes.Add("onmousedown", "if(event.button==0){window.location='PushpinSearch.aspx?keyword=" + dtTags.Rows[e.Row.RowIndex][0].ToString() + "'}");
                e.Row.Cells[0].Font.Underline = true;                
                e.Row.Cells[0].ForeColor = System.Drawing.Color.Blue;
               
                //e.Row.Attributes.Add("onmouseover", "this.style.cursor='pointer'");
                //e.Row.Attributes.Add("onmousedown", "if(event.button==0){window.location='PushpinSearch.aspx?keyword=" + dtTags.Rows[e.Row.RowIndex][0].ToString() + "'}");
            }
        }
    }
}