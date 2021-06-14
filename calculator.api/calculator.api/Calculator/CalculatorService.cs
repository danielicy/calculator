using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calculator.api
{
    public class CalculatorService : ICalculate
    {
        
        public string Calculate(string expression)
        {
            Calculator calculator = new Calculator();

            return calculator.Calculate(expression).ToString();            
            
        }


    }

   
}
