using EmployeeRegistrationService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistrationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly List<Employee> _employees = new List<Employee>() {
            new Employee { Id = 1, FirstName="Peter", LastName="Parker", Email="spiderman@avengers.com", City="New York"},
            new Employee { Id = 2, FirstName = "Bruce", LastName = "Wayne", Email = "batman@avengers.com", City = "New York" },
            new Employee { Id = 3, FirstName = "Tony", LastName = "Stark", Email = "ironman@avengers.com", City = "New York" },
            new Employee { Id = 4, FirstName = "Thor", LastName = "Odinson", Email = "thor@avengers.com", City = "New York" }
            };

        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            _logger.LogInformation("Fetching list of all employees...");
            return Ok(_employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetSingleEmployee(int id)
        {
            if (id == 0 || id == null)
                return BadRequest("Bad Request!");
            var employee = _employees.Find(x => x.Id == id);
            if (employee == null)
                return NotFound("Employee is not found!");
            _logger.LogInformation("Fetching employee with employee id {0}....", id);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> CreateEmployee([FromBody] Employee employee)
        {
            var existingEmployee = _employees.Find(x => x.Email.ToLower() == employee.Email.ToLower());
            if (existingEmployee != null)
            {
                ModelState.AddModelError("Employee Exists", "This employee already exists!");
                _logger.LogError("Employee already exists!");
                return BadRequest(ModelState);
            }
            _employees.Add(employee);
            _logger.LogInformation("New employee added....");
            return Ok(_employees);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            if (id == 0 || id == null)
                return BadRequest("Bad Request!");
            var employee = _employees.Find(x => x.Id == id);
            if (employee == null)
                return NotFound("Employee is not found!");
            _employees.Remove(employee);
            _logger.LogInformation("Employee deleted with id {0}...", id);
            return Ok(_employees);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(int id, [FromBody] Employee request)
        {
            if (id == 0 || id == null)
                return BadRequest("Bad Request!");
            var employee = _employees.Find(x => x.Id == id);
            if (employee == null)
                return NotFound("Employee is not found!");
            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Email = request.Email;
            employee.City = request.City;
            _logger.LogInformation("Employee updated with id {0}...", id);
            return Ok(_employees);
        }
    }
}
