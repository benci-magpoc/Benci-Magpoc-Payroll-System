using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmPersonnel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SecurityLevel"] != "A")
        {
            Response.Redirect("frmLogin.aspx");
        }
        // checking session is security level is administrator
        if (Session["SecurityLevel"] == "A")
        {
            btnSubmit.Visible = true;
            // if access level is administrator, submit button is visible
        }
        else
        {
            btnSubmit.Visible = false;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string errorMessage = "";
        bool allOK = true;
        if (Request["txtFirstName"].ToString().Trim() == "")
        {
            txtFirstName.BackColor = System.Drawing.Color.Yellow;
            errorMessage = errorMessage + " First name may not be empty.";
            allOK = false;
        }
        else
        {
            txtFirstName.BackColor = System.Drawing.Color.White;

        }
        if (Request["txtLastName"].ToString().Trim() == "")
        {
            txtLastName.BackColor = System.Drawing.Color.Yellow;
            errorMessage = errorMessage + " Last name may not be empty.";
            allOK = false;
        }
        else
        {
            txtLastName.BackColor = System.Drawing.Color.White;

        }
        if (Request["txtPayRate"].ToString().Trim() == "")
        {
            txtPayRate.BackColor = System.Drawing.Color.Yellow;
            errorMessage = errorMessage + " Pay rate may not be empty.";
            allOK = false;
        }
        else
        {
            txtPayRate.BackColor = System.Drawing.Color.White;

        }
        if (Request["txtStartDate"].ToString().Trim() == "")
        {
            txtStartDate.BackColor = System.Drawing.Color.Yellow;
            errorMessage = errorMessage + " Start date may not be empty.";
            allOK = false;
        }
        else
        {
            txtStartDate.BackColor = System.Drawing.Color.White;

        }
        if (Request["txtEndDate"].ToString().Trim() == "")
        {
            txtEndDate.BackColor = System.Drawing.Color.Yellow;
            errorMessage = errorMessage + " End date may not be empty.";
            allOK = false;
        }
        else
        {
            txtEndDate.BackColor = System.Drawing.Color.White;

        }
        if (allOK)
        {
            DateTime startDate = DateTime.Parse(Request["txtStartDate"]);
            DateTime endDate = DateTime.Parse(Request["txtEndDate"]);
            if (DateTime.Compare(startDate, endDate) > 0)
            {
                txtStartDate.BackColor = System.Drawing.Color.Yellow;
                txtEndDate.BackColor = System.Drawing.Color.Yellow;
                errorMessage = errorMessage + " The end date must be a later date than the start date";
                allOK = false;
            }
            else
            {
                txtStartDate.BackColor = System.Drawing.Color.White;
                txtEndDate.BackColor = System.Drawing.Color.White;
            }
        }
        if (allOK)
        {
            Session["txtFirstName"] = txtFirstName.Text;
            Session["txtLastName"] = txtLastName.Text;
            Session["txtPayRate"] = txtPayRate.Text;
            Session["txtStartDate"] = txtStartDate.Text;
            Session["txtEndDate"] = txtEndDate.Text;
            Response.Redirect("frmPersonnelVerified.aspx");

        }
        else
        {
            lblError.Text = errorMessage;
        }
    }
}