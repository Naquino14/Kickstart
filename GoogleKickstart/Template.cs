using System;
using c = System.Console;

namespace GoogleKickstart2021
{
    public class Template
    {
        public static void Mainn()
        {
            var tc = int.Parse(c.ReadLine());
            for (var i = 1; i <= tc; i++)
                c.WriteLine($"Case #{i}: {Func()}");
        }
#pragma warning disable CS8632, IDE0059
        private static object Func()
        {
            return new object();
        }
    }
}
