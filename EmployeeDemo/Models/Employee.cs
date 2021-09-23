using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
       
            [Display(Name = "Employee Id")]
            [Required]
            public int Eid { get; set; }
            
            [Required]
            [MaxLength(50,ErrorMessage ="Name cannot exceed 50 chars")]
            public string Ename { get; set; }
            
            [Required]
            [Display(Name = "Email")]
            //[RegularExpression(@"^[a - zA - Z0 - 9_.+ -] +@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage= "Invalid Format.")]
            public string Email { get; set; }

            [Display(Name = "Department")]
            public Dept Department { get; set; }

    }
}
