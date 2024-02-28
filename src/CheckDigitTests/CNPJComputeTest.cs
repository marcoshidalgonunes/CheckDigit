using CheckDigit;

namespace CheckDigitTests;

public class CNPJComputeTest
{
    [Fact]
    public void CalculateLong()
    {
        // Arrange
        long cnpj = 12345678; // "12345678000195";
        int filial = 0001;
        int digito = 95;
        ICNPJCompute compute = new CNPJCompute();

        // Act
        int result = compute.Calculate(cnpj, filial);

        // Assert
        Assert.Equal(digito, result);
    }

    [Fact]
    public void CalculateString()
    {
        // Arrange
        string cnpj = "12345678";
        string filial = "0001";
        string digito = "95";
        ICNPJCompute compute = new CNPJCompute();

        // Act
        string result = compute.Calculate(cnpj, filial);

        // Assert
        Assert.Equal(digito, result);
    }

    [Fact]
    public void CalculateWithFilialLong()
    {
        // Arrange
        long cnpj = 123456780001;
        int digito = 95;
        ICNPJCompute compute = new CNPJCompute();

        // Act
        int result = compute.Calculate(cnpj);

        // Assert
        Assert.Equal(digito, result);
    }

    [Fact]
    public void CalculateWithFilialString()
    {
        // Arrange
        string cnpj = "123456780001";
        string digito = "95";
        ICNPJCompute compute = new CNPJCompute();

        // Act
        string result = compute.Calculate(cnpj);

        // Assert
        Assert.Equal(digito, result);
    }

    [Fact]
    public void ValidateLong()
    {
        // Arrange
        long cnpj = 12345678000195;
        ICNPJCompute compute = new CNPJCompute();

        // Act
        bool result = compute.Validate(cnpj);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ValidateString()
    {
        // Arrange
        string cnpj = "12345678000195";
        ICNPJCompute compute = new CNPJCompute();

        // Act
        bool result = compute.Validate(cnpj);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ValidateDigitLong()
    {
        // Arrange
        long cnpj = 12345678;
        int filial = 0001;
        int digito = 95;
        ICNPJCompute compute = new CNPJCompute();

        // Act
        bool result = compute.Validate(cnpj, filial, digito);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ValidateDigitString()
    {
        // Arrange
        string cnpj = "12345678";
        string filial = "0001";
        string digito = "95";
        ICNPJCompute compute = new CNPJCompute();

        // Act
        bool result = compute.Validate(cnpj, filial, digito);

        // Assert
        Assert.True(result);
    }
}
