using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IEmployeeService
    {
         Task<IEnumerable<EmployeeModel>> GetAll();
        Task<EmployeeModel> GetEmployee(int id);
        void DeleteEmployee(int id);
        Task<int> UpdateEmployee(EmployeeModel model);
        Task<int> CreateEmployee(EmployeeModel model);
    }
}
