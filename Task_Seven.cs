using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntersysRecruitment
{
    class Task_Seven
    {
        static void Main(string[] args)
        {
            //Declare
            List<uint> input;
            List<uint> result;

            //Get input
            Console.WriteLine("Provide input (terminated with empty/whitespace line):");
            input = GetInput();
            if (input == null) return;

            //Run task
            result = RunTask(input);

            //Give output
            Console.WriteLine("Result:");
            PrintResults(result);
        }

        //Assumed input gets terminated by empty line - not specified in description
        public static List<uint> GetInput()
        {
            List<uint> input = new List<uint>();
            try
            {
                string rawInput = Console.ReadLine();
                while (!string.IsNullOrWhiteSpace(rawInput))
                {
                    if (!string.IsNullOrWhiteSpace(rawInput))
                    {
                        input.Add(uint.Parse(rawInput.Trim()));
                    }
                    rawInput = Console.ReadLine();
                } 

                return input;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - invalid input.");
            }

            return null;
        }

        public static void PrintResults(List<uint> results)
        {
            if (results.Count() == 0)
            {
                Console.WriteLine("NA");
            }
            for (int i = 0; i<results.Count() ;i++)
            {
                Console.Write(results[i] + (i != results.Count()-1 ? ", " : "\n"));
            }
        }

        private static List<uint> RunTask(List<uint> values)
        {
            List<uint> decomposition = new List<uint>();

            decomposition = DecomposeValues(values).Distinct().OrderBy(x => x).ToList();

            return decomposition;
        }

        private static List<uint> DecomposeValues(List<uint> values)
        {
            List<uint> results = new List<uint>();

            foreach (uint val in values)
            {
                results.AddRange(Decompose(val));
            }
            return results;
        }

        private static List<uint> Decompose(uint value)
        {
            List<uint> results = new List<uint>();

            uint i = 1;
            while (i <= value)
            {
                if ((i & value) == i)
                {
                    results.Add(i);
                }
                i <<= 1;
            }

            return results;
        }
    }
}
