using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentAPIController : ControllerBase
    {
        private readonly AppDbContext _context;
        private IDepartmentService _service;
        public DepartmentAPIController(AppDbContext context, IDepartmentService service)
        {
            _context = context;
            _service = service;
        }
        [HttpGet]
        public async Task<List<DepartmentModel>> GetAllDepartment()
        {
            
            if(_context.Departments == null)
            {
                return null;
            }
            var data =await _service.GetAll();
            if(data == null)
            {
                return null;
            }
            return (List<DepartmentModel>)data;
        }

        [HttpPost]
        public async Task<IActionResult> PostDepartment(DepartmentModel depart)
        {
            try
            {
               await _service.CreateDepartment(depart);
                _context.SaveChanges();
                return Ok("Department created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
