using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCalculator
{
    public class Wallet
    {
        public Wallet(int id)
        {
            WalletId = id;
            CreditCards = new List<CreditCard>();
        }

        public Wallet(int id, List<CreditCard> creditCards)
        {
            WalletId = id;
            CreditCards = creditCards;
        }
        public int WalletId { get; set; }
        public List<CreditCard> CreditCards { get; set; }

        public decimal GetMonthlyInterest()
        {
            decimal sum = 0;
            foreach(var card in CreditCards)
            {
                sum += card.GetMonthlyInterest();
            }

            return sum;
        }

        public decimal? GetInterestByCard(Type card)
        {
            foreach(var item in CreditCards)
            {
                if(item.GetType() == card)
                {
                    return item.GetMonthlyInterest();
                }
            }

            return null;
        }
    }
}
