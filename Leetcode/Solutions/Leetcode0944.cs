using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0944 : ISolution
    {
        public string Name => "Delete Columns to Make Sorted";
        public string Description => "You are given an array of n strings strs, all of the same length.\r\n\r\nThe strings can be arranged such that there is one on each line, making a grid. You want to delete the columns that are not sorted lexicographically. In the above example (0-indexed), columns 0 ('a', 'b', 'c') and 2 ('c', 'e', 'e') are sorted while column 1 ('b', 'c', 'a') is not, so you would delete column 1.\r\n\r\nReturn the number of columns that you will delete.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var strs = new string[] { "zyx", "wvu", "tsr" };
            
            var result = MinDeletionSize(strs);

            // Prettify
            Console.WriteLine($"Input: strs = {strs.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        // Learnings
        // string.ElementAt(i) is slow
        // Use regular indexing with stringVar[i]
        public int MinDeletionSize(string[] strs)
        {
            var n = strs.Length;
            var len = strs[0].Length;
            
            var result = 0;

            for (int i = 0; i < len; i++)
            {
                var lastChar = 'a';
                for (int j = 0; j < n; j++) 
                {
                    if (strs[j][i] < lastChar)
                    {
                        result++;
                        break;
                    }
                    lastChar = strs[j][i];
                }
            }

            return result;
        }
    }
}
