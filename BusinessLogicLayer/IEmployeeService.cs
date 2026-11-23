using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();

        Task AddEmployee(Employee employee);

        Task<Employee> GetEmployeeByIdAsync(int id); // Gettting employee by id so that we can use it for Edit and Details

        Task EditEmployee(Employee employee);

        Task EmployeeDetails(Employee employee);
    }
}