using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            //business logic would be written here 
            return await _employeeRepository.GetEmployeesAsync();
        } 

        // Implementation for interface method with correct spelling
       public async Task AddEmployee(Employee employee)
       {
            if (employee.Salary <= 250_000)
            {
                await _employeeRepository.AddEmployee(employee);
            } else
            {
                throw new ArgumentException("Salary cannot exceed 250,000.");
            }
       }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task EditEmployee(Employee employee)
        {
            await _employeeRepository.EditEmployee(employee);
        }

        public async Task EmployeeDetails(Employee employee)
        {
            await _employeeRepository.EmployeeDetails(employee);
        }
    }
}