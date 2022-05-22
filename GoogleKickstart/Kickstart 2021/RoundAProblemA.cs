using System;

namespace GoogleKickstart2021
{
    class RoundAProblemA
    {
        public static void Mainn(string[] u)
        {
            var testCases = Int32.Parse(Console.ReadLine());
            for (var i = 1; i <= testCases; i++)
            {
                var ins = Console.ReadLine().Split(' ');
                int n = Int32.Parse(ins[0]), k = Int32.Parse(ins[1]);
                Console.WriteLine($"Case #{i}: {K(Console.ReadLine(), n, k)}");
            }
        }

        static int K(string s, int n, int k)
        {
            var x = 0;
            for (var i = 0; i < n / 2; i++)
                if (s[i] != s[n - i - 1])
                    x++;
            if (x == k)
                return 0;
            else if (x > k)
                return x - k;
            else
                return k - x;
        }
    }
}
