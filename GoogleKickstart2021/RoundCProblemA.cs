using System;
using c = System.Console;
using i32 = System.Int32;
//using i64 = System.Int64;

namespace GoogleKickstart2021
{
    public class RoundCProblemA
    {
        public static void Main()
        {
            var tc = i32.Parse(c.ReadLine());
            for (var i = 1; i <= tc; i++)
                c.WriteLine($"Case #:{i}: {Func(c.ReadLine(), c.ReadLine())}");
        }

        private static long Func(string nk, string s)
        {
            var x = 0L;
            int n = i32.Parse(nk.Split(' ')[0]),
                k = i32.Parse(nk.Split(' ')[1]),
                maxTarget = 97 + k,
                maxIters = (int)Math.Ceiling((float)n / 2);

            var even = n % 2 == 0;

            switch (even)
            {
                case true: // even 
                    ;
                    break;
                case false: // odd
                    ;
                    break;
            }

            return x % 1000000007;
        }
    }
}