using BaseUtils.FlowControl.ResultType;
using MathSolver.NumericTypes;

namespace MathSolver.Operations;
public interface IOperation
{
    Result<INumericType> Evaluate();
    IOperation Compile();
}
