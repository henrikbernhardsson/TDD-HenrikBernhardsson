using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistry
{
    public class Employee
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Ssn { get; private set; }

        public Employee(string firstName, string lastName, string ssn)
        {
            FirstName = firstName;
            LastName = lastName;
            Ssn = ssn;
        }
    }
}
