using EmployeeApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Infrastructure.Services
{
    public interface IServiceEmployee
    {
        public IEnumerable<Employee> GetEmployees();
        public Employee GetEmployee(string employeeCode);

        public void AddEmployee(Employee employee);
        public void UpdateEmployee(Employee employee);
        public void DeleteEmployee(string employeeCode);
    }
}
