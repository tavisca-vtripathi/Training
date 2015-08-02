﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Dal.Model;

namespace RollBaseAcess._1.View
{
    public partial class WebForm2 : System.Web.UI.Page
    {
       public Dictionary<string, string> employeeDictionary = new Dictionary<string, string>();
       protected void Page_Load(object sender, EventArgs e)
       {
           if (Page.IsPostBack == false)
           {
               ClientEmployee fetchedEmployee = (ClientEmployee)Session["Fetched_Employee_Object"];
               if (fetchedEmployee == null || fetchedEmployee.Title.Equals("HR") == false)
               {
                   Response.Redirect("Login.aspx");
               }

               employeeDictionary = Transporter.GetAllEmployees("application/json");
               DropDownList1.DataTextField = "Value";
               DropDownList1.DataValueField = "Key";
               DropDownList1.DataSource = employeeDictionary;
               DropDownList1.DataBind();
           }
       }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ClientRemark remark = Transporter.AddRemark(DropDownList1.SelectedValue, TextBox6.Text);
            TextBox6.Text = "";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }   
            
    }
}