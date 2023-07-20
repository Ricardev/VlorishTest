using Calculator.Interfaces;
using Calculator.Models;

namespace Calculator.Implementations
{
    public class EventError : IEventError
    {
        private ValidationError? ValidationErrors { get; set; }

        public ValidationError? GetValidationError()
        {
            ValidationErrors ??= new ValidationError(string.Empty, 400);
            return ValidationErrors;
        }

        public void RaiseValidationError(string message, int statusCode)
        {
            ValidationErrors ??= new ValidationError(message, statusCode);
        }
    }
}