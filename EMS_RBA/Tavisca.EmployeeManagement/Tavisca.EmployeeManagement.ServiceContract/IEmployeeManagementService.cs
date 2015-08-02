﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.DataContract;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Tavisca.EmployeeManagement.ServiceContract
{
    [ServiceContract]
    public interface IEmployeeManagementService
    {
        [WebInvoke(Method="POST", UriTemplate="employee", RequestFormat= WebMessageFormat.Json, ResponseFormat= WebMessageFormat.Json)]
        Employee Create(Employee employee);

        [WebInvoke(Method = "POST", UriTemplate = "employee/{employeeId}/remark", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Remark AddRemark(string employeeId, Remark remark);

        [WebInvoke(Method = "POST", UriTemplate = "login", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Employee CheckCredentials(Credentials credentials);

        [WebInvoke(Method = "POST", UriTemplate = "change_password", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        string ModifyCredentials(CredentialModifier newCredentials);
    }
}
