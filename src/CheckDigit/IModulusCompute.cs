namespace CheckDigit;

public interface IModulusCompute : ICompute
{
    bool Validate(long number, int digit);

    bool Validate(string value, string digit);
}
