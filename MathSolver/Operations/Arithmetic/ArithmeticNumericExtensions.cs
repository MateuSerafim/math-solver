using BaseUtils.FlowControl.ResultType;
using MathSolver.NumericTypes;

namespace MathSolver.Operations.Arithmetic;
public static class ArithmeticNumericExtensions
{
    public const string OperationCannotBeNull = "An Expression cannot be a null object.";
    public static Result<DecimalNumber> Add(DecimalNumber leftNumber, DecimalNumber rightNumber)
    {
        return new DecimalNumber(leftNumber.Value + rightNumber.Value);
    }

    public static Result<ImaginaryNumber> Add(DecimalNumber leftNumber, ImaginaryNumber rightNumber)
    {
        return new ImaginaryNumber(leftNumber.Value + rightNumber.RealPart, rightNumber.ImaginaryPart);
    }

    public static Result<ImaginaryNumber> Add(ImaginaryNumber leftNumber, ImaginaryNumber rightNumber)
    {
        return new ImaginaryNumber(leftNumber.RealPart + rightNumber.RealPart, 
                                   leftNumber.ImaginaryPart + rightNumber.ImaginaryPart);
    }
}
