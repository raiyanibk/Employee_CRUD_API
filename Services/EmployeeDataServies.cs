using Services.Interfaces;
using SqlDBLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Common.Response;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeeDataServies : IEmployeeDataServices
    {
        EmployeeContext _context;
        public EmployeeDataServies(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees(string filter, int? pageSize, int? pageNo)
        {
            var employees = _context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                employees = employees.Where(a => (string.IsNullOrEmpty(a.Name) || a.Name.ToLower().Contains(filter)) 
                                                && (string.IsNullOrEmpty(a.Address) || a.Address.ToLower().Contains(filter))
                                                && (string.IsNullOrEmpty(a.Designation) || a.Designation.ToLower().Contains(filter))
                                                );
            }

            #region Pagination
            
            if(pageSize.HasValue && pageNo.HasValue)
                employees = employees.Skip((pageNo.Value - 1) * pageSize.Value).Take(pageSize.Value);

            #endregion

            return employees;
        }

        public async Task<ApiResponse<int>> SaveEmployee(Employee employee)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Employees.Update(employee);
                    _context.SaveChanges();

                    transaction.Commit();

                    return await Task.FromResult(new ApiResponse<int>
                    {
                        Data = employee.Id,
                        Success = true,
                        Message = "New Employee Created successfully"
                    });
                }
                catch (Exception ex)
                {
                    return await Task.FromResult(new ApiResponse<int>
                    {
                        Data = 0,
                        Success = false,
                        Message = ex.Message
                    });
                }
            }
        }

        public async Task<ApiResponse<bool>> UpdateEmployee(Employee employee)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Employees.Update(employee);
                    _context.SaveChanges();

                    transaction.Commit();

                    return await Task.FromResult(new ApiResponse<bool>
                    {
                        Data = true,
                        Success = true,
                        Message = "Employee Updated successfully"
                    });
                }
                catch (Exception ex)
                {
                    return await Task.FromResult(new ApiResponse<bool>
                    {
                        Data = false,
                        Success = false,
                        Message = ex.Message
                    });
                }
            }
        }

        public async Task<ApiResponse<bool>> DeleteEmployee(int id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var deleteRecord = _context.Employees.FirstOrDefault(a => a.Id == id);
                    if (deleteRecord == null)
                        return new ApiResponse<bool>
                        {
                            Data = false,
                            Success = false,
                            Message = "Record not found to delete"
                        };

                    _context.Employees.Remove(deleteRecord);
                    _context.SaveChanges();

                    transaction.Commit();

                    return await Task.FromResult(new ApiResponse<bool>
                    {
                        Data = true,
                        Success = true,
                        Message = "Employee Deleted successfully"
                    });
                }
                catch (Exception ex)
                {
                    return await Task.FromResult(new ApiResponse<bool>
                    {
                        Data = false,
                        Success = false,
                        Message = ex.Message
                    });
                }
            }
        }
    }
}
