using Calculator.Models;

namespace Calculator.Interfaces
{
    public interface IEventError
    {
        ValidationError? GetValidationError();
        void RaiseValidationError(string message, int statusCode);
    }
}