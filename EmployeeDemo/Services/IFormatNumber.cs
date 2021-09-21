using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDemo.Services
{
    public interface IFormatNumber
    {
        public string GetFormattedNumber(int number);
    }
}
