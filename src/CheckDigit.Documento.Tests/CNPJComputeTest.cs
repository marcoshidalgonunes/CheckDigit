namespace CheckDigit.Documento.Tests;

public class CNPJComputeTest
{
    [Fact]
    public void CalculateAlphanumeric()
    {
        // Arrange
        string cnpj = "ABCDEFGI";
        string filial = "HIJK";
        string digito = "56";
        ICNPJCompute compute = new CNPJCompute();

        // Act
        string result = compute.Calculate(cnpj, filial);

        // Assert
        Assert.Equal(digito, result);
    }

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
    public void CalculateWithFilialAlphanumeric()
    {
        // Arrange
        string cnpj = "ABCDEFGIHIJK";
        string digito = "56";
        ICNPJCompute compute = new CNPJCompute();

        // Act
        string result = compute.Calculate(cnpj);

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
    public void InvalidateAlphanumeric()
    {
        // Arrange
        string cnpj = "AB.CDE.FGI/HIJK-65";
        ICNPJCompute compute = new CNPJCompute();

        // Act
        bool result = compute.Validate(cnpj);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void InvalidateFormatAlphanumeric()
    {
        // Arrange
        string cnpj = "ab.cde.fgi/hijk-56";
        ICNPJCompute compute = new CNPJCompute();

        // Act
        void act() => compute.Validate(cnpj);

        // Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("CNPJ deve estar no formato XX.XXX.XXX/XXXX-99", exception.Message);
    }

    [Fact]
    public void InvalidateLong()
    {
        // Arrange
        long cnpj = 12345678000159;
        ICNPJCompute compute = new CNPJCompute();

        // Act
        bool result = compute.Validate(cnpj);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void InvalidateString()
    {
        // Arrange
        string cnpj = "12.345.678/0001-59";
        ICNPJCompute compute = new CNPJCompute();

        // Act
        bool result = compute.Validate(cnpj);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void InvalidateDigitAlphanumeric()
    {
        // Arrange
        string cnpj = "ABCDEFGI";
        string filial = "HIJK";
        string digito = "65";
        ICNPJCompute compute = new CNPJCompute();

        // Act
        bool result = compute.Validate(cnpj, filial, digito);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void InvalidateDigitFormatAlphanumeric()
    {
        // Arrange
        string cnpj = "abcdefgi";
        string filial = "hijk";
        string digito = "56";
        ICNPJCompute compute = new CNPJCompute();

        // Act
        void act() => compute.Validate(cnpj, filial, digito);

        // Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("CNPJ deve estar no formato XXXXXXXXXXXX99", exception.Message);
    }

    [Fact]
    public void InvalidateDigitLong()
    {
        // Arrange
        long cnpj = 12345678;
        int filial = 0001;
        int digito = 59;
        ICNPJCompute compute = new CNPJCompute();

        // Act
        bool result = compute.Validate(cnpj, filial, digito);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void InvalidateDigitString()
    {
        // Arrange
        string cnpj = "12345678";
        string filial = "0001";
        string digito = "59";
        ICNPJCompute compute = new CNPJCompute();

        // Act
        bool result = compute.Validate(cnpj, filial, digito);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ValidateAlphanumeric()
    {
        // Arrange
        string cnpj = "AB.CDE.FGI/HIJK-56";
        ICNPJCompute compute = new CNPJCompute();

        // Act
        bool result = compute.Validate(cnpj);

        // Assert
        Assert.True(result);
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
        string cnpj = "12.345.678/0001-95";
        ICNPJCompute compute = new CNPJCompute();

        // Act
        bool result = compute.Validate(cnpj);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ValidateDigitAlphanumeric()
    {
        // Arrange
        string cnpj = "ABCDEFGI";
        string filial = "HIJK";
        string digito = "56";
        ICNPJCompute compute = new CNPJCompute();

        // Act
        bool result = compute.Validate(cnpj, filial, digito);

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
