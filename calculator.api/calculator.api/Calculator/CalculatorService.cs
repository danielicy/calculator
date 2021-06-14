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

            return ParseResult(result);
            
        }

        private string ParseResult(string result)
        {
            if (result.Contains("."))
            {
                var splitted = result.Split('.');
                var dec= int.Parse(splitted[1]);
                if (dec == 0)
                    return splitted[0];

                return result;
            }               
            else
                return result;
        }
    }

   
}
