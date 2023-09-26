using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Event_Linq.Ex2
{
    public delegate void BalanceChangesNotify(int num);
    public class Account
    {
        event BalanceChangesNotify BalanceChanges;
        private int balance;
        public int Balance
        {
            get { return balance; }
            set 
            {
                balance = value;      
                BalanceChanges(balance); 
            }
        }
        private void Notify(int balance) => Console.WriteLine("New account balance: {0}", balance);

        public Account()
        {
            balance = 0;
            BalanceChanges += new BalanceChangesNotify(Notify);
        }
    }
    internal class BankingApplication
    {
        static void Main(string[] args)
        {
            Account account = new Account();
            account.Balance = 200000;
            account.Balance = 150000;
            Console.ReadLine();
        }
    }
}
