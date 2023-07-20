using System;
using Calculator.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Calculator.Controllers
{
    [ApiController]
    [Route("sum")]
    public class CalculatorController : CoreController
    {

        private readonly ICalculatorApplication _calculatorApplication;
        private readonly IEventError _eventError;

        public CalculatorController(ICalculatorApplication calculatorApplication, IEventError eventError) : base(eventError)
        {
            _calculatorApplication = calculatorApplication;
            _eventError = eventError;
        }
        
        [HttpGet]
        public IActionResult Get([FromQuery] int upto)
        {
            try
            {
                var sum = _calculatorApplication.SumUpTo(upto);
                return Response(sum);
            }
            catch (Exception e)
            {
                _eventError.RaiseValidationError("An error has ocurred, please check if the param is an valid integer.", StatusCodes.Status400BadRequest);
                return Response(0);
            }
        }
        
    }
}
