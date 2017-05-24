using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EmployeeRegistry;

namespace EmployeeRegistry.Tests
{
    class RegistryTests
    {
        private Registry sut;
        private Dictionary<string, Employee> employees;
        private Employee employee1;
        private Employee employee2;

        [SetUp]
        public void Setup()
        {
            employees = new Dictionary<string, Employee>();
            employee1 = new Employee("Martin", "Nilsson", "800805-5555");
            employee2 = new Employee("Lars", "Pettersson", "751205-2352");
            sut = new Registry();
        }

        [Test]
        public void StartWithZeroEmployees()
        {
            var result = sut.AllEmployees();
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void CanSeedEmployeesOnConstruct()
        {
            employees.Add(employee1.Ssn, employee1);
            employees.Add(employee2.Ssn, employee2);
            sut = new Registry(employees);

            var result = sut.AllEmployees();

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void CanHireAnEmployee()
        {
            var employee = new Employee("Kalle", "Anka", "200513-1344");
            sut.Hire(employee);
            var result = sut.AllEmployees();
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Kalle", result[0].FirstName);
        }

        [Test]
        public void HireWithInvalidSsn_ThrowsException()
        {
            var employee = new Employee("Kalle", "Anka", "2aa513-1344");
            {
                Assert.Throws<InvalidSsnException>(() =>
                {
                    sut.Hire(employee);
                });
            }
        }
    }
}
