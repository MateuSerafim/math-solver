using MathSolver.Expressions;

namespace MathSolver.Operations;
public interface IOperation : IExpression
{
    IOperation Compile();
}
