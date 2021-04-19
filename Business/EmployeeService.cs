using Business.Interfaces;
using Common.Response;
using Services.Interfaces;
using SqlDBLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeDataServices _employeeDataServices;
        public EmployeeService(IEmployeeDataServices employeeDataServices)
        {
            _employeeDataServices = employeeDataServices;
        }

        public Task<ApiResponse<bool>> DeleteEmployee(int id)
        {
            return _employeeDataServices.DeleteEmployee(id);
        }

        public Task<IEnumerable<Employee>> GetEmployees(string filter, int? pageSize, int? pageNo)
        {
            return _employeeDataServices.GetEmployees(filter, pageSize, pageNo);
        }

        public Task<ApiResponse<int>> SaveEmployee(Employee employee)
        {
            return _employeeDataServices.SaveEmployee(employee);
        }

        public Task<ApiResponse<bool>> UpdateEmployee(Employee employee)
        {
            return _employeeDataServices.UpdateEmployee(employee);
        }
    }
}
