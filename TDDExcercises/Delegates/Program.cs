using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        public delegate double CalcDelegate(double a, double b);

        public class Calculator
        {
            public CalcDelegate CalcLogic { get; set; }

            public void PrintCalculation(double a, double b)
            {
                Console.WriteLine(a + b);
            }
        }
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            calculator.PrintCalculation(1, 2);
            Console.ReadLine();
        }
    }
}
