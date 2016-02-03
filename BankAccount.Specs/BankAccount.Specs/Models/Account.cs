using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Specs.Models
{
    public class Account
    {
        public string Name { get; private set; }
        public string Error { get; private set; }
        public int InterestRate { get; set; }
        public decimal Balance
        {
            get
            {
                return AccountEntries.Sum(x => x.Amount);
            }
        }
        public List<AccountEntry> AccountEntries { get; private set; }

        public Account(string name)
        {
            this.Name = name;
            this.AccountEntries = new List<AccountEntry>();
        }

        public void Book(decimal amount, string description)
        {
            this.AccountEntries.Add(new AccountEntry
             {
                BookedDate = DateTime.Now,
                Description = description,
                Amount = amount
            });
        }

        public void Transfer(decimal amount, Account toAccount)
        {
            if (this.Balance <= amount)
            {
                this.Error = "insufficient funds";
                return;
            }

            this.Book(-amount, "Transfer to " + toAccount.Name);
            toAccount.Book(amount, "Transfer from " + this.Name);
        }

        // http://www.thecalculatorsite.com/articles/finance/compound-interest-formula.php
        public void MonthlyInterestCalculate()
        {
            decimal principalAmount = this.Balance;
            decimal annualRate = 0.01m * InterestRate;
            decimal compoundsPerYear = 12;
            decimal years = 1m / 12m;

            var earnedAmount = principalAmount * (annualRate / compoundsPerYear) * compoundsPerYear * years;

            this.Book(earnedAmount, "Monthly Interest");
        }
    }
}
