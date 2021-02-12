using System;
using System.Collections;
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

            numbers.ForEach(number => Console.Write("[{0}], ", number));
        }
    }


    //public static class Program
    //{
    //    static Random _random = new Random();

    //    static void Main()
    //    {
    //        List<int> numbers = new List<int>(Enumerable.Range(1, 10000));
    //        List<int> shuffle = (List<int>)RandomizeList(numbers);
    //        foreach (int i in shuffle)
    //        {
    //            Console.WriteLine(i);
    //        }
    //    }

    //    /// <summary>
    //    /// 1. Put all ints from the list in a key value pair
    //    /// 2. Add a random int to each key value pair
    //    /// 3. Sort the new keyvaluepair list by the random number we created
    //    /// 4. Create a new list with the sorted ints
    //    /// 5. Return that new list with the random sorted numbers
    //    /// </summary>
    //    /// <param name="arr"></param>
    //    /// <returns></returns>
    //    public static IList RandomizeList(this IList numberList)
    //    {
    //        List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();

    //        foreach (int i in numberList)
    //        {
    //            list.Add(new KeyValuePair<int, int>(_random.Next(), i));
    //        }

    //        var sorted = from item in list 
    //                     orderby item.Key
    //                     select item;

    //        // this is needed because the foreach uses the index of the current list.
    //        List<int> result = new List<int>((IEnumerable<int>)numberList);

    //        int index = 0;
    //        foreach (KeyValuePair<int, int> pair in sorted)
    //        {
    //            result[index] = pair.Value;
    //            index++;
    //        }

    //        return result;
    //    }
}

