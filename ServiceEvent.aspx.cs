﻿using System;
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
            lblError.Text = "";
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            if (!IsPostBack)
            {
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
            Int64 intPhone;

            if (drpClient.SelectedValue == "0")
            {
                blErrState = true;
                lblError.Text = "Please slect a valid Client in the dropdown menu";
            }
            else if (string.IsNullOrEmpty(txtContact.Text))
            {
                blErrState = true;
                lblError.Text = "Contact Name is requred, please enter an Contact";
            }
            else if (txtPhone.Text.Length != 10 && !txtPhone.Text.StartsWith("0"))
            {
                lblError.Text = "Phone Number Must have 10 digits and can't be Null!!!";
                txtPhone.Text = "";
                txtPhone.Focus();
                blErrState = true;
            }
            else if (!Int64.TryParse(txtPhone.Text, out intPhone))
            {
                lblError.Text = "Phone Number must be all numbers";
                txtPhone.Text = "";
                txtPhone.Focus();
                blErrState = true;
            }
            else
            {
                lblError.Text = "";
                blErrState = false;
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
                    lblError.Text = "New Event was added";
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