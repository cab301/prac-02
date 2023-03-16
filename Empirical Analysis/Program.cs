namespace Empirical_Analysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int inputSize = 10;
            for (int inputSize = 1000; 
                inputSize <= 20000; 
                inputSize = inputSize + 1000)
            {
                double[] firstRandomArray =
                    GenerateRandomNumbers(inputSize);
                double comparisonCount = 
                    SortAnalysis(firstRandomArray);
                Console.WriteLine("{0} {1}",
                    inputSize, comparisonCount);
            }
        }

        /// <summary>
        /// Generate an array of random numbers from 0 to 1,
        /// at a given size
        /// </summary>
        /// <param name="size">The size of the array</param>
        /// <returns>The generated array</returns>
        static double[] GenerateRandomNumbers(int size)
        {
            double[] result = new double[size];
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                result[i] = rand.NextDouble();
            }
            return result;
        }

        // Implement the algorithm in Q4
        /// <summary>
        /// Find the number of key comparisons in a sorting algorithm,
        /// on an array of orderable elements
        /// </summary>
        /// <param name="A">The array of orderable elements</param>
        /// <returns>The number of key comparisons made</returns>
        static int SortAnalysis(double[] A)
        {
            int n = A.Length;
            int count = 0;
            for (int i = 1; i <= n - 1; i++)
            {
                double v = A[i];
                int j = i - 1;
                while (j >= 0 && A[j] > v)
                {
                    count = count + 1;
                    A[j + 1] = A[j];
                    j = j - 1;
                }
                // Account for failed case
                if (j < 0) count = count + 1;
                A[j + 1] = v;
            }
            return count;
        }
    }
}