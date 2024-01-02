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
        private static readonly List<Employee> _employees = new List<Employee>() {
            new Employee { Id = 1, FirstName="Peter", LastName="Parker", Email="spiderman@avengers.com", City="New York"},
            new Employee { Id = 2, FirstName = "Bruce", LastName = "Wayne", Email = "batman@avengers.com", City = "New York" },
            new Employee { Id = 3, FirstName = "Tony", LastName = "Stark", Email = "ironman@avengers.com", City = "New York" },
            new Employee { Id = 4, FirstName = "Thor", LastName = "Odinson", Email = "thor@avengers.com", City = "New York" }
            };

        public EmployeeController() { }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return Ok(_employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetSingleEmployee(int id)
        {
            var employee = _employees.Find(x => x.Id == id);
            if (employee == null)
                return NotFound("Employee is not found!");
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> CreateEmployee([FromBody]Employee employee)
        {
            _employees.Add(employee);
            return Ok(_employees);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            var employee = _employees.Find(x=> x.Id == id);
            if (employee == null)
                return NotFound("Employee is not found!");
            _employees.Remove(employee);
            return Ok(_employees);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(int id, [FromBody]Employee request)
        {
            var employee = _employees.Find(x=>x.Id == id);
            if (employee == null)
                return NotFound("Employee is not found!");
            employee.FirstName=request.FirstName;
            employee.LastName=request.LastName;
            employee.Email=request.Email;
            employee.City=request.City;

            return Ok(_employees);
        }
    }
}
