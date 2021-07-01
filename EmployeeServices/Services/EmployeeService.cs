using System.Collections.Generic;
using EmployeeServices.Model;

namespace EmployeeServices.Services
{
    public class EmployeeService : IEmployeeService
    {
        private List<Employee> _employeedetails;

        public Employee Add(Employee newEmp)
        {
            _employeedetails.Add(newEmp);
            return newEmp;
        }

        
    }
    }