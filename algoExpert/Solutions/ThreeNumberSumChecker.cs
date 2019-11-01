using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algoExpert.Solutions
{
    public class ThreeNumberSumChecker
    {
        public static void check()
        {
            int[] arg = new int[] { 12,3,1,2,-6,5,-8,6};
            var res = ThreeNumberSum(arg, 0);
            foreach (int[] arr in res)
                Console.WriteLine("{0}, {1}, {2}", arr[0], arr[1], arr[2]);
        }

        public static List<int[]> ThreeNumberSum(int[] array, int targetSum)
        {
            List<int[]> triplets = new List<int[]>();
            if (array.Length >= 3)
            {
                Array.Sort(array);
                int left, right;
                for (int i = 1; i < array.Length - 1; i++)
                {
                    left = 0;
                    right = array.Length-1;
                    while (left != i && right != i)
                    {
                        if (array[i] + array[left] + array[right] > targetSum)
                            right--;
                        else if (array[i] + array[left] + array[right] < targetSum)
                            left++;
                        else
                            triplets.Add(new int[] { array[left++], array[i], array[right--] });
                    }
                }
            }
            return triplets;
        }
    }
}
