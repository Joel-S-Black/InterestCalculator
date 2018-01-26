using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCalculator
{
    public class Person
    {
        public Person()
        {
            Wallets = new List<Wallet>();
        }
        public List<Wallet> Wallets { get; set; }

        public object GetMonthlyInterest()
        {
            decimal sum = 0;
            foreach(var wallet in Wallets)
            {
                sum += wallet.GetMonthlyInterest();
            }

            return sum;
        }

        public decimal GetInterestByCard(Type card)
        {
            foreach(var item in Wallets)
            {
                if(item.GetInterestByCard(card) != null)
                {
                    return (decimal)item.GetInterestByCard(card);
                }
            }

            return 0;
        }

        public decimal GetInterestByWallet(int walletId)
        {
            return Wallets.FirstOrDefault(x => x.WalletId == walletId).GetMonthlyInterest();
        }
    }
}
