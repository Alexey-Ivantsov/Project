using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();
            Case @case = new Case();

            counter.Count += @case.FirestCase;
            counter.Count += @case.SecondCase;
            counter.CaseCounter();
            Console.ReadKey();
        }
    }
}
