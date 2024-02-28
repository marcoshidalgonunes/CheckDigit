namespace CheckDigit;

public interface ICompute
{
    int Calculate(long number);

    string Calculate(string value);

    bool Validate(long number);

    bool Validate(string value);
}
