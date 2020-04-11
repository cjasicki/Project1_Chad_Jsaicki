using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Project1_Chad_Jsaicki
{
    public partial class ProblemEntry : System.Web.UI.Page
    {
        int intIcount = 1;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            lblProblemNum.Text = intIcount.ToString();
            if (!IsPostBack)
            {
                lblTicketNum.Text = Session["seTicketNumber"].ToString();
                lblError.Text = "";
                LoadsTechdrp();
                LoadsPoductdrp();
            }
        }
  
        private void LoadsPoductdrp()
        {
            DataSet dsData;
            dsData = clsDatabase.getProduct();

            if (dsData == null)
            {
                lblError.Text = "Error retrieving Product list";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error retrieving Product list";
                dsData.Dispose();
            }
            else
            {
                drpProd.AppendDataBoundItems = true;
                drpProd.Items.Clear();
                drpProd.DataSource = dsData.Tables[0];
                drpProd.DataTextField = "ProductID";
                drpProd.DataValueField = "ProductDesc";
                drpProd.Items.Add(new ListItem("--Product--", "0"));
                drpProd.DataBind();
                dsData.Dispose();
            }
        }
        private void LoadsTechdrp()
        {
            DataSet dsData;
            dsData = clsDatabase.getTechs();

            if (dsData == null)
            {
                lblError.Text = "Error retrieving Product list";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error retrieving Product list";
                dsData.Dispose();
            }
            else
            {
                drpTech.AppendDataBoundItems = true;
                drpTech.Items.Clear();
                drpTech.DataSource = dsData.Tables[0];
                drpTech.DataTextField = "TechName";
                drpTech.DataValueField = "TechnicianID";
                drpTech.Items.Add(new ListItem("--Select Technician--", "0"));
                drpTech.DataBind();
                dsData.Dispose();
            }
        }
            protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ServiceEvent.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

                intIcount++;
                lblProblemNum.Text = intIcount.ToString();
    

        }
    }
}