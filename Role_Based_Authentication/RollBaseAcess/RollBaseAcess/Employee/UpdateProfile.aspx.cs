using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RollBaseAcess.Model;
using System.Configuration;



namespace RollBaseAcess._1.View
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string _emsUri = ConfigurationManager.AppSettings["EMSUri"];
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Employee empObject = (Employee)Session["Response"];
                if (empObject == null)
                {
                    Response.Redirect("Login.aspx");
                }
                TextBox1.Text = empObject.Email;
            }
            catch (Exception)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ChangePasssword changePassword = new ChangePasssword();
            changePassword.EmailId = TextBox1.Text;
            changePassword.OldPassword = TextBox2.Text;
            changePassword.NewPassword = TextBox4.Text;
            HttpClient client = new HttpClient();
            var empResponse = client.UploadData<ChangePasssword, Boolean>(_emsUri+"/update", changePassword);
            if (empResponse == false)
            {
                Label5.Text = "Failure!!";
                return;
            }
            Label5.Text="Success!!";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}