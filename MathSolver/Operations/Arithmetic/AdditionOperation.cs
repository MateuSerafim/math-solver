using BaseUtils.FlowControl.ResultType;
using MathSolver.NumericTypes;
using MathSolver.Operations.NumericOperations;

namespace MathSolver.Operations.Arithmetic;
public class AdditionOperation(IOperation LeftOperation, 
                               IOperation RightOperation) : IOperation
{
    public Result<INumericType> Evaluate() => Compile().Evaluate(); 

    public IOperation Compile()
    {
        var leftResult = LeftOperation.Evaluate();
        var rightResult = RightOperation.Evaluate();

        if (leftResult.IsFailure || rightResult.IsFailure)
            return new ValueOperation(Result<INumericType>.Failure([.. leftResult.Errors, 
                                                                    .. rightResult.Errors]));

        Result<INumericType> result = leftResult.GetValue().Add(rightResult.GetValue());
        return new ValueOperation(result);
    }
}
