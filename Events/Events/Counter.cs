using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Counter
    {
        public delegate void Method();

        public event Method Count;

        public void CaseCounter()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 71 && Count != null)
                {
                    Count();

                }
                Console.WriteLine($"{i}");
            }
        }
    }
}
