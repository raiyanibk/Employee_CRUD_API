using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SqlDBLayer.Models;
using System.Threading.Tasks;

namespace WEBApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        /// <summary>
        /// Get Employee
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getemployees")]
        public async Task<IActionResult> GetEmployees(string filter, int? pageSize, int? pageNo)
        {
            var response = await _employeeService.GetEmployees(filter, pageSize, pageNo);

            return Ok(response);
        }

        /// <summary>
        /// Save Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("saveemployee")]
        public async Task<IActionResult> SaveEmployee([FromBody] Employee employee)
        {
            var response = await _employeeService.SaveEmployee(employee);

            return Ok(response);
        }

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("updateemployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            var response = await _employeeService.UpdateEmployee(employee);

            return Ok(response);
        }

        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("deleteemployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var response = await _employeeService.DeleteEmployee(id);

            return Ok(response);
        }
    }
}
