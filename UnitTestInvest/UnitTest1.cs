using Microsoft.VisualStudio.TestTools.UnitTesting;
using SInvestLibrary;

namespace UnitTestInvest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCalculateMethod()
        {
            // Act
            Trade t = new Trade();

            //Arrange
            t.TradeType = "Sell";
            t.SharePrice = 300;
            t.NumberOfShares = 200;

            //double  ActualPrice = t.CalculatePrice();

            // Assert

            Assert.AreEqual(59700,t.Price );

        }
    }
}
