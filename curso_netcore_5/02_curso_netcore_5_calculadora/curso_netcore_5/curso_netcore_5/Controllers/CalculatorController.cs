using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso_netcore_5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{seconfNumber}") ]
        public IActionResult Get(string firstNumber, string seconfNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(seconfNumber))
            {

                var sum = ConverttoDecimal(firstNumber) + ConverttoDecimal(seconfNumber);
                return Ok(sum.ToString());

            }


            return BadRequest("inalid input");

        }

        private bool IsNumeric(string strfNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strfNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }
        private decimal ConverttoDecimal(string strfNumber)
        {
            decimal decimalvalue;
            if (decimal.TryParse(strfNumber, out decimalvalue))
            {
                return decimalvalue;
            }
            return 0;
        }

    }
}
