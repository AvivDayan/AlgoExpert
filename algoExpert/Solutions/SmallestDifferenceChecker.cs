
using System;
public class SmallestDifferenceChecker
{
    public static void check()
    {
        Console.WriteLine("SmallestDifference:");
        int[] arg1 = new int[] { -1,5,10,20,3 };
        int[] arg2 = new int[] { 26,134,135,15,17 };
        int[] res = SmallestDifference(arg1, arg2);
        Console.WriteLine("{0}, {1}",res[0],res[1]);
    }

    private static int[] SmallestDifference(int[] arrayOne, int[] arrayTwo)
    {
        Array.Sort(arrayTwo);
        int[] pair = new int[2];
        int closest, distance = int.MaxValue, currDistance;
        foreach (int num in arrayOne)
        {
            closest = searchClosest(arrayTwo, num);
            currDistance = Math.Abs(num - closest);
            if (currDistance < distance)
            {
                distance = currDistance;
                pair[0] = num;
                pair[1] = closest;
            }
        }
        return pair;
    }
    private static int searchClosest(int[] arr, int target)
    {
        return helper(arr, target, 0, arr.Length - 1);
    }

    private static int helper(int[] arr, int target, int left, int right)
    {
        if (left <= right)
        {
            int mid = (left + right) / 2, temp = 0;
            if (arr[mid] < target)
            {
                temp = helper(arr, target, mid + 1, right);
                if (temp == int.MaxValue || Math.Abs(arr[mid] - target) < Math.Abs(temp - target))
                    return arr[mid];
                else
                    return temp;
            }
            else if (target < arr[mid])
            {
                temp = helper(arr, target, left, mid - 1);
                if (temp == int.MaxValue || Math.Abs(arr[mid] - target) < Math.Abs(temp - target))
                    return arr[mid];
                else
                    return temp;     
            }
            else
            {
                return arr[mid];
            }
        }
        return int.MaxValue;
    }
}

