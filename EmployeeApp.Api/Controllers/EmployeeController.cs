using EmployeeApp.Domain;
using EmployeeApp.Domain.DTO;
using EmployeeApp.Domain.Utilities;
using EmployeeApp.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using System.Collections.Immutable;
using System.Runtime.InteropServices;

namespace EmployeeApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceEmployee _serviceEmployee;

        public EmployeeController(IServiceEmployee serviceEmployee)
        {
            _serviceEmployee = serviceEmployee;
        }



        [HttpGet("all")]
        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            return (await _serviceEmployee.GetEmployees()).Select(e => e.mapEmployeeDTO());

        }



        [HttpGet("get/{EmployeeCode}")]
        public async Task<ActionResult<EmployeeDTO>> EmployeeGetById(string EmployeeCode)
        {
            var employeeFound = (await _serviceEmployee.GetEmployee(EmployeeCode)).mapEmployeeDTO();
            if (employeeFound == null) return NotFound("Employee not found");
            return employeeFound;

        }



        [HttpPost("add")]
        public async Task<ActionResult<EmployeeDTO>> AddEmployee(EmployeeDTO employeeDTO)
        {
            var employee = new Employee()
            {
                Name = employeeDTO.Name,
                EmployeeCode = employeeDTO.EmployeeCode,
                UrlPhoto = employeeDTO.UrlPhoto,
                Email = employeeDTO.Email,
                Age = employeeDTO.Age,
                HireDate= DateTime.Now,
            };

            await _serviceEmployee.AddEmployee(employee);
            return employee.mapEmployeeDTO();
        }




        [HttpPut("update")]
        public async Task<ActionResult<EmployeeDTO>> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            var employeeFound = await _serviceEmployee.GetEmployee(employeeDTO.EmployeeCode);
            if(employeeFound == null) return NotFound();

            employeeFound.EmployeeCode = employeeDTO.EmployeeCode;
            employeeFound.Name= employeeDTO.Name;
            employeeFound.Email= employeeDTO.Email;
            employeeFound.Age= employeeDTO.Age;
            employeeFound.UrlPhoto= employeeDTO.UrlPhoto;

             await _serviceEmployee.UpdateEmployee(employeeFound);
            return employeeDTO;

        }



        [HttpDelete("delete/{EmployeeCode}")]
        public async Task<ActionResult<EmployeeDTO>> DeleteEmployee(string EmployeeCode)
        {
            var employeeFound= await _serviceEmployee.GetEmployee(EmployeeCode);
            if(employeeFound == null) return NotFound();
            await _serviceEmployee.DeleteEmployee(EmployeeCode);
            return employeeFound.mapEmployeeDTO();
        }



    }

    
}
