namespace CheckDigit;

/// <summary>
/// Base class for modulus calculation.
/// </summary>
public abstract class Compute : IModulusCompute
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Func<int, int> ComputeMultiplier { get; private set; }

    protected Func<long, int> ComputeDigit { get; private set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    protected Compute(Func<int, int> computeMultiplier, Func<long, int> computeDigit)
    {
        ComputeMultiplier = computeMultiplier;
        ComputeDigit = computeDigit;
    }

    /// <summary>
    /// Calculate modulus.
    /// </summary>
    /// <param name="number">Number to calculate modulus</param>
    /// <returns>Calculated modulus</returns>
    public abstract int Calculate(long number);

    /// <summary>
    /// Calculate modulus.
    /// </summary>
    /// <param name="number">Number to calculate modulus.</param>
    /// <returns>Calculated modulus</returns>
    public virtual string Calculate(string value)
    {
        return Calculate(value.ConvertToInt64()).ToString();
    }

    /// <summary>
    /// Validate modulus of a number.
    /// </summary>
    /// <param name="number">Number to validate</param>
    /// <param name="digit">Modulus to validate</param>
    /// <returns>True for valid number and modulus</returns>
    public virtual bool Validate(long number, int digit) => digit.Equals(Calculate(number));

    /// <summary>
    /// Validate modulus of a number.
    /// </summary>
    /// <param name="number">Number to validate</param>
    /// <returns>True for number with valid modulus</returns>
    public virtual bool Validate(long number) => Validate(number / 10, (int)(number % 10));

    /// <summary>
    /// Validate modulus of a number.
    /// </summary>
    /// <param name="number">Number to validate</param>
    /// <param name="digit">Modulus to validate</param>
    /// <returns>True for valid number and modulus</returns>
    public virtual bool Validate(string value, string digit)
    {
        return Validate(value.ConvertToInt64(), digit.ConvertToInt32());
    }

    /// <summary>
    /// Validate modulus of a number.
    /// </summary>
    /// <param name="number">Number to validate</param>
    /// <returns>True for number with valid modulus</returns>
    public virtual bool Validate(string value)
    {
        return Validate(value.ConvertToInt64());
    }
}
