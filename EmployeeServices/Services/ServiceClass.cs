using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeServices.Model;

namespace EmployeeServices.Services
{
    public class ServiceClass : IEmployeeService
    {


        public Employee Add(Employee newEmp)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Guid Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
    }