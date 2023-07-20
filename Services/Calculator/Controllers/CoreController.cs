using Calculator.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    public class CoreController : ControllerBase
    {

        private IEventError _eventError;

        public CoreController(IEventError messageBus)
        {
            _eventError = messageBus;
        }

        protected new IActionResult Response<T>(T? data, int successStatusCode = StatusCodes.Status200OK)
        {
            var validationError = _eventError.GetValidationError();
            
            var successModel = new ResponseModelSuccess<T?>(data);
            
            if (!string.IsNullOrEmpty(validationError?.Mensagem))
            {
                successModel.Error = validationError.Mensagem;
                successModel.Success = false;
            }
            
            return new ObjectResult(successModel)
            {
                StatusCode = successStatusCode,
            };
        }
    }
}