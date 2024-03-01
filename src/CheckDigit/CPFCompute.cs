using System.Globalization;

namespace CheckDigit;

/// <summary>
/// Valida dígitos de CPF
/// </summary>
public sealed class CPFCompute : Modulus11Compute
{
    public CPFCompute() 
        : base(n => { return ++n; }, CalculateDigit) { }

    /// <summary>
    /// Calcula dígito de CPF.
    /// </summary>
    /// <param name="cpf">Número do CPF</param>
    /// <returns>Dígito do CPF</returns>
    public override int Calculate(long cpf)
    {
        int digito = base.Calculate(cpf);
        cpf = cpf * 10 + digito;
        return digito * 10 + base.Calculate(cpf);
    }

    /// <summary>
    /// Calcula dígito de CPF.
    /// </summary>
    /// <param name="cpf">Número do CPF</param>
    /// <returns>Dígito do CPF</returns>
    public override string Calculate(string cpf)
    {
        return Calculate(cpf.ConvertToInt32()).ToString("00", CultureInfo.InvariantCulture);
    }

    private static int CalculateDigit(long sum)
    {
        int resto = (int)sum % 11;
        return resto < 2 ? 0 : (11 - resto);
    }

    /// <summary>
    /// Valida dígito de CPF.
    /// </summary>
    /// <param name="cpf">Número do CPF</param>
    /// <returns>True para número de CPF válido.</returns>
    public override bool Validate(long cpf)
    {
        return Validate(cpf / 100, (int)(cpf % 100));
    }
}
