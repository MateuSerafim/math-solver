using MathSolver.NumericTypes;
using MathSolver.Operations.NumericOperations;

namespace MathSolverTests.Operations.Numeric;
public class ValueOperationtests
{
    [Fact(DisplayName = "VOT 1.01 - Create Value Operation")]
    public void ValueOperationTest1()
    {
        // Given
        var decimalValue = new DecimalNumber(23m);
        var operation = new ValueOperation(decimalValue);
    
        // When
        var result = operation.Evaluate();
    
        // Then
        Assert.True(result.IsSuccess);
        Assert.Equal(decimalValue, result.GetValue());
    }

    [Fact(DisplayName = "VOT 1.02 - Create Value Operation with null value")]
    public void ValueOperationTest2()
    {
        // Given
        #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        var operation = new ValueOperation(null);
        #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        // When
        var result = operation.Evaluate();
    
        // Then
        Assert.True(result.IsFailure);
        Assert.Equal(ValueOperation.NumericValueCannotBeNull, result.Errors[0].ErrorMessage());
    }

    [Fact(DisplayName = "VOT 2.01 - Compile Value Operation")]
    public void ValueOperationTest3()
    {
        // Given
        var operation = new ValueOperation(new DecimalNumber(39));

        // When
        var result = operation.Compile();
    
        // Then
        Assert.Equal(operation, result);
    }
}
