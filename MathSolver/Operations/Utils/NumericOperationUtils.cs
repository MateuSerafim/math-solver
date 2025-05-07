using BaseUtils.FlowControl.ErrorType;
using BaseUtils.FlowControl.ResultType;

namespace MathSolver.Operations.Utils;
public static class NumericOperationUtils
{
    public const string InvalidMDCForZero = "Cannot get MDC of only 0 numbers.";
    public static Result<int> GetMaxCommonDivisor(int number1, int number2)
    {
        if (number1 == 0 && number2 == 0)
            return ErrorResponse.InvalidOperationError(InvalidMDCForZero);
        
        if (number1 == 0)
            return number2;
        if (number2 == 0)
            return number1;

        if (number1 == number2)
            return number1;

        if (number1 > number2)
            return GetMaxCommonDivisor(number1%number2, number2);

        return GetMaxCommonDivisor(number1, number2%number1);
    }
}
