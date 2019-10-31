using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algoExpert.Solutions
{
    class FindClosestValueInBstChecker
    {
        public static void check()
        {
            Console.WriteLine("FindClosestValueInBst:");
            BST tree = new BST(5);
            BST left = new BST(3);
            BST right = new BST(2);
            tree.left = left;
            tree.right = right;
            Console.WriteLine(FindClosestValueInBst(tree,-100));


        }
        //n solution
        private static int FindClosestValueInBst(BST tree, int target)
        {
            int temp = Math.Abs(tree.value - target), res = tree.value;
            if (tree.left != null)
            {
                int distanceLeft = Math.Abs(target - FindClosestValueInBst(tree.left, target));
                if (distanceLeft < temp)
                {
                    temp = distanceLeft;
                    res = FindClosestValueInBst(tree.left, target);
                }
            }
            if (tree.right != null)
            {
                int distanceRight = Math.Abs(target - FindClosestValueInBst(tree.right, target));
                if (distanceRight < temp)
                {
                    temp = distanceRight;
                    res = FindClosestValueInBst(tree.right, target);
                }
            }
            return res;
        }



        private class BST
        {
            public int value;
            public BST left;
            public BST right;

            public BST(int value)
            {
                this.value = value;
            }
        }
    }

}
