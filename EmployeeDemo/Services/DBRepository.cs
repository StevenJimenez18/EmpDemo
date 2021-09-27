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
                _employeeContext.Add(emp);
            }
            if (dataBaseCheck.Count != 0)
            {
                emp.Eid = _employeeContext.Employees.Max(emp => emp.Eid) + 1;
                _employeeContext.Employees.Add(emp);
            }

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
            }
            _employeeContext.SaveChanges();
            return emp;
        }
    }
}
