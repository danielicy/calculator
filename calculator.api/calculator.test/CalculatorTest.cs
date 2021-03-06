
using calculator.api;
using NUnit.Framework;
  

namespace calculator.test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SimpleCalculation()
        {
            

            Calculator _calc = new Calculator();
            var result = _calc.Calculate("5+10*3");
            Assert.AreEqual(35, result);
        }

        [Test]
        public void SimpleCalculation2()
        {


            Calculator _calc = new Calculator();
            var result = _calc.Calculate("8*4+2");
            Assert.AreEqual(34, result);
        }

        [Test]
        public void CalculationOrder()
        {
            //1+8+7*4/2+5*2.5 = 9 + 14 + 12.5

            Calculator _calc = new Calculator();
            var result = _calc.Calculate("1+8+7*4/2+5*2.5");
            Assert.AreEqual(35.5, result);
        }
        [Test]
        public void CalculationOrder2()
        {
             
            //1+2+3*2.9/4.6+12+2 = 3 + 1.891 + 14 
            Calculator _calc = new Calculator();
            var result = _calc.Calculate("1+2+3*2.9/4.6+12+2 ");
           var parsedResulr = string.Format("{0:N6}", result);
            Assert.AreEqual("18.891304", parsedResulr);
        }

        [Test]
        public void NegativeResult()
        {
            //5-2*5*7+2+12-2*3.5=5-70+14-7
            Calculator _calc = new Calculator();
            var result = _calc.Calculate("5-2*5*7+2+12-2*3.5");
            Assert.AreEqual(-58, result);
        }

        [Test]
        public void NegativeResult1()
        {
            //5-2*5*7+2+12-2*3.5=5-70+14-7
            Calculator _calc = new Calculator();
            var result = _calc.Calculate("81-20-36-10*8");
            Assert.AreEqual(-55, result);
        }



        [Test]
        public void CalculationOrder4()
        {
            //5*2+5*7+2/3
            Calculator _calc = new Calculator();
            var result = _calc.Calculate("5*2+5*7+2/3");
            var parsedResulr = string.Format("{0:N6}", result);
            Assert.AreEqual("45.666667", parsedResulr);
        }

 
    }
}