namespace CheckDigit.Extensions;

internal static class ComputeExtensions
{
    internal static int ConvertToInt32(this string valor)
    {
        if (!int.TryParse(valor, out int number))
        {
            throw new FormatException(CheckDigit.InvalidNumber);
        }

        return number;
    }

    internal static long ConvertToInt64(this string valor)
    {
        if (!long.TryParse(valor, out long number))
        {
            throw new FormatException(CheckDigit.InvalidNumber);
        }

        return number;
    }
}
