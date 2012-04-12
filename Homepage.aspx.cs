using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;


namespace CBIT_group8
{
    public partial class Homepage : System.Web.UI.Page
    {
        public string user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];
           
        }
    }
}