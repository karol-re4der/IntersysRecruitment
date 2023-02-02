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
            Tuple<int, int>[] input;
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
        public static Tuple<int, int>[] GetInput()
        {
            Tuple<int, int>[] inputs;
            int[] inputArray;
            try
            {
                int size = int.Parse(Console.ReadLine().Trim());

                inputs = new Tuple<int, int>[size];

                for (int i = 0; i < size; i++)
                {
                    inputArray = Console.ReadLine().Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();
                    if(inputArray.Length>2 || inputArray.Length == 0)
                    {
                        Console.WriteLine("Error - invalid input.");
                        return null;
                    }
                    else
                    {
                        inputs[i] = new Tuple<int, int>(inputArray.First(), inputArray.Last());
                    }
                }

                return inputs;
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
                Console.WriteLine(i);
            }
        }

        private static int[] RunTask(Tuple<int, int>[] intervals)
        {
            int[] results = new int[intervals.Length];

            for (int i = 0; i < intervals.Length; i++)
            {
                results[i] = GetPrimesInInterval(intervals[i].Item1, intervals[i].Item2);
            }

            return results;
        }

        private static int GetPrimesInInterval(int m, int n)
        {
            bool[] interval = new bool[n + 1];
            interval[0] = true; interval[1] = true; //0,1 not being prime - kept in the array just to make the code more transparent and reduce operations required for shifting table

            //Cross non-prime numbers
            for (int i = 2; i * i <= n; i++)
            {
                if (interval[i]) continue;

                for (int ii = i + i; ii <= n; ii += i)
                {
                    interval[ii] = true;
                }
            }

            return interval[m..].Count(x => !x);
        }
    }
}
