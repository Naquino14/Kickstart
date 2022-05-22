using System;
using System.Collections;

namespace GoogleKickstart2021
{
    class RoundHProblemB
    {
        public static void Mainn(string[] u)
        {
            var testCases = Int32.Parse(Console.ReadLine());
            for (var i = 1; i <= testCases; i++)
                Console.WriteLine($"Case #{i}: {MinStrokes(Int64.Parse(Console.ReadLine()), Console.ReadLine())}");
        }

        static long MinStrokes(long n, string s)
        {
            var x = 0L;
            bool[] rMask = new bool[n], yMask = new bool[n], bMask = new bool[n];
            for (var i = 0; i <= n - 1; i++)
            {
                char c = s[i];
                if (c == 'R' || c == 'O' || c == 'P' || c == 'A')
                    rMask[i] = true;
                else
                    rMask[i] = false;
                if (c == 'Y' || c == 'O' || c == 'G' | c == 'A')
                    yMask[i] = true;
                else
                    yMask[i] = false;
                if (c == 'B' || c == 'G' || c == 'P' || c == 'A')
                    bMask[i] = true;
                else
                    bMask[i] = false;
            }
            bool rf = false, yf = false, bf = false;
            for (var i = 0; i <= n - 1; i++)
            {
                if (rMask[i] && !rf)
                { rf = true; x++; }
                else if (!rMask[i])
                    rf = false;
                if (yMask[i] && !yf)
                { yf = true; x++; }
                else if (!yMask[i])
                    yf = false;
                if (bMask[i] && !bf)
                { bf = true;  x++; }
                else if (!bMask[i])
                    bf = false;
            }
            return x;
        }
    }
}

