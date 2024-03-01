using CheckDigit.Helpers;
using System.Globalization;

namespace CheckDigit;

/// <summary>
/// Valida dígitos de CNPJ
/// </summary>
public sealed class CNPJCompute : ICNPJCompute
{
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
        int digito = CalculateDigito(cnpj);
        cnpj = cnpj * 10 + digito;
        return (digito * 10) + CalculateDigito(cnpj);
    }

    /// <summary>
    /// Calcula dígito de CNPJ.
    /// </summary>
    /// <param name="cnpj">Número do CNPJ</param>
    /// <param name="filial">Filial do PJ</param>
    /// <returns>Dígito do CNPJ</returns>
    public string Calculate(string cnpj, string filial)
    {
        return Calculate(cnpj.ConvertToInt64(), filial.ConvertToInt32()).ToString("00", CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Calcula dígito de CNPJ.
    /// </summary>
    /// <param name="cnpj">Número do CNPJ</param>
    /// <returns>Dígito do CNPJ</returns>
    public string Calculate(string valor)
    {
        return Calculate(valor.ConvertToInt64()).ToString();
    }

    private static int CalculateDigito(long numero)
    {
        long somatorio = 0;
        int divisor = 1;
        do
        {
            divisor = Modulus11Helper.CalculateMultiplier(divisor);

            somatorio += numero % 10 * divisor;
            numero /= 10;
        } while (numero > 0);

        return Modulus11Helper.CalculateDigit((int)(somatorio % 11));
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
        return dv.Equals(Calculate(cnpj, filial));
    }

    /// <summary>
    /// Valida número do CNPJ.
    /// </summary>
    /// <param name="cnpj">Número do CNPJ</param>
    /// <returns>True para número do CNPJ válido</returns>
    public bool Validate(string valor)
    {
        return Validate(valor.ConvertToInt64());
    }
}
