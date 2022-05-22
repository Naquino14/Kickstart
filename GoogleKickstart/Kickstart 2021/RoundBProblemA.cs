// hello google!
using System;
using System.IO;

namespace GoogleKickstart2021
{
    class RoundBProblemA
    {
        static int t, n;
        static string s;
        /// where t is test cases
        /// n is string length
        /// s is string with n as the length
        /// 

        static int prev = 1;
        static char[] ab = new char[26];

        static bool createResFO = false;

        static void Mainn(string[] args)
        {
            for (int i = 0; i < ab.Length; i++)
                switch (i)
                {
                    case 0:
                        ab[i] = 'A';
                        break;
                    case 1:
                        ab[i] = 'B';
                        break;
                    case 2:
                        ab[i] = 'C';
                        break;
                    case 3:
                        ab[i] = 'D';
                        break;
                    case 4:
                        ab[i] = 'E';
                        break;
                    case 5:
                        ab[i] = 'F';
                        break;
                    case 6:
                        ab[i] = 'G';
                        break;
                    case 7:
                        ab[i] = 'H';
                        break;
                    case 8:
                        ab[i] = 'I';
                        break;
                    case 9:
                        ab[i] = 'J';
                        break;
                    case 10:
                        ab[i] = 'K';
                        break;
                    case 11:
                        ab[i] = 'L';
                        break;
                    case 12:
                        ab[i] = 'M';
                        break;
                    case 13:
                        ab[i] = 'N';
                        break;
                    case 14:
                        ab[i] = 'O';
                        break;
                    case 15:
                        ab[i] = 'P';
                        break;
                    case 16:
                        ab[i] = 'Q';
                        break;
                    case 17:
                        ab[i] = 'R';
                        break;
                    case 18:
                        ab[i] = 'S';
                        break;
                    case 19:
                        ab[i] = 'T';
                        break;
                    case 20:
                        ab[i] = 'U';
                        break;
                    case 21:
                        ab[i] = 'V';
                        break;
                    case 22:
                        ab[i] = 'W';
                        break;
                    case 23:
                        ab[i] = 'X';
                        break;
                    case 24:
                        ab[i] = 'Y';
                        break;
                    case 25:
                        ab[i] = 'Z';
                        break;
                }
            t = Int32.Parse(Console.ReadLine());
            int[] result;
            for (int i = 1; i <= t; i++)
            {
                int iter = 0;
                n = Int32.Parse(Console.ReadLine());
                s = Console.ReadLine();
                result = new int[n];
                foreach (char c in s.ToCharArray())
                {
                    int cur = 0;
                    foreach (char abind in ab)
                    {
                        if (c == abind)
                            break;
                        cur++;
                    }
                    cur++;
                    if (result[0] == 0)
                        result[0] = 1;
                    else
                    {
                        if (iter == 0)
                            result[0] = 1;
                        else if (cur > prev)
                            result[iter] = (result[iter - 1] + 1);
                        else
                            result[iter] = 1;
                    }
                    iter++;
                    prev = cur;
                }
                prev = 1;
                Console.Write("Case #" + i + ": ");
                for (int ri = 0; ri < result.Length; ri++)
                    Console.Write(result[ri] + " ");
                Console.WriteLine("");
            }
        }
    }
}
