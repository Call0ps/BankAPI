using System;
using System.Collections.Generic;

namespace BankAPI.Models
{
#pragma warning disable
    public class Account
    {
        public Guid AccountId { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public double Balance { get; private set; }
        public double Interest { get; private set; }
        private List<double> _historicBalance = new List<double>();

        public Account(double balance, double interest)
        {
            Balance = balance;
            Interest = interest;
        }

        public double AccruedInterest
        {
            get
            {
                double accruedInterest = 0;

                foreach (var balance in _historicBalance)
                {
                    accruedInterest += balance * Interest;
                }

                return accruedInterest;
            }
        }

        public void Withdraw(double amount)
        {
            Balance -= amount;
            _historicBalance.Add(Balance);
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            _historicBalance.Add(Balance);
        }

        public void UpdateInterest(double percentage)
        {
            Interest = percentage;
        }
    }
}