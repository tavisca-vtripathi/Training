﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.ServiceContract;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.Translator;
using Tavisca.EmployeeManagement.EnterpriseLibrary;

namespace Tavisca.EmployeeManagement.ServiceImpl
{
    public class EmployeeManagementService : IEmployeeManagementService
    {
        public EmployeeManagementService(IEmployeeManagementManager manager)
        {
            _manager = manager;
        }

        IEmployeeManagementManager _manager;

        public DataContract.Employee Create(DataContract.Employee employee)
        {
            try
            {
                employee.JoiningDate = DateTime.UtcNow;
                var result = _manager.Create(employee.ToDomainModel());
                if (result == null) return null;
                return result.ToDataContract();
            }
            catch (Exception ex)
            {
                Exception newEx;
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex, out newEx);
                throw newEx;
            }
        }

        public DataContract.Remark AddRemark(string employeeId, DataContract.Remark remark)
        {
            try
            {
                var result = _manager.AddRemark(employeeId, remark.ToDomainModel());
                if (result == null) return null;
                return result.ToDataContract();
            }
            catch (Exception ex)
            {
                Exception newEx;
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex, out newEx);
                throw newEx;
            }
        }

        public DataContract.Employee Authenticate(DataContract.Credentials credentials)
        {
            var result = _manager.Authenticate(credentials.EmailId, credentials.Password);
            if (result == null)
            {
                return null;
            }
            return result.ToDataContract();
        }
        
        public bool UpdatePassword(DataContract.ChangePassword changePassword)
         {
             try
             {
                var result = _manager.UpdatePassword(changePassword.OldPassword,changePassword.NewPassword,changePassword.EmailId);
                  if (result == false) return false;
                  return result;

             }
             catch (Exception ex)
             {
                 Exception newEx;
                 var rethrow = ExceptionPolicy.HandleException("service.policy", ex, out newEx);
                 throw newEx;
             }

         }
    }
}
