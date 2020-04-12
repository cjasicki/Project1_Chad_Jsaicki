using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Project1_Chad_Jsaicki
{
    public partial class ProblemList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                getOpenProblems();
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("./MainMenu.aspx");
        }
        private void getOpenProblems()
        {
            DataSet dsData;
            dsData = clsDatabase.getOpenProblems();

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

                gvProblemList.DataSource = dsData;
                gvProblemList.DataBind();
                dsData.Dispose();
            }
        }
        //protected void gvProblemList_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
            
        //    if (e.CommandName == "Select")
        //    {
        //        //Determine the RowIndex of the Row whose Button was clicked.
        //        int rowIndex = Convert.ToInt32(e.CommandArgument);

        //        //Reference the GridView Row.
        //        GridViewRow row = gvProblemList.Rows[rowIndex];

        //        //Fetch value of Name.
        //        string name = (row.FindControl("txtName") as TextBox).Text;

        //        //Fetch value of Country
        //        string country = row.Cells[1].Text;

        //        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nCountry: " + country + "');", true);
        //    }

        //    //Response.Redirect("./MainMenu.aspx");

        //    //Boolean blnErrorOccurred = false;
        //    //Int32 intRetCode = 0;
        //    //String strProdID = "";

        //    //lblError.Text = "";

        //    //if (e.CommandName.Trim().ToUpper() == "CHANGE")
        //    //{
        //    //    try
        //    //    {
        //    //        strProdID = gvProducts.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text.ToString();
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        blnErrorOccurred = true;
        //    //        lblError.Text = "Unable to access product id";
        //    //    }

        //    //    if (!blnErrorOccurred)
        //    //    {
        //    //        //** Using SESSION variables
        //    //        Session.Contents["ProductID"] = strProdID;
        //    //        Response.Redirect("./Product.aspx");

        //    //        //** Using QUERYSTRING variables
        //    //        //Response.Redirect("./Products.aspx?ProdID=" + strProdID);
        //    //    }
        //    //}

        //    //if (e.CommandName.Trim().ToUpper() == "REMOVE")
        //    //{
        //    //    try
        //    //    {
        //    //        strProdID = gvProducts.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text.ToString();
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        blnErrorOccurred = true;
        //    //        lblError.Text = "Unable to access product id";
        //    //    }

        //    //    if (!blnErrorOccurred)
        //    //    {
        //    //        //**********Add WebService instance BELOW
        //    //        //Then Uncomment
        //    //        intRetCode = svc.DeleteProduct(strProdID);
        //    //        if (intRetCode == 0)
        //    //        {
        //    //            LoadProducts();
        //    //        }
        //    //        else
        //    //        {
        //    //            lblError.Text = "Unable to remove product id";
        //    //        }
        //    //  }
        //    //}
        //}

        //protected void gvProblemList_SelectedIndexChanged(object sender, EventArgs e)
        //{
            protected void gvProblemList_RowCommand(object sender, GridViewCommandEventArgs e) 
            {

             try
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = gvProblemList.Rows[rowIndex];
                //Fetch value of Country
                string TicketID = row.Cells[1].Text;
                //Fetch value of Name.
                string IncidentNo = row.Cells[2].Text;

            }
            catch (Exception ex)
            {
                lblError.Text = "Unable to access product id";
            }



            Response.Redirect("./MainMenu.aspx");
        }
    }
}