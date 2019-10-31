using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algoExpert.Solutions
{
    class RiverSizesChecker
    {
        public static void check()
        {
            Console.WriteLine("RiverSizes:");
            int[][] check = new int[][] { new int[] { 1, 0, 0, 1, 0 }, new int[] { 1, 0, 1, 0, 0 }, new int[] { 0, 0, 1, 0, 1 }, new int[] { 1, 0, 1, 0, 1 }, new int[] { 1, 0, 1, 1, 0 } };
            List<int> res = RiverSizes(check);
            foreach (int num in res)
            {
                Console.WriteLine(num);
            }
        }

        private static List<int> RiverSizes(int[][] matrix)
        {
            List<int> riversSizes = new List<int>();
            bool[][] visited = allocateMatrix(matrix);
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 1 && !visited[i][j])
                    {
                        riversSizes.Add(findRiver(matrix, visited, i, j));
                    }
                }
            }
            return riversSizes;
        }

        private static int findRiver(int[][] matrix, bool[][] visited, int row, int col)
        {
            visited[row][col] = true;
            int res = 1;
            if (inBounds(matrix, row, col - 1) && matrix[row][col-1]==1&&!visited[row][col - 1])
            {
                res += findRiver(matrix, visited, row, col - 1);
            }
            if (inBounds(matrix, row, col + 1) && matrix[row][col + 1] == 1 && !visited[row][col + 1])
            {
                res += findRiver(matrix, visited, row, col + 1);
            }
            if (inBounds(matrix, row - 1, col) && matrix[row-1][col] == 1 && !visited[row - 1][col])
            {
                res += findRiver(matrix, visited, row - 1, col);
            }
            if (inBounds(matrix, row + 1, col) && matrix[row+1][col] == 1 && !visited[row + 1][col])
            {
                res += findRiver(matrix, visited, row + 1, col);
            }
            return res;
        }

        private static bool inBounds(int[][] matrix, int row, int col)
        {
            bool res= (row >= 0 && row < matrix.Length) && (col >= 0 && col < matrix[row].Length);
            return res;
        }

        private static bool[][] allocateMatrix(int[][] matrix)
        {
            bool[][] res = new bool[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                res[i] = new bool[matrix[i].Length];
            }
            return res;
        }

    }
}
