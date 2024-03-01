namespace CheckDigit;

public interface IModulusCompute : ICompute
{
    /// <summary>
    /// Validate modulus of a number.
    /// </summary>
    /// <param name="number">Number to validate</param>
    /// <param name="digit">Modulus to validate</param>
    /// <returns>True for valid number and modulus</returns>
    bool Validate(long number, int digit);

    /// <summary>
    /// Validate modulus of a number.
    /// </summary>
    /// <param name="number">Number to validate</param>
    /// <param name="digit">Modulus to validate</param>
    /// <returns>True for valid number and modulus</returns>
    bool Validate(string value, string digit);
}
