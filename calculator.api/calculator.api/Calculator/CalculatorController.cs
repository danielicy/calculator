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
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CalculatorController> _logger;
        private readonly ICalculate _calculator;

        public CalculatorController(ILogger<CalculatorController> logger, ICalculate calculator)
        {
            _logger = logger;
            _calculator = calculator;
        }

        [HttpGet]        
        public IActionResult Calculate(JToken expression)
        {
            try
            {               
                string result = _calculator.Calculate(expression.Value<string>("expression"));
                     
                 return Ok(result);

            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
          
        }

    }
}
