using System;
using c = System.Console;
using i32 = System.Int32;
using i64 = System.Int64;
using State = System.Object;

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
#pragma warning disable CS8632, IDE0059
        private static object Func()
        {
            bool honest = false;






            State? woopie = (honest ? "zad 😔" : "zAMN 🥵") ?? "what 🤨";


            return new object();
        }
    }
}