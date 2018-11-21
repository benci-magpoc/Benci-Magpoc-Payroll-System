using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmManageUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SecurityLevel"] != "A")
        {
            Response.Redirect("frmLogin.aspx");
        }
    }

    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        Session["txtUserName"] = txtUserName.Text;
        Session["txtPassword"] = txtPassword.Text;
        Session["ddlSecurityLevel"] = ddlSecurityLevel.SelectedValue;

        if (clsDataLayer.SaveUser(Server.MapPath("PayrollSystem_DB.accdb"),
        Session["txtUserName"].ToString(), Session["txtPassword"].ToString(), ddlSecurityLevel.SelectedValue.ToString()))
        {
            lblError.Text = "The user was successfully added!";
            grdUsers.DataBind();
        }
        else
        {
            lblError.Text = "The user was not saved";
        }
    }
}