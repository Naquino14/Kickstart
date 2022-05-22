using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleKickstart2021
{
    class RoundCProblemC
    {
        // win - w
        // tie - e
        // lose - 0?
        int w, e;

        char a; // choice
        char b; // friend choice

        int ri, pi, si; // amt of times you chose rock paper or scissors

        int x; // reward target

        static void Mainn(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            // test cases
            for (int titer = 1; titer <= t; titer++)
            {
                // 60 round probablility calculation
                for (int i = 1; i <= 60; i++)
                {

                }
            }

        }
    }
}
