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
        string number = "12345678909";
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
