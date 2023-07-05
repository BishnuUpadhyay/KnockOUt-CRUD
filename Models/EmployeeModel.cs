using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Employee Name")]
        public string Fullname { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Hired Date")]
        public DateTime Hireddate { get; set; }
        [StringLength(40)]
        public string Address { get; set; }
        public string Branch { get; set; }
        [StringLength(6)]
        [RegularExpression("([1-9][0-9]*)",ErrorMessage ="Please Enter valid amount of Salary")]
        [MinLength(4)]
        public string Salary { get; set; }
    }
}

