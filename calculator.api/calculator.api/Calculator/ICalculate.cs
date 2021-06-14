using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calculator.api
{
   public interface ICalculate
    {
        public string Calculate(string expression);
    }
}
