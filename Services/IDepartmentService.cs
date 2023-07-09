using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IDepartmentService
    {
        public Task<IEnumerable<DepartmentModel>> GetAll();
       public Task<int> CreateDepartment(DepartmentModel model);
    }
}
