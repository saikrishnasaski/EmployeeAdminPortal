using EmployeeAdminPortal.Data;
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
    
    [HttpGet]
    public IActionResult GetAllEmployees()
    {
        var employees = _appDbContext.Employees.ToList();
        return Ok(employees);
    }
}