using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ThreeLayerDemoApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await employeeService.GetEmployeesAsync(); //this makes sure the business logic gets processed before returning the view
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            await employeeService.AddEmployee(employee);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await employeeService.GetEmployeeByIdAsync(id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employeeToEdit)
        {
            var employee = await employeeService.GetEmployeeByIdAsync(employeeToEdit.Id);
            
            if (employee != null)
            {
                employee.FirstName = employeeToEdit.FirstName;
                employee.LastName = employeeToEdit.LastName;
                employee.Position = employeeToEdit.Position;
                employee.Salary = employeeToEdit.Salary;

                await employeeService.EditEmployee(employee);
                return RedirectToAction(nameof(Index));
            }

            return View(employeeToEdit);
        }

        [HttpGet] 
        public async Task<IActionResult> Details(int id)
        {
            var employee = await employeeService.GetEmployeeByIdAsync(id);
            await employeeService.EmployeeDetails(employee);
            return View(employee);
        }
    }
}