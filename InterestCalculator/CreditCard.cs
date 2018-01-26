using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCalculator
{
    public abstract class CreditCard
    {
        public CreditCard(decimal startingBalance)
        {
            Balance = startingBalance;
        }
        protected decimal _interestRate;
        public decimal Balance { get; set;}
        public decimal GetMonthlyInterest()
        {
            return _interestRate * Balance;
        }
    }
}
