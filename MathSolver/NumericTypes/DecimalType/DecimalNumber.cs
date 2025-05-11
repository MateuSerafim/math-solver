using BaseUtils.FlowControl.ResultType;

namespace MathSolver.NumericTypes;
public readonly record struct DecimalNumber(decimal Value) : INumericType
{
    public Result<INumericType> Add(INumericType numberToAdd) 
    => numberToAdd.AddToDecimalNumber(this);

    public Result<INumericType> AddToDecimalNumber(DecimalNumber number)
    {
       return new DecimalNumber(number.Value + Value);
    }

    public Result<INumericType> AddToImaginaryNumber(ImaginaryNumber number)
    {
        return new ImaginaryNumber(number.RealPart + Value, number.ImaginaryPart);
    }

    public Result<INumericType> Subtract(INumericType numberToSubstract) 
    => numberToSubstract.SubtractToDecimalNumber(this);

    public Result<INumericType> SubtractToDecimalNumber(DecimalNumber number)
    {
        return new DecimalNumber(number.Value - Value);
    }

    public Result<INumericType> SubtractToImaginaryNumber(ImaginaryNumber number)
    {
        return new ImaginaryNumber(number.RealPart - Value, number.ImaginaryPart);
    }
}
