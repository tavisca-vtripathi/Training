using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
namespace Tavisca.WCF.DAL
{
    public class FileSystem
    {
        public void SaveEmployee(string jsonString, string id)
        {
            if (File.Exists(@"D:\EmployeeID\ID.Txt") == false)
            {

                throw new System.Exception("Directory not present");
            }
           

            File.WriteAllText(@"D:\EmployeeDetails\" + id + ".Txt", jsonString);


        }
        public string RetrieveById(String id)
        {
            var jsonString = File.ReadAllText(@"D:\EmployeeDetails\" + id );
            return jsonString;
        }

        public List<string> RetrieveAllIds()
       {
           DirectoryInfo dir = new DirectoryInfo(@"D:\EmployeeDetails");
           var files = dir.GetFiles("*.txt");
            List<string> empId=new List<string>();
            
            
           foreach (var file in files)
           {
            empId.Add(file.Name);   
           }
           return empId;
          
       }
    }
}
