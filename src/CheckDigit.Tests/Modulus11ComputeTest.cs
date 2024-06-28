namespace CheckDigit.Tests;

/// <summary>
/// Examples from https://www.cjdinfo.com.br/publicacao-calculo-digito-verificador
/// </summary>
public class Modulus11ComputeTest
{
    [Fact]
    public void CalculateLong()
    {
        // Arrange
        long number = 261533;
        int digit = 9;
        IModulusCompute compute = new Modulus11Compute();

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
        string digit = "9";
        IModulusCompute compute = new Modulus11Compute();

        // Act
        string result = compute.Calculate(number);

        // Assert
        Assert.Equal(digit, result);
    }

    [Fact]
    public void ValidateLong()
    {
        // Arrange
        long number = 2615339;
        IModulusCompute compute = new Modulus11Compute();

        // Act
        bool result = compute.Validate(number);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ValidateString()
    {
        // Arrange
        string number = "2615339";
        IModulusCompute compute = new Modulus11Compute();

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
        int digit = 9;
        IModulusCompute compute = new Modulus11Compute();

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
        string digit = "9";
        IModulusCompute compute = new Modulus11Compute();

        // Act
        bool result = compute.Validate(number, digit);

        // Assert
        Assert.True(result);
    }
}