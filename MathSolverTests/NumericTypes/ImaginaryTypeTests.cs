using MathSolver.NumericTypes;

namespace MathSolverTests.NumericTypes;

public class ImaginaryTypeTests
{
    [Theory(DisplayName = "ITT 1.01 - Create imaginary Number")]
    [InlineData(0.3, 1)]
    [InlineData(0, 0)]
    [InlineData(-11, 2)]
    [InlineData(24, -1)]
    [InlineData(-3.92, 2.49)]
    public void ImaginaryTypeTest1(decimal realPart, decimal imaginaryPart)
    {
        // When
        var number = new ImaginaryNumber(realPart, imaginaryPart);

        // Then
        Assert.Equal(realPart, number.RealPart);
        Assert.Equal(imaginaryPart, number.ImaginaryPart);
    }

    [Theory(DisplayName = "ITT 2.01 - Sum two imaginary numbers.")]
    [InlineData(0.1, 0.2, 0.3, -0.2, 0.4, 0)]
    [InlineData(0, -0, 0, 0, 0, 0)]
    [InlineData(-11, 2, -9, 2, -20, 4)]
    [InlineData(24, 12.1, 36.1, 0, 60.1, 12.1)]
    [InlineData(-3.92, 4, 0.08, 0.3, -3.84, 4.3)]
    public void ImaginaryTypeTest2(
        decimal leftRealPart, decimal leftImaginaryPart,
        decimal rightRealPart, decimal rightImaginaryPart, 
        decimal resultRealPart, decimal resultImaginaryPart)
    {
        // Given
        var leftImaginary = new ImaginaryNumber(leftRealPart, leftImaginaryPart);
        var rightImaginary = new ImaginaryNumber(rightRealPart, rightImaginaryPart);

        // When
        var resultImaginary = leftImaginary.Add(rightImaginary);

        // Then
        Assert.True(resultImaginary.IsSuccess);

        var resultValue = (ImaginaryNumber)resultImaginary.GetValue();
        Assert.Equal(resultRealPart, resultValue.RealPart);
        Assert.Equal(resultImaginaryPart, resultValue.ImaginaryPart);
    }

    [Theory(DisplayName = "ITT 2.02 - sum imaginary with decimal number.")]
    [InlineData(0.1, 0.25, 3, 0.35, 3)]
    [InlineData(0, 0, 0, 0, 0)]
    [InlineData(22, -3, -4, 19, -4)]
    [InlineData(24, 12, 36, 36, 36)]
    [InlineData(-32, 4, 0, -28, 0)]
    public void ImaginaryTypeTest4(decimal rightNumber, 
        decimal leftRealNumber, decimal leftImaginaryNumber, 
        decimal resultReal, decimal resultImaginary)
    {
        // Given
        var leftDecimal = new ImaginaryNumber(leftRealNumber, leftImaginaryNumber);
        var rightDecimal = new DecimalNumber(rightNumber);

        // When
        var result = leftDecimal.Add(rightDecimal);

        // Then
        Assert.True(result.IsSuccess);
        
        var resultValue = (ImaginaryNumber)result.GetValue();

        Assert.Equal(resultReal, resultValue.RealPart);
        Assert.Equal(resultImaginary, resultValue.ImaginaryPart);
    }

    [Theory(DisplayName = "ITT 3.01 - Check comutative property.")]
    [InlineData(0.1, 0.2, 0.3, -0.2, 0.4, 0)]
    [InlineData(0, -0, 0, 0, 0, 0)]
    [InlineData(-11, 2, -9, 2, -20, 4)]
    [InlineData(24, 12.1, 36.1, 0, 60.1, 12.1)]
    [InlineData(-3.92, 4, 0.08, 0.3, -3.84, 4.3)]
    public void ImaginaryTypeTest3(
        decimal leftRealPart, decimal leftImaginaryPart,
        decimal rightRealPart, decimal rightImaginaryPart, 
        decimal resultRealPart, decimal resultImaginaryPart)
    {
        // Given
        var leftImaginary = new ImaginaryNumber(leftRealPart, leftImaginaryPart);
        var rightImaginary = new ImaginaryNumber(rightRealPart, rightImaginaryPart);

        // When
        var resultImaginary1 = leftImaginary.Add(rightImaginary);
        var resultImaginary2 = rightImaginary.Add(leftImaginary);

        // Then
        Assert.True(resultImaginary1.IsSuccess);
        var resultValue1 = (ImaginaryNumber)resultImaginary1.GetValue();
        Assert.Equal(resultRealPart, resultValue1.RealPart);
        Assert.Equal(resultImaginaryPart, resultValue1.ImaginaryPart);
        
        Assert.True(resultImaginary2.IsSuccess);
        var resultValue2 = (ImaginaryNumber)resultImaginary2.GetValue();
        Assert.Equal(resultRealPart, resultValue2.RealPart);
        Assert.Equal(resultImaginaryPart, resultValue2.ImaginaryPart);

        Assert.Equal(resultValue1, resultValue2);
    }

    [Theory(DisplayName = "ITT 4.01 - Substract two imaginary numbers.")]
    [InlineData(0.1, 0.2, 0.3, -0.2, -0.2, 0.4)]
    [InlineData(0, -0, 0, 0, 0, 0)]
    [InlineData(-11, 2, -9, 2, -2, 0)]
    [InlineData(24, 12.1, 36.1, 0, -12.1, 12.1)]
    [InlineData(-3.92, 4, 0.08, 0.3, -4, 3.7)]
    public void ImaginaryTypeTest5(
        decimal leftRealPart, decimal leftImaginaryPart,
        decimal rightRealPart, decimal rightImaginaryPart, 
        decimal resultRealPart, decimal resultImaginaryPart)
    {
        // Given
        var leftImaginary = new ImaginaryNumber(leftRealPart, leftImaginaryPart);
        var rightImaginary = new ImaginaryNumber(rightRealPart, rightImaginaryPart);

        // When
        var resultImaginary = leftImaginary.Subtract(rightImaginary);

        // Then
        Assert.True(resultImaginary.IsSuccess);

        var resultValue = (ImaginaryNumber)resultImaginary.GetValue();
        Assert.Equal(resultRealPart, resultValue.RealPart);
        Assert.Equal(resultImaginaryPart, resultValue.ImaginaryPart);
    }

    [Theory(DisplayName = "ITT 4.02 - subtract imaginary with decimal number.")]
    [InlineData(0.1, 0.25, 3, 0.15, 3)]
    [InlineData(0, 0, 0, 0, 0)]
    [InlineData(22, -3, -4, -25, -4)]
    [InlineData(24, 12, 36, -12, 36)]
    [InlineData(-32, 4, 0, 36, 0)]
    public void ImaginaryTypeTest6(decimal rightNumber, 
        decimal leftRealNumber, decimal leftImaginaryNumber, 
        decimal resultReal, decimal resultImaginary)
    {
        // Given
        var leftDecimal = new ImaginaryNumber(leftRealNumber, leftImaginaryNumber);
        var rightDecimal = new DecimalNumber(rightNumber);

        // When
        var result = leftDecimal.Subtract(rightDecimal);

        // Then
        Assert.True(result.IsSuccess);
        
        var resultValue = (ImaginaryNumber)result.GetValue();

        Assert.Equal(resultReal, resultValue.RealPart);
        Assert.Equal(resultImaginary, resultValue.ImaginaryPart);
    }
}
