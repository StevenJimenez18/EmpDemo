using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDemo.Services
{
    public class FormatNumber : IFormatNumber
    {
        public string GetFormattedNumber(int number)
        {
            return string.Format("{0:n0}", number);
        }
    }
}
