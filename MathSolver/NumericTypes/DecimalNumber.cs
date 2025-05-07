using BaseUtils.FlowControl.ResultType;
using MathSolver.Operations.Arithmetic;

namespace MathSolver.NumericTypes;
public readonly record struct DecimalNumber(decimal Value) : INumericType
{
    public Result<INumericType> Add(INumericType numberToAdd) 
    => numberToAdd.AddToDecimalNumber(this);

    public Result<INumericType> AddToDecimalNumber(DecimalNumber number)
    {
       return ArithmeticNumericExtensions.Add(this, number).GetValue();
    }

    public Result<INumericType> AddToImaginaryNumber(ImaginaryNumber number)
    {
        return ArithmeticNumericExtensions.Add(this, number).GetValue();
    }
}
