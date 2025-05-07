using BaseUtils.FlowControl.ResultType;

namespace MathSolver.NumericTypes;
public interface INumericType
{
    public Result<INumericType> Add(INumericType numberToAdd);
    public Result<INumericType> AddToDecimalNumber(DecimalNumber number);
    public Result<INumericType> AddToImaginaryNumber(ImaginaryNumber number);
}
