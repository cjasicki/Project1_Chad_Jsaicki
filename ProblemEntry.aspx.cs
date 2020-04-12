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

        Boolean blErrState = false;


        protected void Page_Load(object sender, EventArgs e)
        {

            // lblProblemNum.Text = intIcount.ToString();
            if (!IsPostBack)
            {
                if (Session["seTicketNumber"] == null)
                {
                    Session["seError"] = "System Failure, Did not write to Database";
                    Response.Redirect("./ServiceEvent.aspx");
                }
                else
                {
                    lblTicketNum.Text = Session["seTicketNumber"].ToString();
                    lblError.Text = "";
                    LoadsTechdrp();
                    LoadsPoductdrp();
                }
            }
        }
        protected void IncreamentCounter(object sender, EventArgs e)
        {
            int counter;
            if (ViewState["Count"] != null)
            {
                counter = Convert.ToInt32(ViewState["Count"]);
            }
            else
            {
                counter = 1;
            }
            counter = counter + 1;
            ViewState["Count"] = counter;
            this.lblProblemNum.Text = counter.ToString();
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
                drpProd.DataTextField = "ProductDesc";
                drpProd.DataValueField = "ProductID";
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
            DataVal();
            int counter;
            if (ViewState["Count"] != null)
            {
                counter = Convert.ToInt32(ViewState["Count"]);
            }
            else
            {
                counter = 1;
                this.lblProblemNum.Text = counter.ToString();
            }

            if (!blErrState)
            {

                int strResult = clsDatabase.InsProblemEvent(Convert.ToInt32(lblTicketNum.Text), Convert.ToInt32(lblProblemNum.Text), this.txtProblem1.Text, Convert.ToInt32(drpTech.SelectedValue), drpProd.SelectedValue);

                if (strResult == 0)
                {
                    counter = counter + 1;
                    ViewState["Count"] = counter;
                    this.lblProblemNum.Text = counter.ToString();

                    lblError.Text = "Problem# " + lblProblemNum.Text + " was saved";
                    FormDefults();
                }
                else
                {
                    lblError.Text = "Error writing to dabasebase, please check with the system admin";
                }

            }


        }
        private void DataVal()
        {
            if (drpProd.SelectedValue == "0")
            {
                blErrState = true;
                lblError.Text = "Please slect a valid Product in the Product dropdown menu";
            }
            else if (drpTech.SelectedValue == "0") 
            { 
                lblError.Text = "Please slect a valid Technician in the Technician dropdown menu";            
                blErrState = true;
            } 
            else if (string.IsNullOrEmpty(txtProblem1.Text))
            {
                blErrState = true;
                lblError.Text = "Please enter a valid description of the problem";
            }
            else
            {
                blErrState = false;
            }
        }
        private void FormDefults()
        {
            drpProd.SelectedValue = "0";
            drpTech.SelectedValue = "0";
            txtProblem1.Text= "";
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            FormDefults();
        }
    }
}