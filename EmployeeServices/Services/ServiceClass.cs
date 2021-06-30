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
            _employeedetails.Add(newEmp);
            return newEmp;
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeedetails;
        }

        public Guid Remove(Guid id)
        {
            for (var index = _employeedetails.Count - 1; index >= 0; index--)
            {
                if (_employeedetails[index].EId == id)
                {
                    _employeedetails.RemoveAt(index);
                }
            }

            return id;
        }
    }
    }