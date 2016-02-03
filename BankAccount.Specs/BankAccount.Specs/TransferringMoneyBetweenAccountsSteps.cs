using System;
using TechTalk.SpecFlow;

namespace BankAccount.Specs
{
    using BankAccount.Specs.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [Binding]
    public class TransferringMoneyBetweenAccountsSteps
    {
        Account _currentAccount = null;
        Account _savingsAccount = null;
        Account _supersaverAccount = null;

        [Given(@"my Current account has a balance of (.*)")]
        public void GivenMyCurrentAccountHasABalanceOf(Decimal p0)
        {
            _currentAccount = new Account("current");
            _currentAccount.Book(p0, "Current Balance");
        }
        
        [Given(@"my Savings account has a balance of (.*)")]
        public void GivenMySavingsAccountHasABalanceOf(Decimal p0)
        {
            _savingsAccount = new Account("savings");
            _savingsAccount.Book(p0, "Savings Balance");
        }
        
        [Given(@"I have an account of current with a balance of (.*)")]
        public void GivenIHaveAnAccountOfCurrentWithABalanceOf(Decimal p0)
        {
            _currentAccount = new Account("current");
            _currentAccount.Book(p0, "Current Balance");
        }

        [Given(@"I have an account of savings with a balance of (.*)")]
        public void GivenIHaveAnAccountOfSavingsWithABalanceOf(Decimal p0)
        {
            _savingsAccount = new Account("savings");
            _savingsAccount.Book(p0, "Savings Balance");
        }

        [Given(@"I have an account of supersaver with a balance of (.*)")]
        public void GivenIHaveAnAccountOfSupersaverWithABalanceOf(Decimal p0)
        {
            _supersaverAccount = new Account("supersaver");
            _supersaverAccount.Book(p0, "Supersaver Balance");
        }

        [Given(@"I have earned at an annual interest rate of (.*)")]
        public void GivenIHaveEarnedAtAnAnnualInterestRateOf(int p0)
        {
            if (_currentAccount != null)
            {
                _currentAccount.InterestRate = p0;
            }
            if (_savingsAccount != null)
            {
                _savingsAccount.InterestRate = p0;
            }
            if (_supersaverAccount != null)
            {
                _supersaverAccount.InterestRate = p0;
            }
        }

        [When(@"I transfer (.*) from my Current account to my Savings account")]
        public void WhenITransferFromMyCurrentAccountToMySavingsAccount(Decimal p0)
        {
            _currentAccount.Transfer(p0, _savingsAccount);
        }
        
        [When(@"the monthly interest is calculated")]
        public void WhenTheMonthlyInterestIsCalculated()
        {
            if (_currentAccount != null)
            {
                _currentAccount.MonthlyInterestCalculate();
            }
            if (_savingsAccount != null)
            {
                _savingsAccount.MonthlyInterestCalculate();
            }
            if (_supersaverAccount != null)
            {
                _supersaverAccount.MonthlyInterestCalculate();
            }
        }

        [When(@"I should have a new balance of (.*)")]
        public void WhenIShouldHaveANewBalanceOf(Decimal p0)
        {
            if (_currentAccount != null)
            {
                Assert.AreEqual(p0, Math.Round(_currentAccount.Balance, 2));
            }
            if (_savingsAccount != null)
            {
                Assert.AreEqual(p0, Math.Round(_savingsAccount.Balance, 2));
            }
            if (_supersaverAccount != null)
            {
                Assert.AreEqual(p0, Math.Round(_supersaverAccount.Balance, 2));
            }
        }

        [Then(@"I should have (.*) in my Current account")]
        public void ThenIShouldHaveInMyCurrentAccount(Decimal p0)
        {
            Assert.AreEqual(p0, _currentAccount.Balance);
        }
        
        [Then(@"I should have (.*) in my Savings account")]
        public void ThenIShouldHaveInMySavingsAccount(Decimal p0)
        {
            Assert.AreEqual(p0, _savingsAccount.Balance);
        }
        
        [Then(@"I should receive an '(.*)' error")]
        public void ThenIShouldReceiveAnError(string p0)
        {
            Assert.AreEqual("insufficient funds", _currentAccount.Error);
        }

    }
}
