using System;
using System.Collections.Generic;
using EmployeeServices.Model;


namespace EmployeeServices.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee Add(Employee newEmp);
        Guid Remove(Guid id);
    }
}
