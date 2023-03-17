using System.Drawing;
using System;
using System.Globalization;

namespace Week_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] array; int numberOfComparisons;
            for (int size = 1000; size <= 20000; size += 1000)
            {
                array = GenerateRandomArray(size);
                numberOfComparisons = SortAnalysis(array);
                Console.WriteLine("{0}", numberOfComparisons);
            }
            array = GenerateRandomArray(25000);
            numberOfComparisons = SortAnalysis(array);
            Console.WriteLine("{0}", numberOfComparisons);
        }

        static double[] GenerateRandomArray(int size)
        {
            double[] array = new double[size];
            Random rng = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = rng.NextDouble();
            }
            return array;
        }

        static int SortAnalysis(double[] array)
        {
            int count = 0;
            for (int i = 1;
                i <= array.Length - 1;
                i++)
            {
                double v = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > v)
                {
                    count++;
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                if (j < 0) count++;
                array[j + 1] = v;
            }
            return count;
        }
    }
}