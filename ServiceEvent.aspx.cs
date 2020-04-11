using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Project1_Chad_Jsaicki
{
    public partial class ServiceEvent : System.Web.UI.Page
    {
        Boolean blErrState = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            
            if (!IsPostBack)
            {
                if (Session["seContacts"] == null)
                {
                    
                    //lblDate.Text = Session["seTicketMumber"].ToString();
                }

                lblError.Text = "";
                LoadsClientdrp();
            }
        }
        private void LoadsClientdrp()
        {
            DataSet dsData;
            dsData = clsDatabase.getClients();

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
                drpClient.AppendDataBoundItems = true;
                drpClient.Items.Clear();
                drpClient.DataSource = dsData.Tables[0];
                drpClient.DataTextField = "ClientName";
                drpClient.DataValueField = "ClientID";
                drpClient.Items.Add(new ListItem("--Pick Client--", "0"));
                drpClient.DataBind();
                dsData.Dispose();
            }
        }
        private void DataVal()
        {
            
            Int64 intPhone = 0;
            if (!blErrState)
            {
                if (Int64.TryParse(txtPhone.Text, out intPhone))
                {
                    lblError.Text = "";
                    blErrState = false;
                    if (txtPhone.Text.Length != 10 && !txtPhone.Text.StartsWith("0"))
                    {
                        lblError.Text = "Phone Number Must have 10 digits and can't be Null!!!";
                        txtPhone.Focus();
                        blErrState = true;
                    }
                    else
                    {
                        lblError.Text = "";
                        blErrState = false;
                    }


                }
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./MainMenu.aspx");
        }

        protected void drpClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            DataVal();
            if (blErrState == false){
                Int32 intNewTicket;
                int intClientID = Int32.Parse(drpClient.SelectedValue);
                DateTime stDate = DateTime.Now;

                intNewTicket = clsDatabase.InsServiceEvent(stDate, intClientID, txtContact.Text, txtPhone.Text);

                if (intNewTicket > 0)
                {
                    lblError.Text = "New tech was added";
                    Session["seTicketNumber"] = intNewTicket;
                   // FormDefault();
                }

                Response.Redirect("./ProblemEntry.aspx");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.drpClient.SelectedValue = "0";
            this.lblError.Text = "";
            this.txtContact.Text = "";
            this.txtPhone.Text = "";
        }
    }
}