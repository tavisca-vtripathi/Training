﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Dal.Model;
using Tavisca.Dal.Model.EmployeeManagementService;

namespace RollBaseAcess
{
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ClientCredential clientCredential = new ClientCredential();

            clientCredential.EmailId = TextBox1.Text;
            clientCredential.Password = TextBox2.Text;
            //Fix it.
            ClientEmployee employee = clientCredential.Authenticate();

            if (employee == null)
            {
                // Invalid Credentials Provided
                Label3.Visible = true;
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else
            {
                Session["Fetched_Employee_Object"] = employee;
                if (employee.Title.Equals("HR"))
                {
                    Response.Redirect("AddRemark.aspx");
                }
                else
                {
                    Response.Redirect("EmployeeHomePage.aspx");
                }
            }
        }
    }
}