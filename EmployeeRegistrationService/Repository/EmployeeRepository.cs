using EmployeeRegistrationService.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistrationService.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new List<Employee>() {
            new Employee { Id = 1, FirstName="Peter", LastName="Parker", Email="spiderman@avengers.com", City="New York"},
            new Employee { Id = 2, FirstName = "Bruce", LastName = "Wayne", Email = "batman@avengers.com", City = "New York" },
            new Employee { Id = 3, FirstName = "Tony", LastName = "Stark", Email = "ironman@avengers.com", City = "New York" },
            new Employee { Id = 4, FirstName = "Thor", LastName = "Odinson", Email = "thor@avengers.com", City = "New York" }
            };

        public List<Employee> GetEmployees()
        {
            return _employees;
        }

        public Employee? GetSingleEmployee(int id)
        {
            var employee = _employees.Find(x => x.Id == id);
            return employee;
        }

        public List<Employee>? CreateEmployee([FromBody] Employee employee)
        {
            var existingEmployee = _employees.Find(x => x.Email.ToLower() == employee.Email.ToLower());
            if (existingEmployee != null)
            {
                return null;
            }
            _employees.Add(employee);
            return _employees;
        }

        public List<Employee>? DeleteEmployee(int id)
        {
            var employee = _employees.Find(x => x.Id == id);
            if (employee == null)
                return null;
            _employees.Remove(employee);
            return _employees;
        }

        public List<Employee>? UpdateEmployee(int id, [FromBody] Employee request)
        {
            var employee = _employees.Find(x => x.Id == id);
            if (employee == null)
                return null;
            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Email = request.Email;
            employee.City = request.City;
            return _employees;
        }
    }
}
