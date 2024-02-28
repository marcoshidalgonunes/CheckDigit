using CheckDigit.Helpers;

namespace CheckDigit;

public class Modulus11Compute : Compute
{
    public Modulus11Compute() 
        : this(Modulus11Helper.CalculateMultiplier, Modulus11Helper.CalculateDigit) { }

    protected Modulus11Compute(Func<int, int> computeMultiplier, Func<long, int> computeDigit)
        : base(computeMultiplier, computeDigit) { }

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

    public override bool Validate(long number) => Validate(number / 10, (int)(number % 10));

    public override bool Validate(long number, int digit) => digit.Equals(Calculate(number));
}
