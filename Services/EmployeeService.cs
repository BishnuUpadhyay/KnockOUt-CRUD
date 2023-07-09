using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Services
{
    public class EmployeeService : IEmployeeService
      
    
    {
        private readonly AppDbContext _Context;
        private readonly IHttpContextAccessor _contextAccessor;

        public EmployeeService(AppDbContext Context,IHttpContextAccessor contextAccessor)
        {
            _Context = Context;
            _contextAccessor = contextAccessor;
        }

        public void DeleteEmployee(int id)
        {
            var data = _Context.Employees.FirstOrDefault(e => e.Id == id);
            if (data == null)
            {
               
            }
            _Context.Employees.Remove(data);
            _Context.SaveChanges();

        }

      public async  Task<EmployeeModel> GetEmployee(int id)
        {
            var data = await _Context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (data == null)
            {
                return null;
            }
            return data;
        }

      public async  Task<IEnumerable<EmployeeModel>> GetAll()
        {
            var data = await _Context.Employees.ToListAsync();
            return data;
        }

        async Task<int> IEmployeeService.UpdateEmployee(EmployeeModel model)
        {
            _Context.Employees.Update(model);
            return await _Context.SaveChangesAsync();
        }

        async Task<int> IEmployeeService.CreateEmployee(EmployeeModel model)
        {
          await  _Context.Employees.AddAsync(model);
            return  _Context.SaveChanges();
        }
    }
}
