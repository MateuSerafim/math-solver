using BaseUtils.FlowControl.ResultType;
using MathSolver.NumericTypes;

namespace MathSolver.Expressions;
public interface IExpression
{
    Result<INumericType> Evaluate();
}
