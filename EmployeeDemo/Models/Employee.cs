using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDemo.Models
{
    public enum Dept
    {
        None,
        HR,
        Finance,
        IT,
        QA
    }

    public class Employee
    {
            [Key]
            [Display(Name = "Employee Id")]
            [Required]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int Eid { get; set; }

            [Required]
            [MaxLength(50,ErrorMessage ="Name cannot exceed 50 chars")]
            public string Ename { get; set; }
            
            [Required]
            [Display(Name = "Email")]
            //[RegularExpression(@"^[a - zA - Z0 - 9_.+ -] +@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage= "Invalid Format.")]
            public string Email { get; set; }

            public int Age { get; set; }

            [Display(Name = "Department")]
            public Dept Department { get; set; }

            //Foreign Key
            public int DeptId { get; set; }
            public virtual Department department{ get; set; }

    }
}
