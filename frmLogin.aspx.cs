using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class frmLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        // creating dsUser object
        dsUser dsUserLogin;
        // SecurityLevel will take what security level the user is
        string SecurityLevel;
        // constructing dsUserLogin object
        dsUserLogin = clsDataLayer.VerifyUser(Server.MapPath("PayrollSystem_DB.accdb"),
        Login1.UserName, Login1.Password);
        // validates username and password input
        if (dsUserLogin.tblUserLogin.Count < 1)
        {
            e.Authenticated = false;
            // statement to see if SendEmail method will return true or false
            if (clsBusinessLayer.SendEmail("benciian@gmail.com",
            "bmagpoc@my.devry.edu", "", "", "Login Incorrect",
            "The login failed for UserName: " + Login1.UserName +
            " Password: " + Login1.Password))
            {
                Login1.FailureText = Login1.FailureText +
                " Your incorrect login information was sent to bmagpoc@my.devry.edu";
            }
            return;
        }
        // assigning value to SecurityLevel variable
        SecurityLevel = dsUserLogin.tblUserLogin[0].SecurityLevel.ToString();
        // checking the access level of user
        switch (SecurityLevel)
        {
            case "A":
                // A is administrator access level
                e.Authenticated = true;
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
                Session["SecurityLevel"] = "A";
                break;
            case "U":
                // U is user access level
                e.Authenticated = true;
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
                Session["SecurityLevel"] = "U";
                break;
            default:
                e.Authenticated = false;
                break;
        }
    }
}