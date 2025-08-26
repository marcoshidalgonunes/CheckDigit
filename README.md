# CheckDigit

CheckDigit is a .NET 8 C# library for computing and verifying check digits using Modulus 10 (Luhn algorithm) and Modulus 11 algorithms. These algorithms are commonly used in validating identification numbers such as credit card numbers, bank account numbers, and various government-issued IDs.

## Features

- **Modulus 10 (Luhn) Algorithm**: Used for credit cards, IMEI numbers, and more.
- **Modulus 11 Algorithm**: Used for bank account numbers, ISBNs, and other identifiers.
- **Easy-to-use API**: Simple methods for calculating and verifying check digits.
- **Extensible**: Designed for easy integration into .NET applications.

## Installation

Add a reference to the `CheckDigit` project in your .NET 8 solution.

## Usage

### Modulus 10 (Luhn) Example

```csharp
using CheckDigit;
string number = "7992739871"; int checkDigit = Modulus10.CalculateCheckDigit(number); bool isValid = Modulus10.Verify(number + checkDigit);
Console.WriteLine($"Check digit: {checkDigit}"); // Output: Check digit: 3 Console.WriteLine($"Is valid: {isValid}");       // Output: Is valid: True
```

### Modulus 11 Example

```csharp
using CheckDigit;
string number = "123456789"; int checkDigit = Modulus11.CalculateCheckDigit(number); bool isValid = Modulus11.Verify(number + checkDigit);
Console.WriteLine($"Check digit: {checkDigit}"); Console.WriteLine($"Is valid: {isValid}");
```

## API Reference

### Modulus10

- `int CalculateCheckDigit(string number)`
  - Calculates the Modulus 10 check digit for the given number string.
- `bool Verify(string numberWithCheckDigit)`
  - Verifies if the provided number (including check digit) is valid.

### Modulus11

- `int CalculateCheckDigit(string number)`
  - Calculates the Modulus 11 check digit for the given number string.
- `bool Verify(string numberWithCheckDigit)`
  - Verifies if the provided number (including check digit) is valid.

## Testing

Usage examples and unit tests are available in the `CheckDigit.Tests` project within this repository.

## License

This library is licensed under the [GNU General Public License v3.0](./LICENSE).

## Contributing

Contributions are welcome! Please submit issues or pull requests via GitHub.

