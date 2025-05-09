using MathSolver.NumericTypes;

namespace MathSolverTests.NumericTypes;
public class DecimalTypeTests
{
    [Theory(DisplayName = "DTT 1.01 - CreateObject")]
    [InlineData(0.3)]
    [InlineData(0)]
    [InlineData(-11)]
    [InlineData(24)]
    [InlineData(-3.92)]
    public void DecimalTypeTest1(decimal value)
    {
        // When
        var number = new DecimalNumber(value);

        // Then
        Assert.Equal(value, number.Value);
    }

    [Theory(DisplayName = "DTT 2.01 - Sum two decimal numbers.")]
    [InlineData(0.1, 0.2, 0.3)]
    [InlineData(0, -0, 0)]
    [InlineData(-11, 2, -9)]
    [InlineData(24, 12.1, 36.1)]
    [InlineData(-3.92, 4, 0.08)]
    public void DecimalTypeTest2(decimal leftNumber, decimal rightNumber, decimal result)
    {
        // Given
        var leftDecimal = new DecimalNumber(leftNumber);
        var rightDecimal = new DecimalNumber(rightNumber);

        // When
        var resultDecimal = leftDecimal.Add(rightDecimal);

        // Then
        Assert.True(resultDecimal.IsSuccess);

        var resultValue = (DecimalNumber)resultDecimal.GetValue();
        Assert.Equal(result, resultValue.Value);
    }

    [Theory(DisplayName = "DTT 3.01 - Check comutative property.")]
    [InlineData(0.1, 0.2, 0.3)]
    [InlineData(0, 0, 0)]
    [InlineData(-11, 3.5, -7.5)]
    [InlineData(24, 12, 36)]
    [InlineData(-3.92, 4, 0.08)]
    public void DecimalTypeTest3(decimal leftNumber, decimal rightNumber, decimal result)
    {
        // Given
        var leftDecimal = new DecimalNumber(leftNumber);
        var rightDecimal = new DecimalNumber(rightNumber);

        // When
        var resultDecimal1 = leftDecimal.Add(rightDecimal);
        var resultDecimal2 = rightDecimal.Add(leftDecimal);

        // Then
        Assert.True(resultDecimal1.IsSuccess);
        var resultValue1 = (DecimalNumber)resultDecimal1.GetValue();
        Assert.Equal(result, resultValue1.Value);
        
        Assert.True(resultDecimal2.IsSuccess);
        var resultValue2 = (DecimalNumber)resultDecimal2.GetValue();
        Assert.Equal(result, resultValue2.Value);

        Assert.Equal(resultValue1, resultValue2);
    }

    [Theory(DisplayName = "DTT 4.01 - sum decimal with imaginary number.")]
    [InlineData(0.1, 0.25, 3, 0.35, 3)]
    [InlineData(0, 0, 0, 0, 0)]
    [InlineData(22, -3, -4, 19, -4)]
    [InlineData(24, 12, 36, 36, 36)]
    [InlineData(-32, 4, 0, -28, 0)]
    public void DecimalTypeTest4(decimal leftNumber, 
        decimal rightRealNumber, decimal rightImaginaryNumber, 
        decimal resultReal, decimal resultImaginary)
    {
        // Given
        var leftDecimal = new DecimalNumber(leftNumber);
        var rightDecimal = new ImaginaryNumber(rightRealNumber, rightImaginaryNumber);

        // When
        var result = leftDecimal.Add(rightDecimal);

        // Then
        Assert.True(result.IsSuccess);
        
        var resultValue = (ImaginaryNumber)result.GetValue();

        Assert.Equal(resultReal, resultValue.RealPart);
        Assert.Equal(resultImaginary, resultValue.ImaginaryPart);
    }
}