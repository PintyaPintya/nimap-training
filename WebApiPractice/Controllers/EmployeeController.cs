using Microsoft.AspNetCore.Mvc;
using WebApiPractice.Models;

namespace WebApiPractice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private List<Employee> Employees = new List<Employee>()
        {
            new Employee(){ Id = 1, Name = "Anurag", Age = 28, Salary=1000, Gender = "Male", Department = "IT" },
            new Employee(){ Id = 2, Name = "Pranaya", Age = 28, Salary=2000, Gender = "Male", Department = "IT" },
        };

    [HttpGet]
    public ActionResult<List<EmployeeDto>> GetEmployees()
    {
        List<EmployeeDto> employees = new List<EmployeeDto>();

        foreach (var employee in Employees)
        {
            EmployeeDto emp = new EmployeeDto()
            {
                Name = employee.Name,
                Age = employee.Age,
                Gender = employee.Gender,
                Department = employee.Department
            };
            employees.Add(emp);
        }

        return Ok(employees);
    }

    [HttpPost]
    public ActionResult<EmployeeDto> AddEmployee(EmployeeDto employee)
    {
        if(employee == null) return BadRequest();

        Employee emp = new Employee()
        {
            Id = Employees.Count + 1,
            Salary = 3000,

            Name = employee.Name,
            Age = employee.Age,
            Gender = employee.Gender,
            Department = employee.Department
        };

        Employees.Add(emp);

        return Ok(employee);
    }
}
