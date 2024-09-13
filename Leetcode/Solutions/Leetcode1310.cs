using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1310 : ISolution
    {
        public string Name => "XOR Queries of a Subarray";
        public string Description => "You are given an array arr of positive integers. You are also given the array queries where queries[i] = [lefti, righti].\r\n\r\nFor each query i compute the XOR of elements from lefti to righti (that is, arr[lefti] XOR arr[lefti + 1] XOR ... XOR arr[righti] ).\r\n\r\nReturn an array answer where answer[i] is the answer to the ith query.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            int[] arr = [4, 8, 2, 10];
            int[][] queries = [[2, 3], [1, 3], [0, 0], [0, 3]];
            var result = XorQueries(arr, queries);

            // Prettify
            Console.WriteLine($"Input: arr = {arr.GetString()}, queries = {queries.GetString()}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public int[] XorQueries(int[] arr, int[][] queries)
        {
            var result = new int[queries.Length];

            var prefixXors = new int[arr.Length + 1];
            for (var i = 0; i < arr.Length; i++)
            {
                prefixXors[i + 1] = prefixXors[i] ^ arr[i];
            }

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = prefixXors[queries[i][0]] ^ prefixXors[queries[i][1] + 1];
            }

            return result;
        }
    }
}
