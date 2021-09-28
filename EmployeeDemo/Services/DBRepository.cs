using EmployeeDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDemo.Services
{
    public class DBRepository : IEmployeeRepository
    {
        private EmployeeContext _employeeContext;

        public DBRepository(EmployeeContext context)
        {
            _employeeContext = context;
        }

        public Employee AddEmployee(Employee emp)
        {

            var dataBaseCheck = _employeeContext.Employees.ToList();

            if (dataBaseCheck.Count == 0)
            {
                emp.Eid = 101;
                
            }
            if (dataBaseCheck.Count != 0)
            {
                emp.Eid = _employeeContext.Employees.Max(emp => emp.Eid) + 1;

            }
            if (emp.Department.ToString() == "HR")
            {
                emp.DeptId = 1;
            }
            if (emp.Department.ToString() == "Finance")
            {
                emp.DeptId = 2;
            }
            if (emp.Department.ToString() == "IT")
            {
                emp.DeptId = 3;
            }
            if (emp.Department.ToString() == "QA")
            {
                emp.DeptId = 4;
            }
            _employeeContext.Employees.Add(emp);
            _employeeContext.SaveChanges();
            return emp;
        }

        public Employee DeleteEmployee(int id)
        {
            Employee emp = _employeeContext.Employees.FirstOrDefault(emp => emp.Eid == id);
            if (emp != null)
            {
                _employeeContext.Employees.Remove(emp);
            }
            _employeeContext.SaveChanges();
            return emp;
        }

        public Employee GetEmployee(int id)
        {
            Employee emp = _employeeContext.Employees.FirstOrDefault(emp => emp.Eid == id);
            return emp;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeContext.Employees.ToList();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            Employee emp = _employeeContext.Employees.FirstOrDefault(emp => emp.Eid == employee.Eid);
            if (emp != null)
            {
                emp.Ename = employee.Ename;
                emp.Email = employee.Email;
                emp.Department = employee.Department;
                if (employee.Department.ToString() == "HR")
                {
                    emp.DeptId = 1;
                }
                if (employee.Department.ToString() == "Finance")
                {
                    emp.DeptId = 2;
                }
                if (employee.Department.ToString() == "IT")
                {
                    emp.DeptId = 3;
                }
                if (employee.Department.ToString() == "QA")
                {
                    emp.DeptId = 4;
                }
            }
            
            _employeeContext.SaveChanges();
            return emp;
        }
    }
}
