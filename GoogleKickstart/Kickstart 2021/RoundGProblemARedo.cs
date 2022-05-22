// bruh this is so easy and i fucked it up
using System;

namespace GoogleKickstart2021
{
    class RoundGProblemARedo
    {
        static int testCases, numberOfAnimals, dogFoodPortions, addedCatFood;
        static long catFoodPortions;
        static void Mainn(string[] args)
        {
            testCases = Int32.Parse(Console.ReadLine());
            for (int i = 1; i <= testCases; i++)
                Console.WriteLine($"Case #{i}: {(DogsEaten(ReadInputs()) ? "YES" : "NO")}");
        }

        static bool DogsEaten(string sequence)
        {
            for (int i = 0; i < numberOfAnimals; i++)
                if (sequence[i] == 'D')
                {
                    if (dogFoodPortions <= 0 || catFoodPortions < 0)
                        return false;
                    dogFoodPortions--;
                    catFoodPortions += addedCatFood;
                }
                else
                    catFoodPortions--;
            return true;
        }

        static string ReadInputs()
        {
            string[] readNums = Console.ReadLine().Split(' ');
            int i_ = 0;
            foreach (string val in readNums)
            {
                if (i_ == 0)
                    numberOfAnimals = int.Parse(val);
                if (i_ == 1)
                    dogFoodPortions = int.Parse(val);
                if (i_ == 2)
                    catFoodPortions = int.Parse(val);
                if (i_ == 3)
                    addedCatFood = int.Parse(val);
                i_++;
            }
            return Console.ReadLine();
        }
    }
}
