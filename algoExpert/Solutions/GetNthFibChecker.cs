using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algoExpert.Solutions
{
    class GetNthFibChecker
    {
        public static void check()
        {
            Console.WriteLine("GetNthFib1111:");
            Console.WriteLine(GetNthFib(5));
        }

        private static int GetNthFib(int n)
        {
            if (n < 2)
                return n;
            int prev = 1, prevprev = 0, runner = 2, curr = 0;
            while (runner <= n)
            {
                curr = prev + prevprev;
                prevprev = prev;
                prev = curr;
                runner++;
            }
            return curr;
        }
    }
}
