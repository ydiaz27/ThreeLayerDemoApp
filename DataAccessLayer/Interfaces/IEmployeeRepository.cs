using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IEmployeeRepository
    {
        //this is a blueprint that classes can use to implement methods
        //in this blueprint, we will declare the methods without their functionality,
        //and whichever class uses the interface, would be invalid without using all of the methods and adding functionality to them that are declared in this interface
        Task<IEnumerable<Employee>> GetEmployeesAsync(); //now this method, as well as any other method that is created in here needs to be implemented in whichever class implements this interface

        Task AddEmployee(Employee employee);

        Task<Employee> GetEmployeeByIdAsync(int id); // Gettting employee by id so that we can use it for Edit and Details

        Task EditEmployee(Employee employee);

        Task EmployeeDetails(Employee employee);
    }
}
