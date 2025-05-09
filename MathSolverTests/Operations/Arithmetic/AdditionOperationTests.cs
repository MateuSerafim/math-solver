using MathSolver.NumericTypes;
using MathSolver.Operations.Arithmetic;
using MathSolver.Operations.NumericOperations;

namespace MathSolverTests.Operations.Arithmetic;
public class AdditionOperationTests
{
    [Theory(DisplayName = "SOT 1.01 - Create Addition Operation")]
    [InlineData(0.1, 0.2, 0.3)]
    [InlineData(0, -0, 0)]
    [InlineData(-11, 2, -9)]
    [InlineData(24, 12.1, 36.1)]
    [InlineData(-3.92, 4, 0.08)]
    public void AdditionOperationTest1(decimal leftValue, decimal rightValue, decimal resultValue)
    {
        // Given
        var leftOperation = new ValueOperation(new DecimalNumber(leftValue));
        var rightOperation = new ValueOperation(new DecimalNumber(rightValue));
        var operation = new AdditionOperation(leftOperation, rightOperation);
    
        // When
        var result = operation.Evaluate();
    
        // Then
        Assert.True(result.IsSuccess);
        Assert.Equal(resultValue, ((DecimalNumber)result.GetValue()).Value);
    }

    [Fact(DisplayName = "SOT 2.01 - Create Value Operation with null value")]
    public void ValueOperationTest2()
    {

        var rightOperation = new ValueOperation(new DecimalNumber(2));

        #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        var operation = new AdditionOperation(null, rightOperation);
        #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        // When
        var result = operation.Evaluate();
    
        // Then
        Assert.True(result.IsFailure);
        Assert.Equal(ArithmeticNumericExtensions.OperationCannotBeNull, 
                     result.Errors[0].ErrorMessage());
    }

    [Fact(DisplayName = "SOT 3.01 - Create Value Operation with invalid expression")]
    public void ValueOperationTest3()
    {
        #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        var leftOperation = new ValueOperation(null);
        #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        var rightOperation = new ValueOperation(new DecimalNumber(2));

        var operation = new AdditionOperation(leftOperation, rightOperation);

        // When
        var result = operation.Evaluate();
    
        // Then
        Assert.True(result.IsFailure);
        Assert.Equal(ValueOperation.NumericValueCannotBeNull, 
                     result.Errors[0].ErrorMessage());
    }

}
