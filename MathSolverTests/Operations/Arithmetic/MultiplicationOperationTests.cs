using MathSolver.NumericTypes;
using MathSolver.Operations.Arithmetic;
using MathSolver.Operations.NumericOperations;

namespace MathSolverTests.Operations.Arithmetic;
public class MultiplicationOperationTests
{   
    [Theory(DisplayName = "MOT 1.01 - Create Multiplication Operation")]
    [InlineData(0.1, 0.2, 0.02)]
    [InlineData(0, -0, 0)]
    [InlineData(-11, 2, -22)]
    [InlineData(10, 12.1, 121)]
    [InlineData(4, 0, 0)]
    [InlineData(32.1, 1, 32.1)]
    public void MultiplicationOperationTest1(decimal leftValue, decimal rightValue, decimal resultValue)
    {
        // Given
        var leftOperation = new ValueOperation(new DecimalNumber(leftValue));
        var rightOperation = new ValueOperation(new DecimalNumber(rightValue));
        var operation = new MultiplicationOperation(leftOperation, rightOperation);
    
        // When
        var result = operation.Evaluate();
    
        // Then
        Assert.True(result.IsSuccess);
        Assert.Equal(resultValue, ((DecimalNumber)result.GetValue()).Value);
    }

    [Fact(DisplayName = "MOT 2.01 - Create Value Operation with null value")]
    public void ValueOperationTest2()
    {

        var rightOperation = new ValueOperation(new DecimalNumber(2));

        #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        var operation = new MultiplicationOperation(null, rightOperation);
        #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        // When
        var result = operation.Evaluate();
    
        // Then
        Assert.True(result.IsFailure);
        Assert.Equal(ArithmeticExtensions.OperationCannotBeNull, 
                     result.Errors[0].ErrorMessage());
    }

    [Fact(DisplayName = "SOT 3.01 - Create Value Operation with invalid expression")]
    public void ValueOperationTest3()
    {
        #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        var leftOperation = new ValueOperation(null);
        #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        var rightOperation = new ValueOperation(new DecimalNumber(2));

        var operation = new MultiplicationOperation(leftOperation, rightOperation);

        // When
        var result = operation.Evaluate();
    
        // Then
        Assert.True(result.IsFailure);
        Assert.Equal(ValueOperation.NumericValueCannotBeNull, 
                     result.Errors[0].ErrorMessage());
    }
}
