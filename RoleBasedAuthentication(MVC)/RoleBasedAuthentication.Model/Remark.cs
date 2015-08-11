
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;



namespace RollBasedAuthentication.Model
{
    [DataContract]
    public class Remark
    {
        
        private string _emsUri = ConfigurationManager.AppSettings["EMSUri"];
       
        private string _esUri = ConfigurationManager.AppSettings["ESUri"];
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public DateTime CreateTimeStamp { get; set; }
        
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.Text))
                throw new Exception("Text cannot be null or empty.");
        }

        public Dictionary<string, string> ShowEmployee()
        {
            Dictionary<string, string> empRecord = new Dictionary<string, string>();
            var client = new HttpClient();
            var empResponse = client.GetData<GetAllEmployee>(_esUri + "/employee");
            if (empResponse == null)
            {
                return null;
            }
            foreach (var employeeRecord in empResponse.AllEmployeeList.OrderBy(employee => employee.FirstName))
            {
                empRecord.Add(employeeRecord.FirstName + " " + employeeRecord.LastName, employeeRecord.Id);
            }

            return empRecord;
        }

        public Status Add(int employeeId, Remark remark)
        {
            HttpClient client = new HttpClient();
            var empRespone = client.UploadData<Remark, RemarkResponse>(_emsUri + "/employee/" + employeeId + "/remark", remark);

            return empRespone.Status;
        }

        public EmployeeResponse GetRemark(string employeeId, int pageNumber)
        {
            HttpClient client = new HttpClient();
            var response = client.GetData<EmployeeResponse>(_esUri + "/employee/" + employeeId + "/" + pageNumber + "", "application/json");
            return response;
        }
    }
}
