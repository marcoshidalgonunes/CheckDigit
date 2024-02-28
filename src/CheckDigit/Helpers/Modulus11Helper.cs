namespace CheckDigit.Helpers;

internal static class Modulus11Helper
{
    internal static int CalculateDivider(int divider)
    {
        divider++;
        if (divider > 9)
        {
            divider = 2;
        }
        return divider;
    }

    internal static int CalculateDigit(long sum) => (int)sum * 10 % 11;
}
