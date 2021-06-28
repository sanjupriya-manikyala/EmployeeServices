using System;
using System.Collections.Generic;
using EmployeeServices.Model;

namespace EmployeeServices.Services
{
    public class ServiceClass : IEmployeeService
    {
        private List<Employee> _employeedetails;

        public Employee Add(Employee newEmp)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeedetails;
        }

        public Guid Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
    }