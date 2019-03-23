using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static void OutputResult(int? result, int expectedResult) =>
    Console.WriteLine($"Result:{result,4}   Expected:{expectedResult,4}");
        public static void Main()
        {
            /*OutputResult(Multiply("2,2"), 4);
            OutputResult(Multiply("2,2,2,2,2,2,2,2"), 256);
            OutputResult(Multiply("2,3,4,5"), 120);
            OutputResult(Multiply("10"), 10);
            OutputResult(Multiply(""), 1);*/
            TotalPoints();
            Console.ReadKey();
        }
        public static void TotalPoints()
        {
            string s = "Hello Wortld!";
            string sd = "(s.ToCharArray().Reverse().ToArray())";

            Console.WriteLine(sd);
        }
        public static int? Multiply(string arguments)
        {





            if (String.IsNullOrEmpty(arguments))
            {
                return 1;
            }
            string[] numbers = arguments.Split(',');



            int result = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                // int a= Convert.ToInt32(numbers[0]);

                result = Convert.ToInt32(numbers[i]) * result;

                // += multipluay;
            }
            return result;
        }

    }
}
