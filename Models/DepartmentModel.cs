using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class DepartmentModel
    {
        [Key]
        public int departmentId { get; set; }
        public string departmentName { get; set; }
        public ICollection<EmployeeModel> employees { get; set; }

    }
}
