using System;
using c = System.Console;
using i32 = System.Int32;
using i64 = System.Int64;

namespace GoogleKickstart2021
{
    public class Template
    {
        public static void Mainn()
        {
            var tc = i32.Parse(c.ReadLine());
            for (var i = 1; i <= tc; i++)
                c.WriteLine($"Case #:{i}: {Func()}");
        }

        private static object Func()
        {
            return new object();
        }
    }
}