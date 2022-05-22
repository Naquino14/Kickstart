using System;
using c = System.Console;
using i32 = System.Int32;
using i64 = System.Int64;

namespace GoogleKickstart2022
{
    public class RoundCProblemA
    {
        private static readonly char[] spec = { '#', '@', '*', '&' };
        public static void Mainn()
        {
            var tc = int.Parse(c.ReadLine());
            for (var i = 1; i <= tc; i++)
                c.WriteLine($"Case #{i}: {GetNewPassword(int.Parse(c.ReadLine()), c.ReadLine())}");
        }

        private static string GetNewPassword(int n, string s)
        {
            var o = s;
            bool hasLower = false, hasUpper = false, hasDigit = false, hasSpec = false;
            for (int i = 0; i < s.Length; i++)
            {
                hasLower |= s[i] >= 0x61 && s[i] <= 0x7A;
                hasUpper |= s[i] >= 0x41 && s[i] <= 0x5A;
                hasDigit |= s[i] >= 0x30 && s[i] <= 0x39;
                hasSpec |= s[i] == 0x23 || s[i] == 0x40 || s[i] == 0x2A || s[i] == 0x26;
            }
            var rng = new Random();

            if (!hasLower)
                o += (char)rng.Next(0x61, 0x7A);
            if (!hasUpper)
                o += (char)rng.Next(0x41, 0x5A);
            if (!hasDigit)
                o += rng.Next(0, 9);
            if (!hasSpec)
                o += spec[rng.Next(0, 3)];

            while (o.Length < 7)
                o += (char)rng.Next(0x61, 0x7A);
            return o;
        }
    }
}