namespace ParallelLinq.Calculations;

public static class HeavyCalculation
{
    public static long Calculate(int number)
    {
        long result = 0;

        for (int i = 1; i <= 10_000; i++)
        {
            result += ((long)number * i) % 1_234_567;
        }

        return result;
    }
}
