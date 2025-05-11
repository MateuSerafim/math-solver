using BaseUtils.FlowControl.ErrorType;
using BaseUtils.FlowControl.ResultType;
using MathSolver.Expressions;
using MathSolver.NumericTypes;
using MathSolver.Operations.NumericOperations;

namespace MathSolver.Operations.Arithmetic;
public class MultiplicationOperation(IExpression LeftExpression, 
                                     IExpression RightExpression) : IOperation
{
    public Result<INumericType> Evaluate() => Compile().Evaluate(); 
    public IOperation Compile()
    {
        if (LeftExpression is null || RightExpression is null)
        {
            return new ValueOperation(
                ErrorResponse.NotFoundError(
                    ArithmeticExtensions.OperationCannotBeNull));
        }

        var leftResult = LeftExpression.Evaluate();
        var rightResult = RightExpression.Evaluate();

        if (leftResult.IsFailure || rightResult.IsFailure)
            return new ValueOperation(Result<INumericType>.Failure([.. leftResult.Errors, 
                                                                    .. rightResult.Errors]));

        Result<INumericType> result = leftResult.GetValue().Multiply(rightResult.GetValue());

        return new ValueOperation(result);
    }
}
