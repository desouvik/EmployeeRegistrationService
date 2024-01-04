using EmployeeRegistrationService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRegistrationService.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                    new Employee { Id = 1, FirstName = "Peter", LastName = "Parker", Email = "spiderman@avengers.com", City = "New York" },
                    new Employee { Id = 2, FirstName = "Bruce", LastName = "Wayne", Email = "batman@avengers.com", City = "New York" },
                    new Employee { Id = 3, FirstName = "Tony", LastName = "Stark", Email = "ironman@avengers.com", City = "New York" },
                    new Employee { Id = 4, FirstName = "Thor", LastName = "Odinson", Email = "thor@avengers.com", City = "New York" }
                );
        }
    }
}
