using EmployeeApp.Domain;
using EmployeeApp.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<Employee> GetAll()
        {
            return _serviceEmployee.GetEmployees();
        }

    }
}
