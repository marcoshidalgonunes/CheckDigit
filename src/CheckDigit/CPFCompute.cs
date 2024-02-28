using System.Globalization;

namespace CheckDigit;

public sealed class CPFCompute : Modulus11Compute
{
    public CPFCompute() 
        : base(n => { return ++n; }, CalculateDigit) { }

    private static int CalculateDigit(long sum)
    {
        int resto = (int)sum % 11;
        return resto < 2 ? 0 : (11 - resto);
    }

    public override int Calculate(long cpf)
    {
        int digito = base.Calculate(cpf);
        cpf = cpf * 10 + digito;
        return digito * 10 + base.Calculate(cpf);
    }

    public override string Calculate(string valueCpf)
    {
        return Calculate(valueCpf.ConvertToInt32()).ToString("00", CultureInfo.InvariantCulture);
    }

    public override bool Validate(long cpf)
    {
        return base.Validate(cpf / 100, (int)(cpf % 100));
    }
}
