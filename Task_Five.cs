using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntersysRecruitment
{
    //Palindrome
    class Task_Five
    {
        //Assumption: not a palinderom if empty string, not a palindrome if letter case does not match (eg. "Abuttuba")

        static void Main(string[] args)
        {
            //Declare
            string input;
            bool result;

            //Get input
            Console.WriteLine("Provide input:");
            input = GetInput();
            if (input == null) return;

            //Run task
            result = RunTask(input);

            //Give output
            Console.WriteLine("Result:");
            PrintResults(result);
        }

        public static string GetInput()
        {
            try
            {
                string input = Console.ReadLine();

                return input;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - invalid input.");
            }

            return null;
        }

        public static void PrintResults(bool result)
        {
            Console.WriteLine(result ? "YES" : "NO");
        }

        private static bool RunTask(string inputString)
        {
            //Normalize string to remove all non-letter characters
            var normalizedString = inputString.Where(c => char.IsLetter(c)).ToArray();

            //Compare characters
            for (int i = 0; i < normalizedString.Length / 2; i++)
            {
                if (normalizedString[i] != normalizedString[normalizedString.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
