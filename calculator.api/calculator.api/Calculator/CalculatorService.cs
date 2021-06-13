using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calculator.api.Calculator
{
    public class CalculatorService : ICalculate
    {
        //const string precedence = '{ "*":2, "/":2, "+":1, "-":1 }';
        public string Calculate(Expression expression)
        {            
             return Calculator.Calculate(expression);
        }
    }

   
}
