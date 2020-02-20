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


        private void DisplayTech()
        {

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
            txtFName.Text = "";
            txtMInitial.Text = "";
            txtLName.Text = "";
            txtEMail.Text = "";
            txtDept.Text = "";
            txtPhone.Text = "";
            txtRate.Text = "";
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
        }

    }
}