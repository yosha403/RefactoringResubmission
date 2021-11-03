using System;
using System.Linq;

namespace PigLatin
{
    class PigLatinTranslator
    {
        //static void Main(string[] args)
        //{
        //    string userInput = GetInput("Please input a word or sentence to translate to pig Latin");

        //    string translation = ToPigLatin(userInput);
        //    Console.WriteLine(translation);
        //}

        public string GetInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine().ToLower().Trim();
            return input;
        }

        public bool IsVowel(char c)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            //return c.ToString() == vowels.ToString();
            return vowels.Contains(c);
        }

        public string ToPigLatin(string word)
        {
            word = word.ToLower().Trim();

            //Split with no input it splits along white space
            string[] sentence = word.Split();
            string output = "";
            foreach (string wo in sentence)
            {
                char[] specialChars = { '@', '.', '-', '$', '^', '&' };
                bool hasSpecialChars = false;
                foreach (char c in specialChars)
                {
                    if (wo.Contains(c))
                    {
                        Console.WriteLine("That word has special characters, we will return it as is");
                        output += wo + " ";
                        hasSpecialChars = true;
                        break;
                    }

                    //foreach (char w in word)
                    //{
                    //    if (w == c)
                    //    {
                    //        return word;
                    //    }
                    //}

                }

                if (hasSpecialChars)
                {
                    continue;
                }

                bool noVowels = true;
                foreach (char letter in wo)
                {
                    if (IsVowel(letter))
                    {
                        noVowels = false;
                        break;
                    }
                }

                if (noVowels)
                {
                    output += wo + " ";
                    continue;
                }

                char firstLetter = wo[0];

                if (IsVowel(firstLetter) == true)
                {
                    output += wo + "way ";
                }
                else
                {
                    //-1 is a universal sign for nothing was found or there was 
                    int vowelIndex = -1;
                    //Handle going through all the consonants
                    for (int i = 0; i <= wo.Length; i++)
                    {
                        if (IsVowel(wo[i]) == true)
                        {
                            vowelIndex = i;
                            break;
                        }
                    }

                    string sub = wo.Substring(vowelIndex);
                    string postFix = wo.Substring(0, vowelIndex);

                    output += sub + postFix + "ay ";
                }
            }
            return output.Trim();
        }
    }
}
