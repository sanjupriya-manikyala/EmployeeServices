using Xunit;
using EmployeeServices.Model;
using EmployeeServices.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using EmployeeServices.Services;
using AutoFixture;
using AutoFixture.AutoMoq;

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
        public void Add_WhenValidParametersProvided_ReturnsNewEmployeeDetails()
        {

            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var employee = fixture.Create<Employee>();
            var expectedResponse = fixture.Create<Employee>();

            _employeeController.Post(employee);

            //Act
            var result = _employeeController.Post(employee) as CreatedAtActionResult;
            var value = result.Value as Employee;

            //Assert
            Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(expectedResponse, value);
        }


        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            //Arrange
            var fixture = new Fixture();

            var employee = fixture.Create<Employee>();
            //var expectedResponse = fixture.Create<Employee>();

            _employeeController.BadRequest(employee);

            //Act
            var result = _employeeController.Post(employee);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

    }

}
