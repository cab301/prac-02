namespace SortedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList<int> sortedInts = new SortedList<int>(5);
            sortedInts.Add(2);
            sortedInts.Add(1);
            Console.WriteLine(sortedInts);
        }
    }
}