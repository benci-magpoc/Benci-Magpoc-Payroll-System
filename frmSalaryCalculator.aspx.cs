using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmSalaryCalculator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCalculateSalary_Click(object sender, EventArgs e)
    {
        double annualHours;
        double payRate;
        double annualSalary;

        annualHours = double.Parse(txtAnnualHours.Text);
        payRate = double.Parse(txtPayRate.Text);

        annualSalary = payRate * annualHours;

        lblAnnualSalary.Text = "Annual Salary is $: " + annualSalary;

    }
}