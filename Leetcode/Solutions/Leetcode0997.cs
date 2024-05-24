using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0997 : ISolution
    {
        public string Name => "Find the Town Judge";
        public string Description => "In a town, there are n people labeled from 1 to n. There is a rumor that one of these people is secretly the town judge.\r\n\r\nIf the town judge exists, then:\r\n\r\n    The town judge trusts nobody.\r\n    Everybody (except for the town judge) trusts the town judge.\r\n    There is exactly one person that satisfies properties 1 and 2.\r\n\r\nYou are given an array trust where trust[i] = [ai, bi] representing that the person labeled ai trusts the person labeled bi. If a trust relationship does not exist in trust array, then such a trust relationship does not exist.\r\n\r\nReturn the label of the town judge if the town judge exists and can be identified, or return -1 otherwise.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var n = 3;
            var trust = new int[][] 
            { 
                [1, 3],
                [2, 3],
            };
            var result = FindJudge(n, trust);

            // Prettify
            Console.WriteLine($"Input: n = {n}, trust = {trust.GetString()}, ");
            Console.WriteLine($"Output: {result}");
        }

        public int FindJudge(int n, int[][] trust)
        {
            if (trust.Length == n) return -1;

            var isTrustedBy = new int[n + 1];
            var peopleTheyTrust = new int[n + 1];

            foreach (var p in trust)
            {
                isTrustedBy[p[1]]++;
                peopleTheyTrust[p[0]]++;
            }

            for (var i = 1; i <= n; i++)
            {
                // If meets requirement to be townJudge
                if (isTrustedBy[i] == n - 1 && peopleTheyTrust[i] == 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
