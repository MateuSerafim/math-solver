using BaseUtils.FlowControl.ResultType;
using MathSolver.NumericTypes;

namespace MathSolver.Operations.NumericOperations;
public class ValueOperation(Result<INumericType> ResultValue) : IOperation
{
    public const string NumericValueCannotBeNull = "A numeric value cannot be null.";


    public Result<INumericType> Evaluate() => ResultValue;
    public IOperation Compile() => this;
}
