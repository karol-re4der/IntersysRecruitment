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
            int result;

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
        private static int[] GetInput()
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

        private static void PrintResults(int result)
        {
            Console.WriteLine(result);
        }

        private static int RunTask(int[] arr)
        {
            int result = 0;
            List<byte> digitsList = new List<byte>();

            //Split into digits
            digitsList = arr.SelectMany(x => GetDigits(x)).ToList();

            //Count occurences
            result = (
                        from digit in digitsList
                        group digit by digit into digits
                        orderby digits.Count() descending, digits.Key descending
                        select digits.Key
                      ).First();

            return result;
        }

        private static byte[] GetDigits(int val)
        {
            //-'0' to shift value from char ASCII value to actual digit
            return Math.Abs(val).ToString().Select(digit => (byte)(digit - '0')).ToArray();
        }
    }
}
