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

    [Theory(DisplayName = "DTT 2.02 - sum decimal with imaginary number.")]
    [InlineData(0.1, 0.25, 3, 0.35, 3)]
    [InlineData(0, 0, 0, 0, 0)]
    [InlineData(22, -3, -4, 19, -4)]
    [InlineData(24, 12, 36, 36, 36)]
    [InlineData(-32, 4, 0, -28, 0)]
    public void DecimalTypeTest3(decimal leftNumber, 
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

    [Theory(DisplayName = "DTT 3.01 - Check sum comutative property.")]
    [InlineData(0.1, 0.2, 0.3)]
    [InlineData(0, 0, 0)]
    [InlineData(-11, 3.5, -7.5)]
    [InlineData(24, 12, 36)]
    [InlineData(-3.92, 4, 0.08)]
    public void DecimalTypeTest4(decimal leftNumber, decimal rightNumber, decimal result)
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

    [Theory(DisplayName = "DTT 4.01 - Subtract two decimal numbers.")]
    [InlineData(0.1, 0.2, -0.1)]
    [InlineData(0, -0, 0)]
    [InlineData(-21, 2, -23)]
    [InlineData(24, 12.6, 11.4)]
    [InlineData(-3.92, -4, 0.08)]
    public void DecimalTypeTest5(decimal leftNumber, decimal rightNumber, decimal result)
    {
        // Given
        var leftDecimal = new DecimalNumber(leftNumber);
        var rightDecimal = new DecimalNumber(rightNumber);

        // When
        var resultDecimal = leftDecimal.Subtract(rightDecimal);

        // Then
        Assert.True(resultDecimal.IsSuccess);

        var resultValue = (DecimalNumber)resultDecimal.GetValue();
        Assert.Equal(result, resultValue.Value);
    }

    [Theory(DisplayName = "DTT 4.02 - Subtract decimal with imaginary number.")]
    [InlineData(0.1, 0.25, 3, -0.15, -3)]
    [InlineData(0, 0, 0, 0, 0)]
    [InlineData(22, -3, -4, 25, 4)]
    [InlineData(24, 12, 36, 12, -36)]
    [InlineData(-32, 4, 0, -36, 0)]
    public void DecimalTypeTest6(decimal leftNumber, 
        decimal rightRealNumber, decimal rightImaginaryNumber, 
        decimal resultReal, decimal resultImaginary)
    {
        // Given
        var leftDecimal = new DecimalNumber(leftNumber);
        var rightDecimal = new ImaginaryNumber(rightRealNumber, rightImaginaryNumber);

        // When
        var result = leftDecimal.Subtract(rightDecimal);

        // Then
        Assert.True(result.IsSuccess);
        
        var resultValue = (ImaginaryNumber)result.GetValue();

        Assert.Equal(resultReal, resultValue.RealPart);
        Assert.Equal(resultImaginary, resultValue.ImaginaryPart);
    }

    [Theory(DisplayName = "DTT 5.01 - multiply two decimal numbers.")]
    [InlineData(0.1, 0.2, 0.02)]
    [InlineData(0, -0, 0)]
    [InlineData(1, 2, 2)]
    [InlineData(24, 12.6, 302.4)]
    [InlineData(-3.92, -4, 15.68)]
    [InlineData(-2, 2, -4)]
    public void DecimalTypeTest7(decimal leftNumber, decimal rightNumber, decimal result)
    {
        // Given
        var leftDecimal = new DecimalNumber(leftNumber);
        var rightDecimal = new DecimalNumber(rightNumber);

        // When
        var resultDecimal = leftDecimal.Multiply(rightDecimal);

        // Then
        Assert.True(resultDecimal.IsSuccess);

        var resultValue = (DecimalNumber)resultDecimal.GetValue();
        Assert.Equal(result, resultValue.Value);
    }

    [Theory(DisplayName = "DTT 5.02 - multiply decimal with imaginary number.")]
    [InlineData(0.1, 0.25, 3, 0.025, 0.3)]
    [InlineData(0, 0, 0, 0, 0)]
    [InlineData(22, -3, -4, -66, -88)]
    [InlineData(24, 2, 0.5, 48, 12)]
    [InlineData(-2, 4, 0, -8, 0)]
    public void DecimalTypeTest8(decimal leftNumber, 
        decimal rightRealNumber, decimal rightImaginaryNumber, 
        decimal resultReal, decimal resultImaginary)
    {
        // Given
        var leftDecimal = new DecimalNumber(leftNumber);
        var rightDecimal = new ImaginaryNumber(rightRealNumber, rightImaginaryNumber);

        // When
        var result = leftDecimal.Multiply(rightDecimal);

        // Then
        Assert.True(result.IsSuccess);
        
        var resultValue = (ImaginaryNumber)result.GetValue();

        Assert.Equal(resultReal, resultValue.RealPart);
        Assert.Equal(resultImaginary, resultValue.ImaginaryPart);
    }

    [Theory(DisplayName = "DTT 6.01 - Check multiply comutative property with decimal numbers.")]
    [InlineData(0.1, 0.2, 0.02)]
    [InlineData(0, -0, 0)]
    [InlineData(1, 2, 2)]
    [InlineData(24, 12.6, 302.4)]
    [InlineData(-3.92, -4, 15.68)]
    [InlineData(-2, 2, -4)]
    public void DecimalTypeTest9(decimal leftNumber, decimal rightNumber, decimal result)
    {
        // Given
        var leftDecimal = new DecimalNumber(leftNumber);
        var rightDecimal = new DecimalNumber(rightNumber);

        // When
        var resultDecimal1 = leftDecimal.Multiply(rightDecimal);
        var resultDecimal2 = rightDecimal.Multiply(leftDecimal);

        // Then
        Assert.True(resultDecimal1.IsSuccess);
        var resultValue1 = (DecimalNumber)resultDecimal1.GetValue();
        Assert.Equal(result, resultValue1.Value);
        
        Assert.True(resultDecimal2.IsSuccess);
        var resultValue2 = (DecimalNumber)resultDecimal2.GetValue();
        Assert.Equal(result, resultValue2.Value);

        Assert.Equal(resultValue1, resultValue2);
    }

    [Theory(DisplayName = "DTT 6.02 - Check multiply comutative property with Imaginary numbers.")]
    [InlineData(0.1, 0.25, 3, 0.025, 0.3)]
    [InlineData(0, 0, 0, 0, 0)]
    [InlineData(22, -3, -4, -66, -88)]
    [InlineData(24, 2, 0.5, 48, 12)]
    [InlineData(-2, 4, 0, -8, 0)]
    public void DecimalTypeTest10(decimal leftNumber, 
        decimal rightRealNumber, decimal rightImaginaryNumber, 
        decimal resultReal, decimal resultImaginary)
    {
        // Given
        var leftDecimal = new DecimalNumber(leftNumber);
        var rightDecimal = new ImaginaryNumber(rightRealNumber, rightImaginaryNumber);

        // When
        var resultDecimal1 = leftDecimal.Multiply(rightDecimal);
        var resultDecimal2 = rightDecimal.Multiply(leftDecimal);

        // Then
        Assert.True(resultDecimal1.IsSuccess);
        var resultValue1 = (ImaginaryNumber)resultDecimal1.GetValue();
        Assert.Equal(resultReal, resultValue1.RealPart);
        Assert.Equal(resultImaginary, resultValue1.ImaginaryPart);
        
        Assert.True(resultDecimal2.IsSuccess);
        var resultValue2 = (ImaginaryNumber)resultDecimal2.GetValue();
         Assert.Equal(resultImaginary, resultValue2.ImaginaryPart);

        Assert.Equal(resultValue1, resultValue2);
    }
}