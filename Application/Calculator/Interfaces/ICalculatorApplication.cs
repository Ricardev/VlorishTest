namespace Calculator.Interfaces
{
    public interface ICalculatorApplication
    {

        int SumUpTo(int number, int? previousNumber = null, int sum = 0);
    }
}