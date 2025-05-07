using BaseUtils.FlowControl.ResultType;
using MathSolver.Operations.Arithmetic;

namespace MathSolver.NumericTypes;
public readonly record struct ImaginaryNumber(decimal RealPart, decimal ImaginaryPart) : INumericType
{
    public Result<INumericType> Add(INumericType numberToAdd) 
    => numberToAdd.AddToImaginaryNumber(this);

    public Result<INumericType> AddToDecimalNumber(DecimalNumber number)
    {
        var result = ArithmeticNumericExtensions.Add(number, this);

        return result.IsSuccess ? result.GetValue() : result.Errors;
    }

    public Result<INumericType> AddToImaginaryNumber(ImaginaryNumber number)
    {
        var result = ArithmeticNumericExtensions.Add(this, number);

        return result.IsSuccess ? result.GetValue() : result.Errors;
    }
}
