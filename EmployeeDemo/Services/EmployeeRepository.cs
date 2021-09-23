using EmployeeDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDemo.Services
{
    

    public class EmployeeRepository : IEmployeeRepository
    {

        private List<Employee> _emplist;

        public EmployeeRepository()
        {
            _emplist = new List<Employee>()
            {
                new Employee(){ Eid=101, Ename="Michael", Email="M@gmail.com", Department=Dept.IT},
                new Employee(){ Eid=102, Ename="Elena", Email="E@gmail.com", Department=Dept.Finance},
                new Employee(){ Eid=103, Ename="Logan", Email="L@gmail.com", Department=Dept.Finance},
                new Employee(){ Eid=104, Ename="Nathan", Email="N@gmail.com", Department=Dept.HR},
                new Employee(){ Eid=105, Ename="Sarah", Email="s@gmail.com", Department=Dept.QA}
            };
        }

        public Employee AddEmployee(Employee emp)
        {
            emp.Eid = _emplist.Max(emp => emp.Eid) + 1;
            _emplist.Add(emp);
            return emp;
        }

        public Employee DeleteEmployee(int id)
        {
            Employee emp = _emplist.FirstOrDefault(emp => emp.Eid == id);
            if(emp != null)
            {
                _emplist.Remove(emp);
            }
            return emp;
        }

        public Employee GetEmployee(int id)
        {
            Employee emp = _emplist.FirstOrDefault(emp => emp.Eid == id);
            return emp;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _emplist;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            Employee emp = _emplist.FirstOrDefault(emp => emp.Eid == employee.Eid);
            if(emp != null)
            {
                emp.Ename = employee.Ename;
                emp.Email = employee.Email;
                emp.Department = employee.Department;
            }
            return emp;
        }

      
    }
}
