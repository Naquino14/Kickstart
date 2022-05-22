using System;

namespace Kickstart_Round_G
{
    class ProblemA
    {
        static int testCases, numberOfAnimals, dogFoodPortions, addedCatFood;
        static long catFoodPortions;
        static char[] arrangement;
        static char cat = 'C', dog = 'D';
        static void Mainn(string[] args)
        {
            testCases = Int32.Parse(Console.ReadLine());
            for (int i = 1; i <= testCases; i++)
            {
                ReadInputs();

                // my no conditions:
                // the food runs out for EITHER animal and at least 1 dog remains in the sequence

                // loop rules:
                // when a dog eats, add M cat food, subtract 1 dog food
                // when a cat eats, sutract 1 cat food
                bool canAllDogsEat = true;
                int animalIter = 1;
                foreach (char animal in arrangement)
                {
                    // check conditions first
                    if ((catFoodPortions == 0 && animal == cat) || (dogFoodPortions == 0 && animal == dog)) // can either animal eat
                    {
                        if (animalIter == numberOfAnimals && animal == dog)
                        {
                            canAllDogsEat = false;
                            break;
                        }
                        else if (DoDogsRemain(animalIter))
                        {
                            canAllDogsEat = false;
                            break;
                        }
                    }


                    if (animal == cat)
                        catFoodPortions--;
                    if (animal == dog)
                    { dogFoodPortions--; catFoodPortions += addedCatFood; }

                    animalIter++;
                }
                if (!canAllDogsEat)
                    Console.WriteLine($"Case #{i}: NO");
                else
                    Console.WriteLine($"Case #{i}: YES");

            }
        }

        static void ReadInputs()
        {
            string[] readNums = Console.ReadLine().Split(' ');
            int i_ = 0;
            foreach (string val in readNums)
            {
                if (i_ == 0)
                    numberOfAnimals = Int32.Parse(val);
                if (i_ == 1)
                    dogFoodPortions = Int32.Parse(val);
                if (i_ == 2)
                    catFoodPortions = Int32.Parse(val);
                if (i_ == 3)
                    addedCatFood = Int32.Parse(val);
                i_++;
            }
            arrangement = Console.ReadLine().ToCharArray();
        }

        static bool DoDogsRemain(int animalIter)
        {
            char[] check = new char[numberOfAnimals - animalIter];
            Array.Copy(arrangement, animalIter, check, 0, numberOfAnimals - animalIter);
            foreach (char remainingAnimal in check)
                if (remainingAnimal == dog)
                    return true;

            return false;
        }
    }
}
