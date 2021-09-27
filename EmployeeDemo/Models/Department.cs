using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDemo.Models
{
    public class Department
    {
        [Key]
        public int DepartId { get; set; }
        public string DepartmentName { get; set; }

        //Employee Relation
        public virtual ICollection<Employee> Employees{ get; set; }
    }
}
