using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algoExpert.Solutions
{
    class LargestRangeChecker
    {
        public static void check()
        {
            Console.WriteLine("LargestRange:");
            int[] arr = new int[] {-1,1,2,2,3,4,5,6,6,7,8,10,11,12,12,12,13,14,15,16,17,18,19 };
            int[] res = LargestRangeBetter(arr);
            foreach(int num in res)
                Console.WriteLine(num);
        }
        
        //nlogn soloution
        private static int[] LargestRange(int[] array)
        {
            Array.Sort(array);
            if (array.Length == 1)
                return new int[] { array[0], array[0] };

            int temp=0, left=0, right=0, max=0,buff=0;
            for(int i = 1; i < array.Length; i++)
            {
                if (array[i] == array[i - 1] + 1)
                {
                    temp++;
                    if (temp > max)
                    {
                        max = temp;
                        left = i - max-buff;
                        right = i;
                    }
                }
                else if (array[i] == array[i - 1])
                    buff++;
                else
                {
                    temp = 0;
                    buff = 0;
                }
            }
            return new int[] { array[left], array[right] };
        }

        //N solution
        private static int[] LargestRangeBetter(int[] array)
        {
            if (array.Length == 0)
                return null;

            Dictionary<int, bool> visited = new Dictionary<int, bool>();
            foreach(int num in array)
            {
                if(!visited.ContainsKey(num))
                    visited.Add(num, false);
            }

            int max=0,left=array[0],currLeft,right=array[0],currRight;
            foreach(int key in array)
            {
                if(!visited[key])
                {

                    findBounds(visited, key, out currLeft, out currRight);
                    if(currRight-currLeft>max)
                    {
                        max = currRight - currLeft;
                        left = currLeft;
                        right = currRight;
                    }
                }
            }

            return new int[] { left, right };
        }

        private static void findBounds(Dictionary<int, bool> visited, int key, out int left, out int right)
        {
            visited[key] = true;
            left = right = key;


            while (visited.ContainsKey(left - 1) && !visited[left - 1])
            {
                left--;
                visited[left] = true;
            }

            while (visited.ContainsKey(right + 1)&&!visited[right+1])
            {
                right++;
                visited[right] = true;
            }
        }
    }
}
