namespace CheckDigit.Helpers;

internal static class Modulus11Helper
{
    internal static int CalculateMultiplier(int multiplier) => ++multiplier > 9 ? 2 : multiplier;

    internal static int CalculateDigit(long sum) => (int)(sum * 10 % 11);
}
