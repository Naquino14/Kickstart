using System;
using c = System.Console;
using i32 = System.Int32;
using i64 = System.Int64;
using State = System.Object;

namespace GoogleKickstart2022
{
    public class RoundCProblemB
    {
        public static void Main()
        {
            var tc = int.Parse(c.ReadLine());
            for (var i = 1; i <= tc; i++)
            { var o = Func(c.ReadLine());  c.WriteLine($"Case #{i}: {(o.p ? $"POSSIBLE\n{o.l}\n{o.ss}" : "IMPOSSIBLE")}"); }
        }
        private static (bool p, int? l, string? ss) Func(string s)
        {
            (bool p, int? l, string? ss) o = new();
            var seq = s.Split(' ');
            int ctxssl = 1;
            bool r = seq.Length % ctxssl == 0;
            try
            {
                for (int i = 0; i < seq.Length; i++)
                {
                    var ctxset = new int[ctxssl];
                    // im too tired for this sorry

                    ctxssl++;
                }
            }
            catch (IndexOutOfRangeException) { }

            return o;
        }

        private static int gcf(int a, int b)
        {
            while (b != 0)
            {
                var t = b;
                b = a % b;
                a = t;
            }
            return a;
        }
    }
}