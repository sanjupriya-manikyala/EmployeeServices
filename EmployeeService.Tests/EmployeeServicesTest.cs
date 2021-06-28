using System;
using Xunit;
using EmployeeServices.Model;
using EmployeeServices.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using EmployeeServices.Services;

namespace EmployeeService.Tests
{
    public class EmployeeServicesTest
    {
        private readonly EmployeeServicesController _employeeController;
        private Mock<IEmployeeService> _mockEmployeesList;

        public EmployeeServicesTest()
        {
            _mockEmployeesList = new Mock<IEmployeeService>();
            _employeeController = new EmployeeServicesController(_mockEmployeesList.Object);
        }

        [Fact]
        public void GetTest_ReturnsListofEmployees()
        {
           
            var result = _employeeController.Get();
            Assert.IsAssignableFrom<ActionResult<List<Employee>>>(result);


        }

        [Fact]
        public void Get_ActionExecutes_ReturnsExactNumberOfEmployees()
        {
            _mockEmployeesList.Setup(repo => repo.GetAllEmployees())
               .Returns(new List<Employee>() { new Employee(), new Employee() });
            var result = _employeeController.Get();
            var viewResult = Assert.IsAssignableFrom<ActionResult<List<Employee>>>(result);
            var employees = Assert.IsType<List<Employee>>(viewResult.Value);
            Assert.Equal(2, employees.Count);
        }


    }

}
