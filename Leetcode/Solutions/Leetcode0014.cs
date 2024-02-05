using Leetcode.Extensions;
using System.Text;

namespace Leetcode.Solutions
{
    public class Leetcode0014 : ISolution
    {
        public string Name => "Longest Common Prefix";
        public string Description => "Write a function to find the longest common prefix string amongst an array of strings.\r\n\r\nIf there is no common prefix, return an empty string \"\".";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            string[] data = ["flower", "flow", "flight"];
            var result = LongestCommonPrefix(data);

            // Prettify
            Console.WriteLine($"Input: data = {data.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public string LongestCommonPrefix(string[] strs)
        {
            StringBuilder sb = new();
            var minLength = strs.Min(s => s.Length);

            var i = 0;
            while (i < minLength && strs.All(s => s[i] == strs[0][i]))
            {
                sb.Append(strs[0][i]);
                i++;
            }

            return sb.ToString();
        }
    }
}
