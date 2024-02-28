using CheckDigit.Helpers;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CheckDigit;

public sealed class CNPJCompute : ICNPJCompute
{
    public int Calculate(long cnpj, int filial)
    {
        return Calculate(cnpj * 10000 + filial);
    }

    public int Calculate(long cnpj)
    {
        int digito = CalculateDigito(cnpj);
        cnpj = cnpj * 10 + digito;
        return (digito * 10) + CalculateDigito(cnpj);
    }

    public string Calculate(string cnpj, string filial)
    {
        return Calculate(cnpj.ConvertToInt64(), filial.ConvertToInt32()).ToString("00", CultureInfo.InvariantCulture);
    }

    public string Calculate(string valor)
    {
        return Calculate(valor.ConvertToInt64()).ToString();
    }

    private int CalculateDigito(long numero)
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

    public bool Validate(long cnpj, int filial, int dv)
    {
        return dv.Equals(Calculate(cnpj, filial));
    }

    public bool Validate(string cnpj, string filial, string dv)
    {
        return dv.Equals(Calculate(cnpj, filial));
    }

    public bool Validate(long cnpj)
    {
        long numero = cnpj / 1000000;
        int filial = (int)(cnpj % 1000000) / 100;
        int dv = (int)(cnpj % 100);
        return Validate(numero, filial, dv);
    }

    public bool Validate(string valor)
    {
        return Validate(valor.ConvertToInt64());
    }
}
