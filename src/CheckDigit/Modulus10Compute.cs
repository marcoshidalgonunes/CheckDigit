namespace CheckDigit;

/// <summary>
/// Modulus 10 calculation.
/// </summary>
public class Modulus10Compute : Compute
{
    public Modulus10Compute()
        : base(CalculateMultiplier, CalculateDigit) { }

    private static int CalculateDigit(long sum) => (int)(10 - sum % 10);

    private static int CalculateMultiplier(int multiplier) => multiplier % 2 == 0 ? 1 : 2;

    /// <summary>
    /// Calculate modulus 10.
    /// </summary>
    /// <param name="number">Number to calculate modulus 10</param>
    /// <returns>Calculated modulus</returns>
    public override int Calculate(long number)
    {
        long sum = 0;
        int multiplier = 1, multiply;
        do
        {
            multiplier = ComputeMultiplier(multiplier);

            multiply = (int)number % 10 * multiplier;

            sum += (multiply / 10) + (multiply % 10);
            number /= 10;
        } while (number > 0);

        return ComputeDigit(sum);
    }
}
