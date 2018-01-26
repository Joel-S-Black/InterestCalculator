namespace InterestCalculator
{
    public class Discover : CreditCard
    {
        public Discover(decimal startingBalance):base(startingBalance)
        {
            _interestRate = .01m;
        }
    }
}