using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDemo.Models;

namespace EmployeeDemo.Services
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetEmployees();
        Employee AddEmployee(Employee emp);
        Employee UpdateEmployee(Employee emp);
        Employee DeleteEmployee(int id);
    }
}
