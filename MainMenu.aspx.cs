using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1_Chad_Jsaicki
{
    public partial class MainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnServiceEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ServiceEvent.aspx");
        }

        protected void btnTechnician_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Technician.aspx");
        }
    }
}