using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Domain
{
    public class Employee
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public string EmployeeCode { get; set; }
        public string UrlPhoto { get; set; }
        public string Email { get; set; }
        public int Age {get; set;}
        public DateTime HireDate { get; set;}
        public DateTime? TerminationDate { get; set;}


    }
}
