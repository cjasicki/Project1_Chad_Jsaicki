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

                Session["seTicketID"] = TicketID;
                Session["seIncidentNo"] = IncidentNo;
                Response.Redirect("./Resolution.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Unable to access product id";
            }
        }
    }
}