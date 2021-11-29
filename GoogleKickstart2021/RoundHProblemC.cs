using System;

namespace GoogleKickstart2021
{
    class RoundHProblemC
    {
        public static void Mainn(string[] u)
        {
            var testCases = Int32.Parse(Console.ReadLine());
            for (var i = 1; i <= testCases; i++)
                Console.WriteLine($"Case #{i}: {SillySubstitute(Int32.Parse(Console.ReadLine()), Console.ReadLine())}");

        }

        static string SillySubstitute(int n, string s)
        {
            // i immediately kno that this is going to cause serious complexity problems. so heres the lo bar
            // TLE here i come lmao
            while (true)
            {
                var cf = false;
                for (var i = 0; i <= 10; i++)
                    if (s.Contains($"{i % 10}{(i + 1) % 10}"))
                        cf = true;
                if (!cf)
                    return s;
                else
                    for (var i = 0; i <= 10; i++)
                    {
                        var c = $"{i % 10}{(i + 1) % 10}";
                        if (s.Contains(c))
                            s = s.Replace(c, $"{(i + 2) % 10}");
                    }
            }
        }
    }
}
