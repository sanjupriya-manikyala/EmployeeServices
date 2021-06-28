using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EmployeeServices.Model;
using EmployeeServices.Services;

namespace EmployeeServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeServicesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeServicesController(IEmployeeService service)
        {
            _service = service;
        }

        // GET api/employeeslist
        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            var employees = _service.GetAllEmployees();
            return Ok(employees);
        }

        // POST api/addemployees
        [HttpPost]
        public ActionResult Post([FromBody] Employee value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = _service.Add(value);
            return CreatedAtAction("Get", new { id = employee.EId }, employee);
        }

        // DELETE api/removeemployee/5
        [HttpDelete("{id}")]
        public ActionResult<Guid> Remove(Guid id)
        {
            _service.Remove(id);
            return id;
        }
    }
    }

