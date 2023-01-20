using EmployeeApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Infrastructure.Services
{
    public class ServiceEmployee : IServiceEmployee
    {

        private readonly List<Employee> _employees;

        public ServiceEmployee()
        {
            _employees = new List<Employee>()
            {
                new Employee {Id= 1, Name= "Nestea", EmployeeCode="E001", Age= 25, Email="@nestea", UrlPhoto="dhbusdghushgd.jpg", HireDate= DateTime.Now},
                new Employee {Id= 2, Name= "Noah", EmployeeCode="E002", Age= 22, Email="@noah", UrlPhoto="dhbusdghushgd.jpg", HireDate= DateTime.Now},
                new Employee {Id= 3, Name= "Harry", EmployeeCode="E003", Age= 23, Email="@harry", UrlPhoto="dhbusdghushgd.jpg", HireDate= DateTime.Now},
                new Employee {Id= 4, Name= "Anne", EmployeeCode="E004", Age= 24, Email="@anne", UrlPhoto="dhbusdghushgd.jpg", HireDate= DateTime.Now},

            };
        }

        public Employee AddEmployee(Employee Employee)
        {
            _employees.Add(Employee);
            return Employee;
        }

        public Employee GetEmployee(string EmployeeCode)
        {
            var employeeFound= _employees.Where(e => e.EmployeeCode == EmployeeCode).FirstOrDefault();
            if (employeeFound == null) return null;

            return employeeFound;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employees;
        }
    }
}
