using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algoExpert.Solutions
{
    class TwoNumberSumChecker
    {
        public static void check()
        {
            Console.WriteLine("TwoNumberSum:");
            int[] arg = new int[] { 3,5,-4,8,11,1,-1,6};
            int[] arg2 = new int[] { -21,301,12,4,65,56,210,356,9,-47};
            int[] res = TwoNumberSumBetter(arg2, 163);
            foreach (int num in res)
                Console.WriteLine(num);
        }

        //nlogn solution
        private static int[] TwoNumberSum(int[] array, int targetSum)
        {
            Array.Sort(array);
            int left = 0, right = array.Length - 1;
            while (left < right)
            {
                if (array[left] + array[right] > targetSum)
                    right--;
                else if (array[left] + array[right] < targetSum)
                    left++;
                else
                    return new int[] { array[left], array[right] };
            }
            return new int[] { };
        }

        //n solution
        public static int[] TwoNumberSumBetter(int[] array, int targetSum)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (int num in array)
                if (!set.Contains(num))
                    set.Add(num);
                
            foreach (int num in set)
            {
                if (set.Contains(targetSum - num) && (targetSum - num) != num)
                {
                    int[] res= new int[] { num, targetSum - num };
                    Array.Sort(res);
                    return res;
                }
            }
            return new int[] { };
        }


    }
}
