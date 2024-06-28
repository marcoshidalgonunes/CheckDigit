namespace CheckDigit.Helpers;

public static class Modulus11Helper
{
    public static int CalculateMultiplier(int multiplier) => ++multiplier > 9 ? 2 : multiplier;

    public static int CalculateDigit(long sum) => (int)(sum * 10 % 11);
}
