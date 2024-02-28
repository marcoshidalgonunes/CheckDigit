namespace CheckDigit;

interface ICompute
{
    int Calculate(long number);

    string Calculate(string value);

    bool Validate(long number);

    bool Validate(long number, int digit);

    bool Validate(string value);

    bool Validate(string value, string digit);
}
