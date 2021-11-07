using System;
using System.Collections.Generic;

namespace BankAPI.Models
{
    public class Account
    {
        public Guid Guid { get; set; }
        public double Balance {get; private set; }
        public double Interest { get; private set; }
        private List<double> _historicBalance = new List<double>();

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

