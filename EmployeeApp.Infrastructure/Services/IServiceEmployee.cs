﻿using EmployeeApp.Domain;
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
        public Employee GetEmployee(string EmployeeCode);

        public Employee AddEmployee(Employee Employee);
    }
}
