using System.Globalization;
using System.Text.RegularExpressions;
using CheckDigit.Extensions;

namespace CheckDigit.Documento;

/// <summary>
/// Valida dígitos de CPF
/// </summary>
public sealed partial class CPFCompute : Modulus11Compute
{
    [GeneratedRegex("[\\.-]")]
    private static partial Regex CPFMaskRegex();

    [GeneratedRegex("[0-9]{3}[\\.][0-9]{3}[\\.][0-9]{3}-[0-9]{2}")]
    private static partial Regex CPFFormatRegex();

    public CPFCompute() 
        : base(n => { return ++n; }, CalculateDigit) { }

    private static string Cleanup(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        if (CPFMaskRegex().IsMatch(value) && !CPFFormatRegex().IsMatch(value))
        {
            throw new ArgumentException(CheckDigit_Documento.InvalidCPFFormat);
        }

        return CPFMaskRegex().Replace(value, string.Empty);
    }

    #region IModulusCompute members

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

    public override bool Validate(string cpf, string dv)
    {
        return Validate(cpf + dv);
    }

    public override bool Validate(string value)
    {
        string cpf = Cleanup(value);
        return base.Validate(cpf);
    }

    #endregion
}
