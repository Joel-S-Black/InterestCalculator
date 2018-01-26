using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCalculator.Tests
{
    [TestFixture]
    public class InterestTests
    {
        const decimal visaInterest = 10;
        const decimal mcInterest = 5;
        const decimal discoverInterest = 1;

        [Test]
        public void OnePerson_OneWallet_ThreeCards()
        {
            //Arrange
            var person = new Person();
            var wallet = new Wallet(1,new List<CreditCard> { new Visa(100), new MC(100), new Discover(100) });
            person.Wallets.Add(wallet);

            //Act: Visa 10% interest of 100 = 10, MC 5% interest of 100 = 5, Discover 1% interest of 100 = 1, sum = 16
            var totalExpected = visaInterest + mcInterest + discoverInterest;
            var actual = person.GetMonthlyInterest();

            //Assert
            Assert.AreEqual(totalExpected, actual);
            Assert.AreEqual(visaInterest, person.GetInterestByCard(typeof(Visa)));
            Assert.AreEqual(mcInterest, person.GetInterestByCard(typeof(MC)));
            Assert.AreEqual(discoverInterest, person.GetInterestByCard(typeof(Discover)));
        }

        [Test]
        public void OnePerson_TwoWallets_ThreeCards()
        {
            //Arrange
            var person = new Person();
            var wallet1 = new Wallet(1, new List<CreditCard> { new Visa(100), new Discover(100) });
            var wallet2 = new Wallet(2, new List<CreditCard> { new MC(100) });
            person.Wallets.Add(wallet1);
            person.Wallets.Add(wallet2);
        
            //Act: Visa 10% interest of 100 = 10, MC 5% interest of 100 = 5, Discover 1% interest of 100 = 1, sum = 16
            var totalExpected = visaInterest + mcInterest + discoverInterest;
            var actual = person.GetMonthlyInterest();

            //Assert
            Assert.AreEqual(totalExpected, actual);
            Assert.AreEqual(visaInterest + discoverInterest, person.GetInterestByWallet(1));
            Assert.AreEqual(mcInterest, person.GetInterestByWallet(2));
        }

        [Test]
        public void TwoPerson_TwoWallets_FourCards()
        {
            //Arrange
            var person1 = new Person();
            var wallet1 = new Wallet(1,new List<CreditCard> { new MC(100), new Visa(100) });
            person1.Wallets.Add(wallet1);

            var person2 = new Person();
            var wallet2 = new Wallet(1, new List<CreditCard> { new Visa(100), new MC(100) });
            person2.Wallets.Add(wallet2);

            //Act: Visa 10% interest of 100 = 10, MC 5% interest of 100 = 5
            var totalExpected = visaInterest + mcInterest;

            Assert.AreEqual(totalExpected, person1.GetMonthlyInterest());
            Assert.AreEqual(totalExpected, person2.GetMonthlyInterest());
            Assert.AreEqual(mcInterest + visaInterest, person1.GetInterestByWallet(1));
            Assert.AreEqual(visaInterest + mcInterest, person2.GetInterestByWallet(1));
        }
    }
}
