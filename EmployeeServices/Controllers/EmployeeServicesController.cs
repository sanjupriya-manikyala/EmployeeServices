using Microsoft.AspNetCore.Mvc;
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

    }
    }

