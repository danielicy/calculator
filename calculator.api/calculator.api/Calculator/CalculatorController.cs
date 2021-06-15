using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace calculator.api
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    { 

        private readonly ILogger<CalculatorController> _logger;
        private readonly ICalculate _calculator;

        public CalculatorController(ILogger<CalculatorController> logger, ICalculate calculator)
        {
            _logger = logger;
            _calculator = calculator;
        }

        [HttpGet]        
        public IActionResult Calculate(string expression)
        {
            try
            {
                if (string.IsNullOrEmpty(expression))
                    throw new NullReferenceException("expression is empty");

                string result = _calculator.Calculate(expression);
                     
                 return Ok(result);

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
            
          
        }

    }
}
