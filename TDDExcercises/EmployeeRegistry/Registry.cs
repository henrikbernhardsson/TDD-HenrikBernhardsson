using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeRegistry
{
    public class Registry : IRegistry
    {
        private Dictionary<string, Employee> employees;
        private Regex ssnRegex = new Regex(@"^\d{6}-\d{4}$");
        public Registry()
        {
            employees = new Dictionary<string, Employee>();
        }
        public Registry(Dictionary<string, Employee> newEmployees)
        {
            employees = newEmployees;
        }
        public List<Employee> AllEmployees()
        {
            return employees.Values.ToList();
        }

        public void Fire(string ssn)
        {
            
        }

        public void Hire(Employee employee)
        {
            if (!ssnRegex.IsMatch(employee.Ssn))
            {
                throw new InvalidSsnException();
            }
            employees.Add(employee.Ssn, employee);
        }
    }
}
