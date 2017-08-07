using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex7_Polymorphism_BankExample
{
    public class BankAccount
    {
        protected decimal _balance;

        public BankAccount(decimal initialBalance)
        {
            _balance = initialBalance;
        }

        public decimal Balance
        {
            get { return _balance; }
        }

        public virtual decimal Withdraw(decimal amount)
        {
            Console.WriteLine("In BankAccount.Withdraw() for £{0} ... ", amount);
            decimal amountToWithdraw = amount;
            if (amountToWithdraw > Balance)
            {
                amountToWithdraw = Balance;
            }
            _balance -= amountToWithdraw;
            return amountToWithdraw;
        }


    }
    public class SavingsAccount : BankAccount
    {
        public decimal _interestRate;

        public SavingsAccount(decimal initialBalance, decimal interestRate) : base(initialBalance)
        {
            _interestRate = interestRate / 100;
        }

        public void AccumulateInterest()
        {
            _balance = Balance + (Balance * _interestRate);
        }

        public override decimal Withdraw(decimal withdrawal)
        {
            Console.WriteLine("In SavingsAccount.Withdrawal() ...");
            //take off £1.50 fee
            base.Withdraw(1.5M);
            return base.Withdraw(withdrawal);
        }
    }
    class Program
    {
        public static void MakeAWithdrawal(BankAccount ba, decimal amount)
        {
            ba.Withdraw(amount);
        }

        static void Main(string[] args)
        {
            BankAccount ba;
            SavingsAccount sa;

            Console.WriteLine("Withdrawal: MakeAWithdrawal(ba, ...)");
            ba = new BankAccount(200M);
            MakeAWithdrawal(ba, 100M);
            Console.WriteLine("Bank account balance is £{0:F2}", ba.Balance);
            Console.WriteLine();
            Console.WriteLine("Withdrawal: MakeAWithdrawal(sa, ...)");
            sa = new SavingsAccount(200M, 12);
            MakeAWithdrawal(sa, 100M);
            Console.WriteLine("Savings account balance is £{0:F2}", sa.Balance);
        }
    }
}
