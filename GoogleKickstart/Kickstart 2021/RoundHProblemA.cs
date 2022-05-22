using System;
using System.Linq;
using System.Text;

namespace GoogleKickstart2021
{
    class RoundHProblemA
    {
        public static void Mainn(string[] u)
        {
            var testCases = Int32.Parse(Console.ReadLine());
            for (var i = 1; i <= testCases; i++)
                Console.WriteLine($"Case #{i}: {FindOps(Console.ReadLine(), Console.ReadLine())}");
        }

        static long FindOps(string s, string f)
        {
            var x = 0L;
            byte[] ss = Encoding.ASCII.GetBytes(s),
                ff = Encoding.ASCII.GetBytes(f);
            foreach (var sCheck in ss)
            {
                var diffs = new long[ff.Length * 2];
                var diffsInd = 0L;
                foreach (var fCheck in ff)
                {
                    diffs[diffsInd] = (long)Math.Abs(fCheck - sCheck);
                    diffs[diffsInd + 1] = (long)Math.Abs(26 - diffs[diffsInd]);
                    diffsInd += 2;
                }
                x += diffs.Min();
            }
            return x;
        }
    }
}
