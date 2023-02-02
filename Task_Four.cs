using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntersysRecruitment
{
    class Task_Four
    {
        static void Main(string[] args)
        {
            //Declare
            int[] input;
            int[] result;

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

        //Assumed the input values are integers - not specified in task description
        public static int[] GetInput()
        {
            try
            {
                int size = int.Parse(Console.ReadLine().Trim());
                int[] values = Console.ReadLine().Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();

                if (size != values.Length)
                {
                    Console.WriteLine("Error - Array size does not match number of values.");
                    return null;
                }

                return values;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - invalid input.");
            }

            return null;
        }

        public static void PrintResults(int[] results)
        {
            foreach (int i in results)
            {
                Console.Write(i + " ");
            }
        }

        private static int[] RunTask(int[] inputArray)
        {
            //In case Array.Reverse() is not valid solution:
            //int[] result = new int[inputArray.Length];
            //for(int i = 0; i<inputArray.Length; i++)
            //{
            //    result[inputArray.Length-1-i] = inputArray[i];
            //}

            return inputArray?.Length>0?inputArray.Reverse().ToArray():inputArray;
        }
    }
}
