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
            Response.Redirect("./MainMenu.aspx"); //return webpage back to main menu
        }
        private void getOpenProblems()  // loads gridview will all open casess using a SQL stored procedure
        {
            DataSet dsData;
            dsData = clsDatabase.getOpenProblems();  //gets data using SQL stored procedure

            if (dsData == null)  //checks there was data returned
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
                gvProblemList.DataSource = dsData;  // loads grid view from sql database
                gvProblemList.DataBind();
                dsData.Dispose();
            }
        }
  
        protected void gvProblemList_RowCommand(object sender, GridViewCommandEventArgs e) 
        {

            try
            {
                //Determine the RowIndex of which row button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Reference the GridView Row.
                GridViewRow row = gvProblemList.Rows[rowIndex];
                //gets the value of ticket# in the gridview 
                string TicketID = row.Cells[1].Text;
                //gets the value of Incident# in the gridview
                string IncidentNo = row.Cells[2].Text;

                Session["seTicketID"] = TicketID; // sets session verable to selected ticket 
                Session["seIncidentNo"] = IncidentNo;  // sets session verable to selected Incident# 
                Response.Redirect("./Resolution.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Unable to access product id";
            }
        }
    }
}