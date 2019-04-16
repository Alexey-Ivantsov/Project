using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Account<int> account1 = new Account<int>();
            Account<string> account2 = new Account<string>();
            account1.Id = 3;
            Predicate<int> op;
            op = Add;
            Console.WriteLine(op(20));
            Console.ReadKey();
        }
        static bool Add(int x1)
        {
            return x1 > 0;
        }
    }

    class Account<T>
    {
        public T Id;
    }
}
