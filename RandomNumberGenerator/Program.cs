using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RandomNumberGenerator
{
    public static class Program
    {
        private static Random random = new Random();
        private static string response;

        /// <summary>
        /// Main entry point
        /// 1. Create a list of numbers
        /// 2. Shuffle those numbers using the Shuffle function
        /// 3. Write each number to the console
        /// 4. Ask user if they would like to run the program again
        /// 5. If yes, run MakeList again, else, end the program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("This program randomly shuffles a list of numbers from 1 to 10000.");

            do
            {
                MakeRandomList();

                Console.Write("Would you like to run the program again? (Y or press any key to end) : ");

                response = Console.ReadLine();

            } while (response.ToUpper() == "Y");
        }

        /// <summary>
        /// Shuffles a list of generic objects randomly using the Fisher-Yates shuffle.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int size = list.Count;
            while (size > 1)
            {
                size--;
                int index = random.Next(size + 1);
                T value = list[index];
                list[index] = list[size];
                list[size] = value;
            }
        }

        public static void MakeRandomList()
        {
            List<int> numbers = new List<int>(Enumerable.Range(1, 10000));
            List<int> originalNumbers = new List<int>(numbers);

            numbers.Shuffle();

            // Asserts uniqueness of each number.
            Debug.Assert(numbers.Distinct().Count() == 10000);
            // Asserts a random order for the numbers list.
            Debug.Assert(TestOrder(originalNumbers, numbers));

            numbers.ForEach(number => Console.Write("[{0}], ", number));
        }

        /// <summary>
        /// Asserts that the original list is in a different order.
        /// Note: Could be flawed as it is possible a random sort returns the same input. However with 10,000 numbers, that is rare.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="original"></param>
        /// <param name="randomized"></param>
        /// <returns></returns>
        public static bool TestOrder<T>(IList<T> original, IList<T> randomized)
        {
            return !original.SequenceEqual(randomized);
        }
    }
}
