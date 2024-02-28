using CheckDigit.Helpers;

namespace CheckDigit;

public class Modulus11Compute : Compute
{
    public Modulus11Compute() 
    {
        ComputeDivider = Modulus11Helper.CalculateDivider;
    }

    public override int Calculate(long number)
    {
        long sum = 0;
        int divisor = 1;
        do
        {
            divisor = ComputeDivider(divisor);

            sum += number % 10 * divisor;
            number /= 10;
        } while (number > 0);

        return Modulus11Helper.CalculateDigit(sum);
    }

    public override bool Validate(long number) => Validate(number / 10, (int)(number % 10));

    public override bool Validate(long number, int digit) => digit.Equals(Calculate(number));
}
