using System;
using System.Linq;

namespace GoogleKickstart2021
{
    class RoundFProblemA
    {
        static readonly int larg = 2147483647;
        public static void Mainn(string[] u)
        {
            var testCases = Int64.Parse(Console.ReadLine());
            for (int i = 1; i <= testCases; i++)
                Console.WriteLine($"Case #{i}: {FindSumOfDistances(Int32.Parse(Console.ReadLine()), Console.ReadLine())}");
        }

        static long FindSumOfDistances(int n, string s)
        {
            var c = 0;
            int[] lr = new int[n], rl = new int[n];
            bool lrf = false, rlf = false;
            for (var i = 0; i <= n - 1; i++)
            {
                if (s[i] == '0' && !lrf)
                    c = larg;
                else if (s[i] == '1')
                { c = 0; lrf = true; }
                else if (lrf)
                    c++;
                lr[i] = c;
            }
            for (var i = n - 1; i >= 0; i--)
            {
                if (s[i] == '0' && !rlf)
                    c = larg;
                else if (s[i] == '1')
                { c = 0; rlf = true; }
                else if (rlf)
                    c++;
                rl[i] = c;
            }
            var result = new int[n];
            for (var i = 0; i <= n - 1; i++)
                result[i] = Math.Min(lr[i], rl[i]);
            return result.AsParallel().Sum(x => (long)x);
        }
    }
}
