namespace CheckDigit;

/// <summary>
/// Interface for modulus calculation.
/// </summary>
public interface ICompute
{
    /// <summary>
    /// Calculate modulus.
    /// </summary>
    /// <param name="number">Number to calculate modulus</param>
    /// <returns>Calculated modulus</returns>
    int Calculate(long number);

    /// <summary>
    /// Calculate modulus.
    /// </summary>
    /// <param name="number">Number to calculate 
    string Calculate(string value);

    /// <summary>
    /// Validate modulus of a number.
    /// </summary>
    /// <param name="number">Number to validate</param>
    /// <returns>True for number with valid modulus</returns>
    bool Validate(long number);

    /// <summary>
    /// Validate modulus of a number.
    /// </summary>
    /// <param name="number">Number to validate</param>
    /// <returns>True for number with valid modulus</returns>
    bool Validate(string value);
}
