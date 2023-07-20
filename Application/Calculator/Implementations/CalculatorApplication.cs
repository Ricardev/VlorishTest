using Calculator.Interfaces;

namespace Application.Calculator.Implementations
{
    public class CalculatorApplication : ICalculatorApplication
    {
        private readonly IEventError _eventError;

        public CalculatorApplication(IEventError eventError)
        {
            _eventError = eventError;
        }
        
        public int SumUpTo(int number, int? previousNumber = null, int sum = 0)
        {
            if (number == 0)
            {
                _eventError.RaiseValidationError("0 is not an valid number, please input a number bigger than 1 to be fun.", 400);
                return 0;
            }

            if (number < 0)
            {
                _eventError.RaiseValidationError("Negatives numbers are not valid, please input a number bigger than 1, like your credit card number and the password.", 
                    statusCode: 400);
                return 0;
            }
                
            previousNumber ??= 1;

            if (number == previousNumber)
                return sum + previousNumber.Value;

            sum += previousNumber.Value;
            
            return SumUpTo(number, previousNumber + 1, sum);
        }
    }
}