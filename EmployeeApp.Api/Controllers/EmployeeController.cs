using EmployeeApp.Domain;
using EmployeeApp.Domain.DTO;
using EmployeeApp.Domain.Utilities;
using EmployeeApp.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace EmployeeApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceEmployee _serviceEmployee;

        public EmployeeController(IServiceEmployee serviceEmployee)
        {
            this._serviceEmployee = serviceEmployee;
        }

        [HttpGet("all")]
        public IEnumerable<EmployeeDTO> GetAll()
        {
            return _serviceEmployee.GetEmployees().Select(e => e.mapEmployeeDTO());

        }

        [HttpGet("get/{EmployeeCode}")]
        public ActionResult<EmployeeDTO> EmployeeGetById(string EmployeeCode)
        {
            var employeeFound = this._serviceEmployee.GetEmployee(EmployeeCode).mapEmployeeDTO();
            if (employeeFound == null) return NotFound();
            return employeeFound;

        }

        [HttpPost("add")]
        public ActionResult<EmployeeDTO> AddEmployee(EmployeeDTO employeeDTO)
        {
            var employee = new Employee()
            {
                Id= _serviceEmployee.GetEmployees().Count() + 1,
                Name = employeeDTO.Name,
                EmployeeCode = employeeDTO.EmployeeCode,
                UrlPhoto = employeeDTO.UrlPhoto,
                Email = employeeDTO.Email,
                Age = employeeDTO.Age,
                HireDate= DateTime.Now,
            };

            return _serviceEmployee.AddEmployee(employee).mapEmployeeDTO();

       
        }


    }

    
}
