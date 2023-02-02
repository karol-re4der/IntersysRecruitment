using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntersysRecruitment
{
    //Permutation
    class Task_Six
    {
        static void Main(string[] args)
        {
            //Declare
            int[][] input;
            bool result;

            //Get input
            Console.WriteLine("Provide input:");
            input = GetInput();
            if (input == null) return;

            //Run task
            result = RunTask(input[0], input[1]);

            //Give output
            Console.WriteLine("Result:");
            PrintResults(result);
        }

        public static int[][] GetInput()
        {
            int[][] input = new int[2][];
            try
            {
                input[0] = Console.ReadLine().Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();
                input[1] = Console.ReadLine().Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();

                if (input[0].Length!=11 || input[0].Length!= input[1].Length)
                {
                    Console.WriteLine("Error - Invalid number of values");
                    return null;
                }

                return input;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - invalid input.");
            }

            return null;
        }

        private static void PrintResults(bool result)
        {
            Console.WriteLine(result ? "YES" : "NO");
        }

        private static bool RunTask(int[] arrOne, int[] arrTwo)
        {
            foreach (int val in arrOne.Distinct())
            {
                if (arrOne.Where(i => i == val).Count() != arrTwo.Where(i => i == val).Count())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
