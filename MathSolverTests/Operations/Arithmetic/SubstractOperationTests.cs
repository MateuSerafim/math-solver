using MathSolver.NumericTypes;
using MathSolver.Operations.Arithmetic;
using MathSolver.Operations.NumericOperations;

namespace MathSolverTests.Operations.Arithmetic;
public class SubstractOperationTests
{
    [Theory(DisplayName = "SubOT 1.01 - Create Subtract Operation")]
    [InlineData(0.1, 0.2, -0.1)]
    [InlineData(0, -0, 0)]
    [InlineData(-11, -2, -9)]
    [InlineData(24, 12.1, 11.9)]
    [InlineData(-3.92, 4, -7.92)]
    public void SubtractOperationTest1(decimal leftValue, decimal rightValue, decimal resultValue)
    {
        // Given
        var leftOperation = new ValueOperation(new DecimalNumber(leftValue));
        var rightOperation = new ValueOperation(new DecimalNumber(rightValue));
        var operation = new SubtractOperation(leftOperation, rightOperation);
    
        // When
        var result = operation.Evaluate();
    
        // Then
        Assert.True(result.IsSuccess);
        Assert.Equal(resultValue, ((DecimalNumber)result.GetValue()).Value);
    }

    [Fact(DisplayName = "SubOT 2.01 - Create Subtract operation with null value")]
    public void SubtractOperationTest2()
    {

        var rightOperation = new ValueOperation(new DecimalNumber(2));

        #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        var operation = new SubtractOperation(null, rightOperation);
        #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        // When
        var result = operation.Evaluate();
    
        // Then
        Assert.True(result.IsFailure);
        Assert.Equal(ArithmeticExtensions.OperationCannotBeNull, 
                     result.Errors[0].ErrorMessage());
    }

    [Fact(DisplayName = "SubOT 3.01 - Create Substract Operation with invalid expression")]
    public void SubtractOperationTest3()
    {
        #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        var leftOperation = new ValueOperation(null);
        #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        var rightOperation = new ValueOperation(new DecimalNumber(2));

        var operation = new SubtractOperation(leftOperation, rightOperation);

        // When
        var result = operation.Evaluate();
    
        // Then
        Assert.True(result.IsFailure);
        Assert.Equal(ValueOperation.NumericValueCannotBeNull, 
                     result.Errors[0].ErrorMessage());
    }
}
