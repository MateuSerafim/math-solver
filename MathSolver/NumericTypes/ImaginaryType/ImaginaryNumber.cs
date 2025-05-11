using BaseUtils.FlowControl.ResultType;

namespace MathSolver.NumericTypes;
public readonly record struct ImaginaryNumber(decimal RealPart, decimal ImaginaryPart) : INumericType
{
    public Result<INumericType> Add(INumericType numberToAdd) 
    => numberToAdd.AddToImaginaryNumber(this);

    public Result<INumericType> AddToDecimalNumber(DecimalNumber number)
    {
        return number.AddToImaginaryNumber(this);
    }

    public Result<INumericType> AddToImaginaryNumber(ImaginaryNumber number)
    {
        return new ImaginaryNumber(number.RealPart + RealPart, 
                                   number.ImaginaryPart + ImaginaryPart);
    }

    public Result<INumericType> Subtract(INumericType numberToSubstract) 
    => numberToSubstract.SubtractToImaginaryNumber(this);

    public Result<INumericType> SubtractToDecimalNumber(DecimalNumber number)
    {
       return new ImaginaryNumber(number.Value - RealPart, 0 - ImaginaryPart);
    }

    public Result<INumericType> SubtractToImaginaryNumber(ImaginaryNumber number)
    {
        return new ImaginaryNumber(number.RealPart - RealPart, 
                                   number.ImaginaryPart - ImaginaryPart);
    }
}
