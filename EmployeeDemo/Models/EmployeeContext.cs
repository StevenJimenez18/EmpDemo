using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Step1
using Microsoft.EntityFrameworkCore;

namespace EmployeeDemo.Models
{
    //Step2
    public class EmployeeContext : DbContext
    {
        //Constructor
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        //Tables in DB
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        //Data seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                
                new Department()
                {
                    DepartId = 1,
                    DepartmentName = "HR",
                    
                },

                new Department()
                {
                    DepartId = 2,
                    DepartmentName = "Fiance",

                },

                new Department()
                {
                    DepartId = 3,
                    DepartmentName = "IT",

                },

                new Department()
                {
                    DepartId = 4,
                    DepartmentName = "QA",

                }
                

                );

            modelBuilder.Entity<Employee>().HasData(

                new Employee()
                {
                    Eid = 101,
                    Ename = "Sarah",
                    Email = "s@gmail.com",
                    Department = Dept.IT,
                    DeptId = 3
                },

                new Employee()
                {
                    Eid = 102,
                    Ename = "Michael",
                    Email = "m@gmail.com",
                    Department = Dept.HR,
                    DeptId = 1
                }

                ); 
        }
    }
}
