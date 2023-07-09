using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly AppDbContext _Context;
        private readonly IEmployeeService _Employee;
        public EmployeeAPIController(AppDbContext context, IEmployeeService Employee)
        {
            _Context = context;
            _Employee = Employee;
        }



        [HttpGet]
        public List<EmployeeModel> GetEmployeeModel(int skipcount=0,int take=0 ,string search ="")
        {
            if (_Context.Employees == null)
            {
                return null;
            };
            IQueryable<EmployeeModel> query = _Context.Employees;
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(e => e.Fullname.Contains(search) || e.Address.Contains(search) || e.Branch.Contains(search));
            }

                var data = query
                .Skip(skipcount)
                .Take(take)
                .ToList();
            if (data == null)
            {
                return null;
            }
            return data;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeModel(int id)
        {
            if (_Context.Employees== null)
            {
                return NotFound();
            }
            var employee = await _Employee.GetEmployee(id);

            if (employee == null)
            {
                return NotFound();
            }

            return (IActionResult)employee;
        }

        [HttpPut("{id}")]
        public IActionResult PutEmployeeModel(int id, EmployeeModel employeemodel)
        {
            if (id != employeemodel.Id)
            {
                return BadRequest();
            }
            _Employee.UpdateEmployee(employeemodel);
           
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> PostEmployee(EmployeeModel model)
        {
            await  _Employee.CreateEmployee(model);
            return CreatedAtAction("GetEmployeeModel", new { id = model.Id, }, model);
        }

        [HttpDelete("{id}")]
        public void DeleteEmployee(int id)
        {
              _Employee.DeleteEmployee(id);
        }
        }
    }
