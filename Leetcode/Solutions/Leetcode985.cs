using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode985 : ISolution
    {
        public string Name => "Sum of Even Numbers After Queries";
        public string Description => "You are given an integer array nums and an array queries where queries[i] = [vali, indexi]. For each query i, first, apply nums[indexi] = nums[indexi] + vali, then print the sum of the even values of nums. Return an integer array answer where answer[i] is the answer to the ith query.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 1, 2, 3, 4 };
            var queries = new int[][] { 
                new int[] { 1, 0 },
                new int[] { -3, 1 },
                new int[] { -4, 0 },
                new int[] { 2, 3 },
            };

            var result = SumEvenAfterQueries(nums, queries);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}, queiries = {queries.GetString()}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        // Time: O(n), Space: O(1)
        // Traverse queries, keep dynaminc sum. Ez
        public int[] SumEvenAfterQueries(int[] nums, int[][] queries)
        {
            int[] answer = new int[queries.Length];
            int sum = nums.Sum(n => n % 2 == 0 ? n : 0);
            for (int i = 0; i < queries.Length; i++)
            {
                int[] query = queries[i];
                int index = query[1];
                int temp = nums[index];
                int newNum = nums[index] + query[0];
                sum -= temp % 2 == 0 ? temp : 0;
                sum += newNum % 2 == 0 ? newNum : 0;
                nums[index] = newNum;
                answer[i] = sum;
            }

            return answer;
        }
    }
}
