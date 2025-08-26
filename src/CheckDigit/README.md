# CheckDigit

CheckDigit is a .NET library for calculating and validating check digits using various algorithms.

## Features

- Supports multiple check digit algorithms
- Easy integration with .NET projects
- Simple API for validation and generation

## Installation

Install via NuGet:

```shell
dotnet add package CheckDigit
```

Or using the NuGet Package Manager:

```
PM> Install-Package CheckDigit
```

## Usage

```csharp
using CheckDigit;

// Example: Validate a code
bool isValid = CheckDigitValidator.Validate("123456789");

// Example: Generate a check digit
string codeWithCheckDigit = CheckDigitGenerator.Generate("123456789");
```

## Documentation and License

See the [GitHub repository](https://github.com/marcoshidalgonunes/CheckDigit) for full documentation, examples and licensing.
