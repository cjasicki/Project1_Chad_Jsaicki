using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1_Chad_Jsaicki
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Boolean blErrState = false;
        string str_SP;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //uspProblemsByProduct
                lstReport.Items.Add("-- Select Report --");
                lstReport.Items.Add("By Product");
                lstReport.Items.Add("By Technician");
                lstReport.Items.Add("By Client");
                lstReport.Items.Add("By Institution");
            }

        }
        protected void btnRun_Click(object sender, EventArgs e)
        {
            switch (lstReport.SelectedValue)
            {
                case "By Product":
                    str_SP = "uspProblemsByProduct";
                    break;
                case "By Technician":
                    str_SP = "uspProblemsByTechnician";
                    break;
                case "By Client":
                    str_SP = "uspProblemsByClient";
                    break;
                case "By Institution":
                    str_SP = "uspProblemsByInstitution";
                    break;
                default:
                    blErrState = true;
                    lblerr.Text = "Must select a report";
                    break;
            }
            if (!blErrState)
            {
                lblerr.Text = "";
                Session["seReport"] = str_SP.ToString();
                Response.Redirect("./RepDisplay.aspx");
            }
        }

        protected void lstReport_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void btnMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("./MainMenu.aspx");
        }
    }
}