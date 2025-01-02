using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Mapper;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly AppDBContext _appDbContext;

    public EmployeesController(AppDBContext _appDbContext)
    {
        this._appDbContext = _appDbContext;
    }

    [HttpPost]
    public IActionResult CreateEmployee([FromBody] CreateEmployeeRequest createEmployeeRequest)
    {
        var employee = createEmployeeRequest.Adapt<Employee>();
        employee.Id = Guid.NewGuid();
        _appDbContext.Employees.Add(employee);
        _appDbContext.SaveChanges();

        return Ok(employee);
    }
    
    [HttpGet]
    public IActionResult GetAllEmployees()
    {
        var employees = _appDbContext.Employees.ToList();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public IActionResult GetEmployee(Guid id)
    {
        var employee = _appDbContext.Employees.Find(id);

        if (employee is null)
        {
            return NotFound();
        }
        
        return Ok(employee);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateEmployee(Guid id, [FromBody] UpdateEmployeeRequest updateEmployeeRequest)
    {
        var employee = _appDbContext.Employees.Find(id);

        if (employee is null)
        {
            return NotFound();
        }

        employee.Name = updateEmployeeRequest.Name;
        employee.Email = updateEmployeeRequest.Email;
        employee.Phone = updateEmployeeRequest.Phone;
        employee.Salary = updateEmployeeRequest.Salary;
        
        _appDbContext.SaveChanges();
        
        return Ok(employee);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteEmployee(Guid id)
    {
        var employee = _appDbContext.Employees.Find(id);

        if (employee is null)
        {
            return NotFound();
        }
        
        _appDbContext.Employees.Remove(employee);
        _appDbContext.SaveChanges();
        return Ok(employee);
    }
}