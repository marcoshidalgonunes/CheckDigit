using System.Text.RegularExpressions;
using CheckDigit.Helpers;

namespace CheckDigit.Documento;

/// <summary>
/// Valida dígitos de CNPJ
/// </summary>
public sealed partial class CNPJCompute : Documento, ICNPJCompute
{
    [GeneratedRegex("[\\./-]")]
    private static partial Regex CNPJMaskRegex();

    [GeneratedRegex("[0-9A-Z]{12}[0-9]{2}")]
    private static partial Regex CNPJCleanupRegex();

    [GeneratedRegex("[0-9A-Z]{2}[\\.][0-9A-Z]{3}[\\.][0-9A-Z]{3}[/][0-9A-Z]{4}-[0-9]{2}")]
    private static partial Regex CNPJFormatRegex();

    [GeneratedRegex("[0-9A-Z]{12}")]
    private static partial Regex CNPJValueRegex();

    public CNPJCompute()
        : base(Modulus11Helper.CalculateMultiplier, Modulus11Helper.CalculateDigit) { }

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
           throw new ArgumentException(ResourcesFacade.GetString("InvalidCNPJFormat"));
        }

        string cnpj = CNPJMaskRegex().Replace(value, string.Empty);
        if (!CNPJCleanupRegex().IsMatch(cnpj))
        {
            throw new ArgumentException(ResourcesFacade.GetString("InvalidCNPJCleanedFormat"));
        }

        return cnpj;
    }

    #region IModulus11Compute members

    /// <summary>
    /// Valida número do CNPJ.
    /// </summary>
    /// <param name="cnpj">Número do CNPJ</param>
    /// <returns>True para número do CNPJ válido</returns>
    public override bool Validate(long cnpj)
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
    /// <returns>True para número do CNPJ válido</returns>
    public override bool Validate(string valor)
    {
        const int tamanhoDV = 2;

        string cnpj = Cleanup(valor);
        string cnpjBase = cnpj[..^tamanhoDV];
        string digitos = cnpj[^tamanhoDV..];

        return Calculate(cnpjBase).Equals(digitos);
    }

    #endregion

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
    public override string Calculate(string valor)
    {
        string cnpj = CNPJMaskRegex().Replace(valor, "");
        if (!CNPJValueRegex().IsMatch(cnpj))
        {
            throw new ArgumentException(ResourcesFacade.GetString("InvalidCNPJ"));
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
    /// <param name="filial">Filial do PJ</param>
    /// <param name="dv">Dígito do CNPJ</param>
    /// <returns>True para número do CNPJ válido</returns>
    public bool Validate(string cnpj, string filial, string dv)
    {
        return Validate(cnpj + filial + dv);
    }

    #endregion
}
