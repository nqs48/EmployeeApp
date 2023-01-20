using EmployeeApp.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Domain.Utilities
{
    public static class UtilitiesEmployee
    {
        public static EmployeeDTO mapEmployeeDTO(this Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException();
            }

            return new EmployeeDTO()
            {
                Name = employee.Name,
                Email = employee.Email,
                EmployeeCode = employee.EmployeeCode,
                UrlPhoto = employee.UrlPhoto,
            };
        }
    }
}
