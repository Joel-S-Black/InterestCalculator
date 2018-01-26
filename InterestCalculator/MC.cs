namespace InterestCalculator
{
    public class MC : CreditCard
    {
        public MC(decimal startingBalance):base(startingBalance)
        {
            _interestRate = .05m;
        }
    }
}