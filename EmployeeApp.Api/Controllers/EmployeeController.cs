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

    }
}
