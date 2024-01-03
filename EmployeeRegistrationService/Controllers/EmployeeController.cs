using EmployeeRegistrationService.Models;
using EmployeeRegistrationService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistrationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            _logger.LogInformation("Fetching list of all employees...");
            var result = _employeeRepository.GetEmployees();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetSingleEmployee(int id)
        {
            if (id == 0 || id == null)
                return BadRequest("Bad Request!");
            var result = _employeeRepository.GetSingleEmployee(id);
            if (result == null)
                return NotFound("Employee is not found!");
            _logger.LogInformation("Fetching employee with employee id {0}....", id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> CreateEmployee([FromBody] Employee employee)
        {
            var result = _employeeRepository.CreateEmployee(employee);
            if (result == null)
            {
                ModelState.AddModelError("Employee Exists", "This employee already exists!");
                _logger.LogError("Employee already exists!");
                return BadRequest(ModelState);
            }
            _logger.LogInformation("New employee added....");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            if (id == 0 || id == null)
                return BadRequest("Bad Request!");
            var result = _employeeRepository.DeleteEmployee(id);    
            if (result == null)
                return NotFound("Employee is not found!");
            _logger.LogInformation("Employee deleted with id {0}...", id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(int id, [FromBody] Employee request)
        {
            if (id == 0 || id == null)
                return BadRequest("Bad Request!");
            var result = _employeeRepository.UpdateEmployee(id, request);
            if (result == null)
                return NotFound("Employee is not found!");
            
            _logger.LogInformation("Employee updated with id {0}...", id);
            return Ok(result);
        }
    }
}
