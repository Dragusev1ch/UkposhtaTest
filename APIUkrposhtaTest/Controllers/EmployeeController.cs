using APIUkrposhtaTest.Services;
using DALUkrposhtaTest.Entity;
using Microsoft.AspNetCore.Mvc;

namespace APIUkrposhtaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // POST api/employee
        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            _employeeService.AddEmployee(employee);
            return Ok();
        }

        // GET api/employee/{id}
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // GET api/employees
        [HttpGet("list")]
        public IActionResult GetEmployees()
        {
            var employees = _employeeService.List();

            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        // PUT api/employee
        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            _employeeService.UpdateEmployee(employee);
            return Ok();
        }

        // DELETE api/employee/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            _employeeService.DeleteEmployee(id);
            return Ok();
        }

        // Можна додати інші методи, залежно від ваших вимог
    }
}
