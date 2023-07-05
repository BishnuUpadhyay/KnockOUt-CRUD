using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly AppDbContext _Context;
        public EmployeeAPIController(AppDbContext context)
        {
            _Context = context;
        }



        [HttpGet]
        public List<EmployeeModel> GetEmployeeModel(int skipcount=0,int take=0 ,string search ="")
        {
            if (_Context.Employees == null)
            {
                return null;
            };
            var query = _Context.Employees.AsQueryable();
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
        public async Task<ActionResult<EmployeeModel>> GetEmployeeModel(int id)
        {
            if (_Context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _Context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeModel(int id, EmployeeModel employeemodel)
        {
            if (id != employeemodel.Id)
            {
                return BadRequest();
            }

            _Context.Entry(employeemodel).State = EntityState.Modified;

            try
            {
                await _Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }

            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> PostEmployee(EmployeeModel model)
        {
            _Context.Employees.Add(model);
            await _Context.SaveChangesAsync();
            return CreatedAtAction("GetEmployeeModel", new { id = model.Id, }, model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (_Context.Employees == null)
            {
                return NotFound();
            }
            var EmployeeModel = await _Context.Employees.FindAsync(id);
            if (EmployeeModel == null)
            {
                return NotFound();
            }
            _Context.Employees.Remove(EmployeeModel);
            await _Context.SaveChangesAsync();

            return NoContent();
        }


        }
    }
