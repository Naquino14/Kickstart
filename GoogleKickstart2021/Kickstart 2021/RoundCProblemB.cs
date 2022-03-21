// hello again
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleKickstart2021
{
    class RoundCProblemB
    {
        static ulong t;
        static ulong k;
        static ulong p = 0;
        static void Maain(string[] args)
        {
            t = ulong.Parse(Console.ReadLine());
            for (ulong titer = 1; titer <= t; titer++)
            {
                k = ulong.Parse(Console.ReadLine());
                p = 0;
                for (ulong i = 1; i <= k; i++)
                {
                    ulong iter = 1;
                    bool flag = true;
                    ulong _sum = 0;
                    ulong prevSum = 0;
                    while (flag)
                    {
                        flag = false;
                        _sum = i + iter - 1 + prevSum;
                        if (_sum >= k)
                        {
                            if (_sum == k)
                                p++;
                        }
                        else
                            flag = true;
                        prevSum = _sum;
                        iter++;
                    }
                }
                Console.Write("Case #" + titer + ": " + p);
                Console.WriteLine("");
            }
        }
    }
}
