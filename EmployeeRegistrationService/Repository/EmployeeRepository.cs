using EmployeeRegistrationService.Data;
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
        private readonly DataContext _dataContext;

        public EmployeeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Employee>? GetEmployees()
        {
            return _dataContext.Employees.ToList();
        }

        public Employee? GetSingleEmployee(int id)
        {
            var employee = _dataContext.Employees.ToList().Find(x => x.Id == id);
            return employee;
        }

        public List<Employee>? CreateEmployee([FromBody] Employee employee)
        {
            var existingEmployee = _dataContext.Employees.ToList().Find(x => x.Email.ToLower() == employee.Email.ToLower());
            if (existingEmployee != null)
            {
                return null;
            }
            _dataContext.Employees.Add(employee);
            _dataContext.SaveChanges();
            return _dataContext.Employees.ToList();
        }

        public List<Employee>? DeleteEmployee(int id)
        {
            var employee = _dataContext.Employees.ToList().Find(x => x.Id == id);
            if (employee == null)
                return null;
            _dataContext.Employees.Remove(employee);
            _dataContext.SaveChanges();
            return _dataContext.Employees.ToList() ;
        }

        public List<Employee>? UpdateEmployee(int id, [FromBody] Employee request)
        {
            var employee = _dataContext.Employees.ToList().Find(x => x.Id == id);
            if (employee == null)
                return null;
            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Email = request.Email;
            employee.City = request.City;
            _dataContext.Employees.Update(employee);
            _dataContext.SaveChanges();
            return _dataContext.Employees.ToList();
        }
    }
}
