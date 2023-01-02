using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2287 : ISolution
    {
        public string Name => "Rearrange Characters to Make Target String";
        public string Description => "You are given two 0-indexed strings s and target. You can take some letters from s and rearrange them to form new strings.\r\n\r\nReturn the maximum number of copies of target that can be formed by taking letters from s and rearranging them.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var s = "ilovecodingonleetcode";
            var target = "code";
            var result = RearrangeCharacters(s, target);

            // Prettify
            Console.WriteLine($"Input: s = {s}, target = {target}");
            Console.WriteLine($"Output: {result}");
        }

        public int RearrangeCharacters(string s, string target)
        {
            Dictionary<char, int> sf = s.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            Dictionary<char, int> tf = target.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

            var result = int.MaxValue;
            foreach (var c in tf)
            {
                result = Math.Min(result, sf.TryGetValue(c.Key, out var value) ? value / c.Value : 0);
            }
            return result;
        }
    }
}
