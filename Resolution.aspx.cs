using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace Project1_Chad_Jsaicki
{
    public partial class Resolution : System.Web.UI.Page
    {
        Boolean blErrState = false;
        ArrayList list = new ArrayList();
        Decimal decTechRate;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Text = "";
                txtRes.Focus();
                lblTicketNum.Text = Session["seTicketID"].ToString(); // sets ticket number from session variable
                lblProblemNum.Text = Session["seIncidentNo"].ToString(); // sets Problem number from session variable for post backs
                lblResNum.Text = "1";
                LoadsTechdrp();   
            }
        }

        //loads tech technicians in drop down menu from sql database
        private void LoadsTechdrp()
        {
            DataSet dsData;
            dsData = clsDatabase.getTechs();

            if (dsData == null)  //displays error message if no recards are pull or recived from database
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
                // add techs to the dropdown menu
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Meain

            DataVal();
            TechRate();
            WriteDB();
            Clear();     

        }

        private void TechRate() // pulls tech rate from database 
        {
            string strTechID = drpTech.SelectedValue.ToString();
            DataSet dsTech = clsDatabase.GetTechInfoByID(strTechID);
            if (drpTech.SelectedValue != "0")
            {
                decTechRate = Convert.ToDecimal(dsTech.Tables[0].Rows[0]["HRate"]);
            }
        }

        private void WriteDB()  //atempts to updated datebase when submit button is pressed
        {
            int counter;
            if (ViewState["Count"] != null)
            {
                counter = Convert.ToInt32(ViewState["Count"]);
            }
            else
            {
                counter = 1;
                this.lblResNum.Text = counter.ToString();
            }

           
            if (!blErrState)
            {
                //data below has already been validated through the validation process or is pulled from the database
                DateTime dtOnsite = Convert.ToDateTime(list[6]);
                DateTime dtDateRep = Convert.ToDateTime(list[5]);
                decimal DecMIsc = Convert.ToDecimal(list[4]);
                decimal DecSupplies = Convert.ToDecimal(list[3]);
                decimal DecMiles = Convert.ToDecimal(null);   //more here 
                decimal decCostMiles = Convert.ToDecimal(list[1]);
                decimal intHours = Convert.ToDecimal(list[0]);
                int intTech = Convert.ToInt32(drpTech.SelectedValue);
                int intResNum = Convert.ToInt32(lblResNum.Text);
                int intTicketNum = Convert.ToInt32(lblTicketNum.Text);
                int intProblemNum = Convert.ToInt32(lblProblemNum.Text);
                string strRes = txtRes.Text.ToString();
                int intCharge = Convert.ToInt32(ckb_NoCharge.Checked);   // sends no charge checkbox value to the stored procedure

                int strResult = clsDatabase.InsertResolution(intTicketNum, intProblemNum, intResNum, strRes, dtDateRep, dtOnsite, intTech, intHours, DecMiles, decCostMiles, DecSupplies, DecMIsc, intCharge);

               
                if (strResult == 0) //updates the resolutoin number on the page if database update was successful.
                {
                    counter = counter + 1;
                    ViewState["Count"] = counter;
                    this.lblResNum.Text = counter.ToString();

                    lblError.Text = "Resolution# " + lblResNum.Text + " was saved";

                }
                else
                {
                    lblError.Text = "Error writing to dabasebase, please check with the system admin";
                }
            }
        }
        private void DataVal() // validation of user entery fields
        {
            blErrState = false;

            int int_number;
            Decimal Dec_Number;

            // Sorry for getting carried away, but I really wanted to use a two-dimensional array 
            // array holds the config infomaiton for the user entry fields 
            string[,] Values = { { "Required", txtRes.Text, "Resolution Notes", "str" }, { "Required", txtHours.Text, "Hours", "Dec" }, { "NotRequired", txtMiles.Text, "Mileage", "Dec" }, { "NotRequired", txtCostMiles.Text, "Cost Miles", "Dec" }, { "NotRequired", txtSupplies.Text, "Supplies", "Dec" }, { "NotRequired", txtMisc.Text, "Misc", "Dec" } };
            for (int i = 0; i < Values.GetLength(0); i++)
            {
                if (!blErrState)
                {
                    if (Values[i, 1] == "" && Values[i, 0] == "Required")  //check if required field is null 
                    {
                        blErrState = true;
                        lblError.Text = Values[i, 2] + " is a required field";
                    }
                    else if (Values[i, 1] == "" && Values[i, 0] == "NotRequired") // add null value in not required and field is null
                    {
                        list.Add(null);
                        blErrState = false;
                        lblError.Text = "";
                    }
                    else
                    {
                        if (Values[i, 3] == "str")
                        {
                            blErrState = false;
                            lblError.Text = "";
                        }
                        else if (Values[i, 3] == "int")
                        {
                            bool success = Int32.TryParse(Values[i, 1], out int_number); //checks if data entery is a intager 
                            if (success)
                            {
                                if (int_number > 0) //checks if data entery is greater then 0 
                                {
                                    list.Add(int_number);
                                    blErrState = false;
                                    lblError.Text = "";
                                }
                                else
                                {
                                    blErrState = true;
                                    lblError.Text = "Entry for " + Values[i, 2] + " is not valid, needs to be greater than 0";
                                }
                            }
                            else
                            {
                                blErrState = true;
                                lblError.Text = "Entry for " + Values[i, 2] + " is not valid";
                            }
                        }
                        else 
                        {
                            bool success = Decimal.TryParse(Values[i, 1], out Dec_Number); //checks if data entery is a Decimal 
                            if (success)
                            {
                                if (Dec_Number > 0)  //checks if data entery is greater then 0 
                                {
                                    list.Add(Dec_Number);
                                    blErrState = false;
                                    lblError.Text = "";
                                }
                                else
                                {
                                    blErrState = true;
                                    lblError.Text = "Entry for " + Values[i, 2] + " is not valid, needs to be greater than 0";
                                }
                            }
                            else
                            {
                                blErrState = true;
                                lblError.Text = "Entry for " + Values[i, 2] + " is not valid";
                            }
                        } 
                    }
                }
            }
            // validates time
            DateTime temp;
            if (!blErrState)
            {
                if (txtDateRep.Text == "")
                {
                    list.Add(null);
                }
                else 
                { 
                    if (DateTime.TryParse(txtDateRep.Text, out temp))
                    {
                        if (temp > DateTime.Now)
                        {
                            blErrState = true;
                            lblError.Text = "Date Repared is not valid, Can't be greater then today's date";
                        }
                        else
                        {
                            list.Add(temp);
                            blErrState = false;
                            lblError.Text = "";
                        }
                    }
                    else
                    {
                        blErrState = true;
                        lblError.Text = "Date Repared is not valid";
                    }
                }
                DateTime temp1;

                if (txtDateOnsite.Text == "")
                {
                    list.Add(null);
                }
                else
                    {
                        if (DateTime.TryParse(txtDateOnsite.Text, out temp1))
                    {
                        if (temp1 > DateTime.Now)
                        {
                            blErrState = true;
                            lblError.Text = "Date Repared is not valid, Can't be greater then today's date";
                        }
                        else
                        {
                            list.Add(temp1);
                            blErrState = false;
                            lblError.Text = "";
                        }
                    }
                    else
                    {
                        blErrState = true;
                        lblError.Text = "Date Repared is not valid";
                    }
                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
                Clear();
        }
        
        private void Clear()
        {
            //clears the webform
            txtRes.Text = "";
            drpTech.SelectedValue = "0";
            txtHours.Text = "";
            txtMiles.Text = "";
            txtCostMiles.Text = "";
            txtSupplies.Text = "";
            txtMisc.Text = "";
            txtDateRep.Text = "";
            txtDateOnsite.Text = "";
            ckb_NoCharge.Checked = false;
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            //returns browser to problem list page
            Response.Redirect("./ProblemList.aspx");
        }

        protected void ckb_NoCharge_CheckedChanged(object sender, EventArgs e) // method for the no charge checkbox, it just updates the field on the form
        {
               
                if (ckb_NoCharge.Checked == false)
                {
                    TechRate();
                    lblTechRate.Text = decTechRate.ToString("C");
                }
                else
                {
                    lblTechRate.Text = "0";
                }
           
        }

        protected void drpTech_SelectedIndexChanged(object sender, EventArgs e) // method for the no charge checkbox, it just updates the field on the form
        {

                if (ckb_NoCharge.Checked == false)
                {
                    TechRate();
                    lblTechRate.Text = decTechRate.ToString("C");
                }
                else
                {
                    lblTechRate.Text = "0";
                }
        
        }
    }
}