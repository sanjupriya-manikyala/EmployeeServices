using System;
using Xunit;
using EmployeeService.Tests;
using Moq;
using EmployeeServices.Model;
using EmployeeServices.Services;
using EmployeeServices.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Tests
{
    public class EmployeeServicesTest
    {
        private readonly EmployeeServicesController _employeeController;
        
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _employeeController.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _employeeController.Get().Result as OkObjectResult;
            // Assert
            var employees = Assert.IsType<List<Employee>>(okResult.Value);
            Assert.Equal(3, employees.Count);
        }
    }

}
