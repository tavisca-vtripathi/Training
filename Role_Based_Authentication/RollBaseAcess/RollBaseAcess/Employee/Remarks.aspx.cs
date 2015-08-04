using RollBaseAcess.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace RollBaseAcess
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string _esUri = ConfigurationManager.AppSettings["ESUri"];
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Employee empObject = ((Model.Session.Employee)Session["Response"]).ToServer();

                ////- (Label)Master.FindControl("Label1").Text = "Welcome " + empObject.FirstName;
                //if (empObject.Title == "Hr" || empObject == null)
                //{
                //    Response.Redirect("Login.aspx");
                //}
                if (Page.IsPostBack == false)
                {
                    HttpClient client = new HttpClient();
                    var response = client.GetData<string>(_esUri + "/remarkCount/" + empObject.Id + " ", "application/json");
                    GridView1.VirtualItemCount = Convert.ToInt32(response);
                    GridView1.DataSource = GetRemarks(empObject.Id, 1);
                    GridView1.DataBind();
                }
            }
            catch (Exception)
            {
                FormsAuthentication.RedirectToLoginPage();

            }

        }

        public List<Remark> GetRemarks(string employeeId, int pageNumber)
        {
            HttpClient client = new HttpClient();
            var response = client.GetData<Employee>(_esUri + "/employee/" + employeeId + "/" + pageNumber + "", "application/json");
            List<Remark> remarklList = new List<Remark>();
            remarklList = response.Remarks;



            return remarklList;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProfile.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Employee empObject = (Employee)Session["Response"];
            int pageNo = e.NewPageIndex;
            GridView1.PageIndex = pageNo;
            GridView1.DataSource = GetRemarks(empObject.Id, pageNo + 1);
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");


        }

    }
}