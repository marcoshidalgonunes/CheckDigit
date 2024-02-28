﻿namespace CheckDigit;

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

    public abstract int Calculate(long number);

    public virtual string Calculate(string value)
    {
        return Calculate(value.ConvertToInt64()).ToString();
    }

    public abstract bool Validate(long number);

    public abstract bool Validate(long number, int digit);                                                 

    public virtual bool Validate(string value)
    {
        return Validate(value.ConvertToInt64());
    }

    public virtual bool Validate(string value, string digit)
    {
        return Validate(value.ConvertToInt64(), digit.ConvertToInt32());
    }
}
