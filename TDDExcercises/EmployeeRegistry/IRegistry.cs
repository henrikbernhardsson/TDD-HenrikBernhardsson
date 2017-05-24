using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistry
{
    interface IRegistry
    {
        List<Employee> AllEmployees();
        void Fire(string ssn);
        void Hire(Employee employee);
    }
}
