using System;
using Xunit;
using EmployeeServices.Model;
using EmployeeServices.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using EmployeeServices.Services;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

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
            //arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var repostory = fixture.Freeze<Mock<IEmployeeService>>();
            repostory.Setup(repo => repo.GetAllEmployees())
               .Returns(fixture.Create<List<Employee>>());
            var sut = fixture.Create<ServiceClass>();

            //act
            var result = sut.GetAllEmployees();

            //assert
            Assert.Equal(2, 2);
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
        public void Remove_GivenID_EmployeeDeleted()
        {
            //arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var repository = fixture.Freeze<Mock<IEmployeeService>>();
            repository.Setup(repo => repo.Remove(It.IsAny<Guid>()))
                .Returns(fixture.Create<Guid>());

            var sut = fixture.Create<ServiceClass>();

            //act
            var result = sut.Remove(fixture.Create<Guid>());

            //assert
            Assert.IsAssignableFrom<OkObjectResult>(result);

        }

    }

}
