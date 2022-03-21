using System;
using c = System.Console;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace GoogleKickstart
{
    public class HashCodePracticeProblem
    {
        static readonly string inputPath = @"\HC22P i", outputPath = @"\HC22P o"; 
        public static void Mainn(string[] args)
        {
            // data is read thru a file and stdout must be written to a file

            var input = File.ReadAllLines(args[0].Contains(".txt") ? $@"{((args[0].Contains(@"C:\") || args[0].Contains(@"D:\")) ? args[0] : @$"{Directory.GetCurrentDirectory()}{inputPath}\{args[0]}")}" : throw new ArgumentException("Invalid Path."));

            int customers = int.Parse(input[0]);

            var ingredients = new Dictionary<string, int>();
            ingredients.Add("dummy", 0);
            bool firstLineFO = false;
            bool adding = false;
            foreach (var line in input)
            {
                if (!firstLineFO)
                {
                    firstLineFO = true;
                    continue;
                }
                adding = !adding;

                var contextLine = line.Split(' ');
                int ingredientCount = int.Parse(contextLine[0]);
                for (int i = 1; i <= ingredientCount; i++)
                {
                    // search thru the dictionary
                    // if the ingrienient exists, add 1 to the ingredient
                    // if the ingredient doesnt exist, add it to the dictionary
                    int ic = ingredients.Count();
                    for(int j = 0; j < ic; j++) // this isnt checking every line, so when it sees that it contains an ingredient it writes to the wrong spot
                        if (ingredients.ContainsKey(contextLine[i]))
                            if (adding)
                                ingredients[ingredients.ElementAt(j).Key]++;
                            else
                                ingredients[ingredients.ElementAt(j).Key]--;
                        else
                        {
                            ingredients.Add(contextLine[i], (adding) ? 1 : -1);
                            break;
                        }
                }
            }
            // look thru the dictionary and get any positive values
            string ret = "";
            int positiveKeyCount = 0;
            foreach (var key in ingredients.Keys)
            {
                //if (key == "Dummy") continue;

                if(ingredients[key] > 0)
                {
                    ret += key + " ";
                    positiveKeyCount++;
                }
            }

            ret = positiveKeyCount + " " + ret;

            c.WriteLine(ret);

        }
    }
}
//obamanation mm there is no meme take off your clothes