using NUnit.Framework;
using calculator.api.Calculator;

namespace calculator.test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculationOrder()
        {
            Expression expression = new Expression()
            {
                                         //1+8+7*4/2-5*2.5 = 9 + 14 + 12.5
                Operations = new string[] { "+", "+", "*", "/", "+", "*" },
                Operators = new string[] { "1", "8", "7", "4", "2", "5", "2.5" }
            };

             
            Assert.AreEqual("35.5", Calculator.Calculate(expression));
        }
        [Test]
        public void Test2()
        {
            Assert.Pass();
        }
        [Test]
        public void Test3()
        {
            Assert.Pass();
        }
    }
}