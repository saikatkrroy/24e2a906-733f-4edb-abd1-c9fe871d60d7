using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternFinder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lisFinder = new LisFinder();
            Console.WriteLine("Enter a sequence of integers separated by spaces:");
            string input = Console.ReadLine() ?? string.Empty;
            string result = lisFinder.Find(input);
            Console.WriteLine("The earliest longest increasing contiguous subarray is:");
            Console.WriteLine(result);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
