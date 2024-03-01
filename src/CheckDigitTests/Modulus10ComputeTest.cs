using CheckDigit;

namespace CheckDigitTests;

public class Modulus10ComputeTest
{
    [Fact]
    public void CalculateLong()
    {
        // Arrange
        long number = 261533;
        int digit = 4;
        IModulusCompute compute = new Modulus10Compute();

        // Act
        int result = compute.Calculate(number);

        // Assert
        Assert.Equal(digit, result);
    }

    [Fact]
    public void CalculateString()
    {
        // Arrange
        string number = "261533";
        string digit = "4";
        IModulusCompute compute = new Modulus10Compute();

        // Act
        string result = compute.Calculate(number);

        // Assert
        Assert.Equal(digit, result);
    }

    [Fact]
    public void ValidateLong()
    {
        // Arrange
        long number = 2615334;
        IModulusCompute compute = new Modulus10Compute();

        // Act
        bool result = compute.Validate(number);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ValidateString()
    {
        // Arrange
        string number = "2615334";
        IModulusCompute compute = new Modulus10Compute();

        // Act
        bool result = compute.Validate(number);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ValidateDigitLong()
    {
        // Arrange
        long number = 261533;
        int digit = 4;
        IModulusCompute compute = new Modulus10Compute();

        // Act
        bool result = compute.Validate(number, digit);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ValidateDigitString()
    {
        // Arrange
        string number = "261533";
        string digit = "4";
        IModulusCompute compute = new Modulus10Compute();

        // Act
        bool result = compute.Validate(number, digit);

        // Assert
        Assert.True(result);
    }
}
