namespace CheckDigit;

public interface ICNPJCompute : ICompute
{
    int Calculate(long cnpj, int filial);

    string Calculate(string cnpj, string filial);

    bool Validate(long cnpj, int filial, int digito);

    bool Validate(string cnpj, string filial, string digito);
}
