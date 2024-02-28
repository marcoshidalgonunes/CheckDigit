namespace CheckDigit.Helpers;

internal static class Modulus11Helper
{
    internal static int CalculateMultiplier(int multiplier)
    {
        multiplier++;
        if (multiplier > 9)
        {
            multiplier = 2;
        }
        return multiplier;
    }

    internal static int CalculateDigit(long sum) => (int)sum * 10 % 11;
}
