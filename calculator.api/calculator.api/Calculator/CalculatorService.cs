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

            string result = calculator.Calculate(expression).ToString();
            var splitted = result.Split('.');
            if (splitted[1] == "000000")
                return splitted[0];
            else
                return result;

            
        }
    }

   
}
