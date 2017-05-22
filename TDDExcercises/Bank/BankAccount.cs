using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankAccount
    {
        public decimal Balance { get; set; }


        public void Deposit(int v)
        {
            Balance += v;
        }
        public void Withdraw(int v)
        {
            Balance -= v;
        }
    }
}
