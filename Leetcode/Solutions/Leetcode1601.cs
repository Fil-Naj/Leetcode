using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1601 : ISolution
    {
        public string Name => "Maximum Number of Achievable Transfer Requests";
        public string Description => "We have n buildings numbered from 0 to n - 1. Each building has a number of employees. It's transfer season, and some employees want to change the building they reside in.\r\n\r\nYou are given an array requests where requests[i] = [fromi, toi] represents an employee's request to transfer from building fromi to building toi.\r\n\r\nAll buildings are full, so a list of requests is achievable only if for each building, the net change in employee transfers is zero. This means the number of employees leaving is equal to the number of employees moving in. For example if n = 3 and two employees are leaving building 0, one is leaving building 1, and one is leaving building 2, there should be two employees moving to building 0, one employee moving to building 1, and one employee moving to building 2.\r\n\r\nReturn the maximum number of achievable requests.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var n = 5;
            var requests = new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 1, 0 },
                new int[] { 0, 1 },
                new int[] { 1, 2 },
                new int[] { 2, 0 },
                new int[] { 3, 4 },
            };
            var result = MaximumRequests(n, requests);

            // Prettify
            Console.WriteLine($"Input: n = {n}, requests = {requests.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int MaximumRequests(int n, int[][] requests)
        {
            var inDegree = new int[n];

            int Move(int reqIndex, int count)
            {
                if (reqIndex == requests.Length)
                {
                    for (int i = 0; i < n; i++)
                        if (inDegree[i] != 0) return 0;

                    return count;
                }

                // Take!
                inDegree[requests[reqIndex][0]]--;
                inDegree[requests[reqIndex][1]]++;
                var take = Move(reqIndex + 1, count + 1);

                // No take! Return people
                inDegree[requests[reqIndex][0]]++;
                inDegree[requests[reqIndex][1]]--;
                var notTake = Move(reqIndex + 1, count);

                return Math.Max(take, notTake);
            }

            return Move(0, 0);
        }
    }
}
