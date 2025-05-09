using BaseUtils.FlowControl.ResultType;
using MathSolver.Operations.Arithmetic;

namespace MathSolver.NumericTypes;
public readonly record struct ImaginaryNumber(decimal RealPart, decimal ImaginaryPart) : INumericType
{
    public Result<INumericType> Add(INumericType numberToAdd) 
    => numberToAdd.AddToImaginaryNumber(this);

    public Result<INumericType> AddToDecimalNumber(DecimalNumber number)
    {
        return ArithmeticNumericExtensions.Add(number, this).GetValue();
    }

    public Result<INumericType> AddToImaginaryNumber(ImaginaryNumber number)
    {
        return ArithmeticNumericExtensions.Add(this, number).GetValue();
    }
}
