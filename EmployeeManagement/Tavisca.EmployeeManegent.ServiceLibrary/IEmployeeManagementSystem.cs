﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using Tavisca.EmployeeManagement.DataContract;
namespace Tavisca.EmployeeManagement.ServiceContract
{

    [ServiceContract]
    public interface IEmployeeManagementService
    {

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Employee Create(Employee employee);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/addremark/{employeeId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Remark AddRemark(string employeeId, Remark remark);


    }
}

