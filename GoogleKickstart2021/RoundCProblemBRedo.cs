using System;
using System.Collections.Generic;

namespace GoogleKickstart2021
{
    class RoundCProblemBRedo
    {
        public static void Main(string[] u)
        {
            var testCases = Int32.Parse(Console.ReadLine());
            for (int i = 1; i <= testCases; i++)
                Console.WriteLine($"Case #{i}: {FindOddDivisors(Int64.Parse(Console.ReadLine()))}");
        }

        static long FindOddDivisors(long k)
        {
            if (k <= 0)
                return 0L;

            List <long> divisors = new List<long>();
            List<long> result = new List<long>();
            bool even = k % 2 == 0;

            for (long i = 1; i <= Math.Sqrt(k); i++)
            {
                long r = k / i;
                if (k % i == 0)
                {
                    divisors.Add(i);
                    if (i != r)
                        divisors.Add(r);
                }
            }
            foreach (long oe in divisors)
                if (even && oe % 2 == 0)
                    result.Add(oe);
                else if (!even && oe % 2 == 1)
                    result.Add(oe);
            return result.Count;
        }

    }
}
