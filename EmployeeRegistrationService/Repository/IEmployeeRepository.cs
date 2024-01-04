using EmployeeRegistrationService.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistrationService.Repository
{
    public interface IEmployeeRepository
    {
        public List<Employee>? GetEmployees();

        public Employee? GetSingleEmployee(int id);

        public List<Employee>? CreateEmployee([FromBody] Employee employee);

        public List<Employee>? DeleteEmployee(int id);

        public List<Employee>? UpdateEmployee(int id, [FromBody] Employee request);
    }
}
