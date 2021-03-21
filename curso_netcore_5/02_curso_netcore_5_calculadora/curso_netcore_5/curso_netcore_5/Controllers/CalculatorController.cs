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
        public IActionResult Sum(string firstNumber, string seconfNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(seconfNumber))
            {

                var sum = ConverttoDecimal(firstNumber) + ConverttoDecimal(seconfNumber);
                return Ok(sum.ToString());

            }

            return BadRequest("inalid input");

        }

        [HttpGet("subtraction/{firstNumber}/{seconfNumber}")]
        public IActionResult Subtraction(string firstNumber, string seconfNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(seconfNumber))
            {

                var sum = ConverttoDecimal(firstNumber) - ConverttoDecimal(seconfNumber);
                return Ok(sum.ToString());

            }

            return BadRequest("inalid input");

        }

        [HttpGet("multiplication/{firstNumber}/{seconfNumber}")]
        public IActionResult Multiplication(string firstNumber, string seconfNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(seconfNumber))
            {

                var sum = ConverttoDecimal(firstNumber) * ConverttoDecimal(seconfNumber);
                return Ok(sum.ToString());

            }

            return BadRequest("inalid input");

        }

        [HttpGet("division/{firstNumber}/{seconfNumber}")]
        public IActionResult Division(string firstNumber, string seconfNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(seconfNumber))
            {

                var sum = ConverttoDecimal(firstNumber) / ConverttoDecimal(seconfNumber);
                return Ok(sum.ToString());

            }

            return BadRequest("inalid input");

        }

        [HttpGet("mean/{firstNumber}/{seconfNumber}")]
        public IActionResult Mean(string firstNumber, string seconfNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(seconfNumber))
            {

                var sum = (ConverttoDecimal(firstNumber) + ConverttoDecimal(seconfNumber)) /2;
                return Ok(sum.ToString());

            }

            return BadRequest("inalid input");

        }

        [HttpGet("square-root/{firstNumber}")]
        public IActionResult Squareroot(string firstNumber)
        {

            if (IsNumeric(firstNumber))
            {

                var squareroot = Math.Sqrt((double)ConverttoDecimal(firstNumber));
                return Ok(squareroot.ToString());

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
