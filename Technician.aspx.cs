using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Project1_Chad_Jsaicki
{
    public partial class Technician : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Text = "";
                LoadsTechdrp();
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./MainMenu.aspx");
        }

        private void LoadsTechdrp()
        {
            DataSet dsData;
            dsData = clsDatabase.gettechs();
  
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

        //*** clears the form (first load)
        private void FormDefault()
        {
            this.drpTech.SelectedValue = "0";
            this.btnAccept.Enabled = false;
            this.btnCancel.Enabled = false;
            this.btnRemove.Enabled = false;
            this.btnClear.Enabled = false;
            this.btnNewTech.Enabled = true;
            this.drpTech.Enabled = true;
            txtFName.Text = "";
            txtMInitial.Text = "";
            txtLName.Text = "";
            txtEMail.Text = "";
            txtDept.Text = "";
            txtPhone.Text = "";
            txtRate.Text = "";
            LoadsTechdrp();
        }
        protected void drpProdID_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int x = Convert.ToInt32(drpTech.SelectedValue.ToString());
            if (x == 0)
            {
                FormDefault();
            }
            else
            {
                this.btnAccept.Enabled = true;
                this.btnCancel.Enabled = true;
                this.btnRemove.Enabled = true;
                this.btnClear.Enabled = true;
                this.btnNewTech.Enabled = false;
                DisplayTechInfo(drpTech.SelectedValue.ToString());
                lblError.Text = "";
            }
        }
        private void DisplayTechInfo(String strProdID)
        {
            DataSet dsData;
            dsData = clsDatabase.GetTechInfoByID(strProdID);
            if (dsData == null)
            {
                lblError.Text = "Error retriving Product";
            }
            else if (dsData.Tables.Count < 1)
            {
                lblError.Text = "Error retrieving Product";
                dsData.Dispose();
            }
            else
            {
                if (dsData.Tables[0].Rows[0]["FName"] == DBNull.Value)
                {
                    txtFName.Text = "";
                }
                else
                {
                    txtFName.Text = dsData.Tables[0].Rows[0]["FName"].ToString();
                }

                if (dsData.Tables[0].Rows[0]["MInit"] == DBNull.Value)
                {
                    txtMInitial.Text = "";
                }
                else
                {
                    txtMInitial.Text = dsData.Tables[0].Rows[0]["MInit"].ToString();
                }

                if (dsData.Tables[0].Rows[0]["LName"] == DBNull.Value)
                {
                    txtLName.Text = "";
                }
                else
                {
                    txtLName.Text = dsData.Tables[0].Rows[0]["LName"].ToString();
                }

                if (dsData.Tables[0].Rows[0]["EMail"] == DBNull.Value)
                {
                    txtEMail.Text = "";
                }
                else
                {
                    txtEMail.Text = dsData.Tables[0].Rows[0]["EMail"].ToString();
                }

                if (dsData.Tables[0].Rows[0]["Dept"] == DBNull.Value)
                {
                    txtDept.Text = "";
                }
                else
                {
                    txtDept.Text = dsData.Tables[0].Rows[0]["Dept"].ToString();
                }

                if (dsData.Tables[0].Rows[0]["Phone"] == DBNull.Value)
                {
                    txtPhone.Text = "";
                }
                else
                {
                    txtPhone.Text = dsData.Tables[0].Rows[0]["Phone"].ToString();
                }

                if (dsData.Tables[0].Rows[0]["HRate"] == DBNull.Value)
                {
                    txtRate.Text = "";
                }
                else
                {
                    txtRate.Text = dsData.Tables[0].Rows[0]["HRate"].ToString();
                }
                dsData.Dispose();
            }
        }

        protected void btnNewTech_Click(object sender, EventArgs e)
        {
            FormDefault();
            lblError.Text = "Adding new Tech";
            this.btnNewTech.Enabled = false;
            this.btnAccept.Enabled = true;
            this.btnCancel.Enabled = true;
            this.btnClear.Enabled = true;
            this.drpTech.SelectedValue = "0";
            this.drpTech.Enabled = false;
            this.txtFName.Focus();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            FormDefault();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.btnAccept.Enabled = false;
            this.btnCancel.Enabled = false;
            this.btnRemove.Enabled = false;
            this.btnClear.Enabled = false;
            this.btnNewTech.Enabled = true;
            this.drpTech.Enabled = true;
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            DataVal();
        }
        private void DataVal()
        {
            Boolean blErrState = false;
            Int32 intNewTech;
            Int32 UpdateTech;
            lblError.Text = "";
            string strFName = txtFName.Text;
            string strMidIni = txtMInitial.Text;
            string strLName = txtLName.Text;
            string strEmail = txtEMail.Text;
            string strDept = txtDept.Text;
            Int64 intPhone = 0;
            decimal decRate = 0;
            int intFName = strFName.Length;
            if (intFName >= 2 && intFName < 20)
            {
                blErrState = false;
            }
            else
            {
                blErrState = true;
                txtFName.Focus();
                lblError.Text = "First Name not valid, Can't be null and has to have 2 to 20 character!!!";
            }

            if (!blErrState)
            {
                int intMidIni = strMidIni.Length;
                if (intMidIni < 2)
                {
                    blErrState = false;
                    lblError.Text = "";
                }
                else
                {
                    blErrState = true;
                    txtMInitial.Focus();
                    lblError.Text = "Invalid Data, middle can only be 1 characters";
                }
            }
            if (!blErrState)
            {
                int intLName = strLName.Length;
                if (intLName >= 3 && intLName < 30)
                {
                    blErrState = false;
                    lblError.Text = "";
                }
                else
                {
                    blErrState = true;
                    txtLName.Focus();
                    lblError.Text = "Invalid Data, Last Name Can't be null and has to have 3 to 30 character!!!";
                }
            }

            if (!blErrState)
            {
                int intEmail = strEmail.Length;
                if (intEmail >= 5 && intEmail < 50)
                {
                    if (strEmail is null)
                    {
                        blErrState = false;
                        lblError.Text = strEmail;
                    }
                }
                else
                {
                    blErrState = true;
                    txtEMail.Focus();
                    lblError.Text = "Invalid Data, Email Address must have between 5-50 characters";
                }
            }
            if (!blErrState)
            {
                int intDept = strDept.Length;
                if (intDept >= 2 && intDept < 25)
                {
                    if (strDept is null)
                    {
                        blErrState = false;
                        lblError.Text = "";
                    }
                }
                else
                {
                    blErrState = true;
                    txtDept.Focus();
                    lblError.Text = "Invalid Data, Dept must have between 2-25 characters";
                }
            }

            if (!blErrState)
            {
                if (Int64.TryParse(txtPhone.Text, out intPhone))
                {
                    lblError.Text = "";
                    blErrState = false;
                    if (txtPhone.Text.Length != 10)
                    {
                        lblError.Text = "Phone Number Must have 10 digits and can't be Null!!!";
                        txtPhone.Focus();
                        blErrState = true;
                    }
                    else
                    {
                        lblError.Text = "";
                        blErrState = false;
                        if (Decimal.TryParse(txtRate.Text, out decRate))
                        {
                            Decimal decRate1 = decRate;
                            if (decRate < 0)
                            {
                                lblError.Text = "Rate can't be 0!!!";
                                blErrState = true;
                                txtRate.Focus();
                            }
                            else
                            {
                                blErrState = false;
                                lblError.Text = "";
                            }
                        }
                        else
                        {
                            lblError.Text = "Rate can't be null and can only contain Number!!!";
                            txtRate.Focus();
                            blErrState = true;
                        }
                    }
                }
                else
                {
                    lblError.Text = "Phone Number can only contain Numbers!!!";
                    txtPhone.Focus();
                    blErrState = true;
                }
            }

            if (!blErrState)
            {
                if (drpTech.SelectedValue != "0")
                {
                    Int32 intTechID = Convert.ToInt32(drpTech.SelectedValue.ToString());

                    UpdateTech = clsDatabase.SQLUpdateTech(intTechID, strLName, strFName, strMidIni, strEmail, strDept, intPhone, decRate);

                    if (UpdateTech == 0)
                    {
                        lblError.Text = "Tech ID " + drpTech.SelectedItem.ToString() + " was updated";
                        FormDefault();
                    }
                    else
                    {
                        lblError.Text = "Error updating Tech record";
                    }
                }
                else
                {
                    intNewTech = clsDatabase.InsertTech(strLName, strFName, strMidIni, strEmail, strDept, intPhone, decRate);

                    if (intNewTech > 0)
                    {
                        lblError.Text = "New tech was added";
                        FormDefault();
                    }
                    else
                    {
                        lblError.Text = "Error addinig Tech record";
                    }
                }
            }
        }
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            int intTest = clsDatabase.DeleteTech(drpTech.SelectedValue.ToString());
            if (intTest == 0)
            {
                lblError.Text = "Tech " + drpTech.SelectedItem.ToString() + " was removed"; 
                FormDefault();
            }
            else
            {
                lblError.Text = "Error, Tech was not removed";
            }
        }
    }
}