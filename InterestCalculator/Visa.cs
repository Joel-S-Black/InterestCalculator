namespace InterestCalculator
{
    public class Visa : CreditCard
    {
        public Visa(decimal startingBalance):base(startingBalance)
        {
            _interestRate = .1m;
        }
    }
}