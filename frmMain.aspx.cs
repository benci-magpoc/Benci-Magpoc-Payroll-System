using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmMain : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // saving user activity to clsDataLayer class
        clsDataLayer.SaveUserActivity(Server.MapPath("PayrollSystem_DB.accdb"), "frmPersonnel");

        if (Session["SecurityLevel"] == "A")
        {
            lnkbtnCalculator.Visible = true;
            lnkbtnEditEmployees.Visible = true;
            lnkbtnNewEmployee.Visible = true;
            lnkbtnSearch.Visible = true;
            lnkbtnUserActivity.Visible = true;
            lnkbtnViewPersonnel.Visible = true;
            
        }
        else
        {
            lnkbtnCalculator.Visible = true;
            lnkbtnEditEmployees.Visible = false;
            imgbtnEditEmployees.Visible = false;
            lnkbtnNewEmployee.Visible = false;
            imgbtnNewEmployee.Visible = false;
            lnkbtnSearch.Visible = true;
            lnkbtnUserActivity.Visible = false;
            imgbtnUserActivity.Visible = false;
            lnkbtnViewPersonnel.Visible = true;
            lnkbtnManageUsers.Visible = false;
            imgbtnManageUsers.Visible = false;
        }
    }
}