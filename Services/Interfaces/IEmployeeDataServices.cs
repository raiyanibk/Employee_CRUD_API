using Common.Response;
using SqlDBLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEmployeeDataServices
    {
        Task<IEnumerable<Employee>> GetEmployees(string filter, int? pageSize, int? pageNo);
        Task<ApiResponse<int>> SaveEmployee(Employee employee);
        Task<ApiResponse<bool>> UpdateEmployee(Employee employee);
        Task<ApiResponse<bool>> DeleteEmployee(int id);
    }
}
