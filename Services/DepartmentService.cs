using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _Context;
        public DepartmentService(AppDbContext Context)
        {
            _Context = Context;
        }
      public  async Task<int> CreateDepartment(DepartmentModel model)
        {
            await _Context.Departments.AddAsync(model);
            return _Context.SaveChanges();
        }

        public async Task<IEnumerable<DepartmentModel>> GetAll()
        {
            var data = await _Context.Departments.ToListAsync();
            return data;
        }
    }
}
