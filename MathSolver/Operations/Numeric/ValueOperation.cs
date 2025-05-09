using BaseUtils.FlowControl.ErrorType;
using BaseUtils.FlowControl.ResultType;
using MathSolver.NumericTypes;

namespace MathSolver.Operations.NumericOperations;
public sealed record ValueOperation(Result<INumericType> ResultValue) : IOperation
{
    public const string NumericValueCannotBeNull = "A numeric value cannot be null.";

    public Result<INumericType> Evaluate() 
    {
        if (ResultValue is null)
            return ErrorResponse.NotFoundError(NumericValueCannotBeNull); 

        return ResultValue;  
    }
    
    public IOperation Compile() => this;
}
