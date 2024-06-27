using CheckDigit;

namespace CheckDigitTests;

public class CPFComputeTest
{
    [Fact]
    public void CalculateLong()
    {
        // Arrange
        long number = 123456789;
        int digit = 09;
        IModulusCompute compute = new CPFCompute();

        // Act
        int result = compute.Calculate(number);

        // Assert
        Assert.Equal(digit, result);
    }

    [Fact]
    public void CalculateString()
    {
        // Arrange
        string number = "123456789";
        string digit = "09";
        IModulusCompute compute = new CPFCompute();

        // Act
        string result = compute.Calculate(number);

        // Assert
        Assert.Equal(digit, result);
    }

    [Fact]
    public void InvalidateLong()
    {
        // Arrange
        long number = 12345678990;
        IModulusCompute compute = new CPFCompute();

        // Act
        bool result = compute.Validate(number);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void InvalidateString()
    {
        // Arrange
        string number = "ABC.DEF.GHI-09";
        IModulusCompute compute = new CPFCompute();

        // Act
        Action act = () => compute.Validate(number);

        // Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("CPF deve estar no formato 999.999.999-99", exception.Message);
    }

    [Fact]
    public void InvalidateDigitLong()
    {
        // Arrange
        long number = 123456789;
        int digit = 90;
        IModulusCompute compute = new CPFCompute();

        // Act
        bool result = compute.Validate(number, digit);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void InvalidateDigitString()
    {
        // Arrange
        string number = "123456789";
        string digit = "90";
        IModulusCompute compute = new CPFCompute();

        // Act
        bool result = compute.Validate(number, digit);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ValidateLong()
    {
        // Arrange
        long number = 12345678909;
        IModulusCompute compute = new CPFCompute();

        // Act
        bool result = compute.Validate(number);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ValidateString()
    {
        // Arrange
        string number = "123.456.789-09";
        IModulusCompute compute = new CPFCompute();

        // Act
        bool result = compute.Validate(number);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ValidateDigitLong()
    {
        // Arrange
        long number = 123456789;
        int digit = 09;
        IModulusCompute compute = new CPFCompute();

        // Act
        bool result = compute.Validate(number, digit);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ValidateDigitString()
    {
        // Arrange
        string number = "123456789";
        string digit = "09";
        IModulusCompute compute = new CPFCompute();

        // Act
        bool result = compute.Validate(number, digit);

        // Assert
        Assert.True(result);
    }
}
