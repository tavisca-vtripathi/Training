﻿using RollBaseAcess.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace RollBaseAcess
{
    public partial class Login : System.Web.UI.UserControl
    {
        string _emsUri = ConfigurationManager.AppSettings["EMSUri"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FormsAuthentication.Initialize();
            Credentials credentials = new Credentials();
            credentials.EmailId = TextBox1.Text;
            credentials.Password = TextBox2.Text;
            try
            {
                HttpClient client = new HttpClient();
                var empResponse = client.UploadData<Credentials, Employee>(_emsUri + "/login", credentials);
                if (empResponse != null)
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1,
                        empResponse.Email,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(30),
                        true,
                        empResponse.Title,
                        FormsAuthentication.FormsCookiePath);

                    string hash = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(
                       FormsAuthentication.FormsCookieName,
                       hash);
                    Response.Cookies.Add(cookie);
                    Session["Response"] = empResponse.ToSession();

                    Response.Redirect(FormsAuthentication.GetRedirectUrl(empResponse.Email, CheckBox1.Checked));
                }
            }
            catch (Exception)
            {
                Label3.Text = "Invalid Username or Password ";

            }
        }



    }
}