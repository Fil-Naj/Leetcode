using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2326 : ISolution
    {
        public string Name => "Spiral Matrix IV";
        public string Description => "You are given two integers m and n, which represent the dimensions of a matrix.\r\n\r\nYou are also given the head of a linked list of integers.\r\n\r\nGenerate an m x n matrix that contains the integers in the linked list presented in spiral order (clockwise), starting from the top-left of the matrix. If there are remaining empty spaces, fill them with -1.\r\n\r\nReturn the generated matrix.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var m = 8;
            var n = 7;
            ListNode head = new([405, 341, 910, 645, 954, 915, 447, 924, 263, 350, 472, 1, 481, 972, 807, 970, 898, 525, 318, 620, 21, 922, 231, 192, 659, 976, 153, 130, 273, 997, 889, 488, 528, 832, 768, 444, 894, 682, 116, 569, 305, 112, 259, 810, 898, 831, 675, 165, 224, 367, 959, 783, 477, 974]);
            var result = SpiralMatrix(m, n , head);

            // Prettify
            Console.WriteLine($"Input: m = {m}, n = {n}, head = {head}");
            result.PrintMatrix();
            int[][] expected = [[405, 341, 910, 645, 954, 915, 447], [976, 153, 130, 273, 997, 889, 924], [659, 810, 898, 831, 675, 488, 263], [192, 259, 974, -1, 165, 528, 350], [231, 112, 477, -1, 224, 832, 472], [922, 305, 783, 959, 367, 768, 1], [21, 569, 116, 682, 894, 444, 481], [620, 318, 525, 898, 970, 807, 972]];
            Console.WriteLine();
            expected.PrintMatrix();
        }

        public int[][] SpiralMatrix(int m, int n, ListNode head)
        {
            var result = new int[m][];
            for (var i = 0; i < m; i++)
            {
                var toAdd = new int[n];
                Array.Fill(toAdd, -1);
                result[i] = toAdd;
            }

            var x = -1;
            var y = 0;
            var current = head;
            while (current is not null)
            {
                // Right
                for (var i = 0; i < n; i++)
                {
                    x++;
                    result[y][x] = current?.val ?? result[y][x];
                    current = current?.next;
                }

                // Down
                for (var i = 0; i < m - 1; i++)
                {
                    y++;
                    result[y][x] = current?.val ?? result[y][x];
                    current = current?.next;
                }

                // Left
                for (var i = 0; i < n - 1; i++)
                {
                    x--;
                    result[y][x] = current?.val ?? result[y][x];
                    current = current?.next;
                }

                // Up
                for (var i = 0; i < m - 2; i++)
                {
                    y--;
                    result[y][x] = current?.val ?? result[y][x];
                    current = current?.next;
                }

                n -= 2;
                m -= 2;
            }

            return result;
        }
    }
}
