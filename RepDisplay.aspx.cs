using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Project1_Chad_Jsaicki
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string str_Report;
        DataSet dsData;
        protected void Page_Load(object sender, EventArgs e)
        {
            str_Report = Session["seReport"].ToString();
            dsData = clsDatabase.getReport(str_Report);

            if (dsData == null)
            {
                // lblError.Text = "Error retrieving Product list";
            }
            else if (dsData.Tables.Count < 1)
            {
                //lblError.Text = "Error retrieving Product list";
                dsData.Dispose();
            }
            else
            {
                gvupdate();
                dsData.Dispose();
            }
        }

        private void LoadsReport()  
        {

        }
        protected void gvupdate()
        {
            //populates the gridview
            gvReport.DataSource = dsData;
            gvReport.DataBind();

        }
        protected void btnMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("./MainMenu.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./RepSelection.aspx");
        }
    }
}