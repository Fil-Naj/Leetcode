using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0839 : ISolution
    {
        public string Name => "Similar String Groups";
        public string Description => "Two strings X and Y are similar if we can swap two letters (in different positions) of X, so that it equals Y. Also two strings X and Y are similar if they are equal.\r\n\r\nFor example, \"tars\" and \"rats\" are similar (swapping at positions 0 and 2), and \"rats\" and \"arts\" are similar, but \"star\" is not similar to \"tars\", \"rats\", or \"arts\".\r\n\r\nTogether, these form two connected groups by similarity: {\"tars\", \"rats\", \"arts\"} and {\"star\"}.  Notice that \"tars\" and \"arts\" are in the same group even though they are not similar.  Formally, each group is such that a word is in the group if and only if it is similar to at least one other word in the group.\r\n\r\nWe are given a list strs of strings where every string in strs is an anagram of every other string in strs. How many groups are there?";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var strs = new string[] { "tars", "rats", "arts", "star" };
            var result = NumSimilarGroups(strs);

            // Prettify
            Console.WriteLine($"Input: strs = {strs.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        // Used DFS, could also use UnionFind
        public int NumSimilarGroups(string[] strs)
        {
            bool[] visited = new bool[strs.Length];
            var groups = 0;

            void Dfs(int str)
            {
                visited[str] = true;

                for (int i = 0; i < strs.Length; i++)
                {
                    if (visited[i]) continue;

                    if (AreSimilar(strs[str], strs[i]))
                        Dfs(i);
                }
            }

            for (int i = 0; i < strs.Length; i++)
            {
                if (visited[i]) continue;

                groups++;
                Dfs(i);
            }

            return groups;
        }

        private bool AreSimilar(string str1, string str2)
        {
            var diff = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                    diff++;

                if (diff > 2) return false;
            }

            return diff == 0 || diff == 2;
        }
    }
}
