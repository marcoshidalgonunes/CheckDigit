using CheckDigit.Helpers;

namespace CheckDigit;

/// <summary>
/// Modulus 11 calculation.
/// </summary>
public class Modulus11Compute : Compute
{
    public Modulus11Compute() 
        : this(Modulus11Helper.CalculateMultiplier, Modulus11Helper.CalculateDigit) { }

    protected Modulus11Compute(Func<int, int> computeMultiplier, Func<long, int> computeDigit)
        : base(computeMultiplier, computeDigit) { }

    /// <summary>
    /// Calculate modulus 11.
    /// </summary>
    /// <param name="number">Number to calculate modulus 11</param>
    /// <returns>Calculated modulus</returns>
    public override int Calculate(long number)
    {
        long sum = 0;
        int multiplier = 1;
        do
        {
            multiplier = ComputeMultiplier(multiplier);

            sum += number % 10 * multiplier;
            number /= 10;
        } while (number > 0);

        return ComputeDigit(sum);
    }
}
