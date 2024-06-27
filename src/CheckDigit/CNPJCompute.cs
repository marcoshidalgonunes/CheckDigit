using System.Text.RegularExpressions;
using CheckDigit.Helpers;

namespace CheckDigit;

/// <summary>
/// Valida dígitos de CNPJ
/// </summary>
public sealed partial class CNPJCompute : ICNPJCompute
{
    [GeneratedRegex("[\\./-]")]
    private static partial Regex CNPJMaskRegex();

    [GeneratedRegex("[0-9A-Z]{2}[\\.][0-9A-Z]{3}[\\.][0-9A-Z]{3}[/][0-9A-Z]{4}-[0-9]{2}")]
    private static partial Regex CNPJFormatRegex();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Func<int, int> ComputeMultiplier;

    private Func<long, int> ComputeDigit;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public CNPJCompute()
        : this(Modulus11Helper.CalculateMultiplier, Modulus11Helper.CalculateDigit) { }

    private CNPJCompute(Func<int, int> computeMultiplier, Func<long, int> computeDigit)
    {
        ComputeMultiplier = computeMultiplier;
        ComputeDigit = computeDigit;
    }

    private long CalculateDigit(long valor)
    {
        long somatorio = 0;
        int multiplicador = 1;
        do
        {
            multiplicador = ComputeMultiplier(multiplicador);

            somatorio += valor % 10 * multiplicador;
            valor /= 10;
        } while (valor > 0);

        return ComputeDigit(somatorio % 11);
    }

    private string CalculateDigit(string valor)
    {
        long somatorio = 0;
        int multiplicador = 1;

        for (int posicao = valor.Length - 1; posicao >= 0; posicao--)
        {
            multiplicador = ComputeMultiplier(multiplicador);

            int digito = valor[posicao] - '0';
            somatorio += digito * multiplicador;
        }

        return ComputeDigit(somatorio % 11).ToString();
    }

    private static string Cleanup(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        if (CNPJMaskRegex().IsMatch(value) && !CNPJFormatRegex().IsMatch(value))
        {
           throw new ArgumentException(CheckDigit.InvalidCNPJFormat);
        }

        string cnpj = CNPJMaskRegex().Replace(value, string.Empty);
        if (!Regex.IsMatch(cnpj, "[0-9A-Z]{12}[0-9]{2}"))
        {
            throw new ArgumentException(CheckDigit.InvalidCNPJCleanedFormat);
        }

        return cnpj;
    }

    #region ICNPJCompute members

    /// <summary>
    /// Calcula dígito de CNPJ.
    /// </summary>
    /// <param name="cnpj">Número do CNPJ</param>
    /// <param name="filial">Filial do PJ</param>
    /// <returns>Dígito do CNPJ</returns>
    public int Calculate(long cnpj, int filial)
    {
        return Calculate(cnpj * 10000 + filial);
    }

    /// <summary>
    /// Calcula dígito de CNPJ.
    /// </summary>
    /// <param name="cnpj">Número do CNPJ</param>
    /// <returns>Dígito do CNPJ</returns>
    public int Calculate(long cnpj)
    {
        long digito = CalculateDigit(cnpj);
        cnpj = cnpj * 10 + digito;
        return (int)((digito * 10) + CalculateDigit(cnpj));
    }

    /// <summary>
    /// Calcula dígito de CNPJ.
    /// </summary>
    /// <param name="cnpj">Número do CNPJ</param>
    /// <param name="filial">Filial do PJ</param>
    /// <returns>Dígito do CNPJ</returns>
    public string Calculate(string cnpj, string filial)
    {
        return Calculate(cnpj + filial);
    }

    /// <summary>
    /// Calcula dígito de CNPJ.
    /// </summary>
    /// <param name="cnpj">Número do CNPJ</param>
    /// <returns>Dígito do CNPJ</returns>
    public string Calculate(string valor)
    {
        string cnpj = CNPJMaskRegex().Replace(valor, "");
        if (!Regex.IsMatch(cnpj, "[0-9A-Z]{12}"))
        {
            throw new ArgumentException(CheckDigit.InvalidCNPJ);
        }

        string digito = CalculateDigit(cnpj);
        return digito + CalculateDigit(cnpj + digito);
    }

    /// <summary>
    /// Valida número do CNPJ.
    /// </summary>
    /// <param name="cnpj">Número do CNPJ</param>
    /// <param name="filial">Filial do PJ</param>
    /// <param name="dv">Dígito do CNPJ</param>
    /// <returns>True para número do CNPJ válido</returns>
    public bool Validate(long cnpj, int filial, int dv)
    {
        return dv.Equals(Calculate(cnpj, filial));
    }
    
    /// <summary>
    /// Valida número do CNPJ.
    /// </summary>
    /// <param name="cnpj">Número do CNPJ</param>
    /// <returns>True para número do CNPJ válido</returns>
    public bool Validate(long cnpj)
    {
        long numero = cnpj / 1000000;
        int filial = (int)(cnpj % 1000000) / 100;
        int dv = (int)(cnpj % 100);
        return Validate(numero, filial, dv);
    }

    /// <summary>
    /// Valida número do CNPJ.
    /// </summary>
    /// <param name="cnpj">Número do CNPJ</param>
    /// <param name="filial">Filial do PJ</param>
    /// <param name="dv">Dígito do CNPJ</param>
    /// <returns>True para número do CNPJ válido</returns>
    public bool Validate(string cnpj, string filial, string dv)
    {
        return Validate(cnpj + filial + dv);
    }

    /// <summary>
    /// Valida número do CNPJ.
    /// </summary>
    /// <param name="cnpj">Número do CNPJ</param>
    /// <returns>True para número do CNPJ válido</returns>
    public bool Validate(string valor)
    {
        const int tamanhoDV = 2;

        string cnpj = Cleanup(valor);
        string cnpjBase = cnpj[..^tamanhoDV];
        string digitos = cnpj[^tamanhoDV..];

        return Calculate(cnpjBase).Equals(digitos);
    }

    #endregion
}
