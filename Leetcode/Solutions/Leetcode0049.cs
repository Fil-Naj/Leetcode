using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0049 : ISolution
    {
        public string Name => "Group Anagrams";
        public string Description => "Given an array of strings strs, group the anagrams together. You can return the answer in any order.\r\n\r\nAn Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            string[] strs = ["eat", "tea", "tan", "ate", "nat", "bat"];
            var result = GroupAnagrams(strs);

            // Prettify
            Console.WriteLine($"Input: strs = {strs.GetString()}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> groups = [];
            foreach (var str in strs)
            {
                var orderedStr = str.ToCharArray();
                Array.Sort(orderedStr);
                var sortedStr = new string(orderedStr);
                if (!groups.TryGetValue(sortedStr, out List<string> value))
                {
                    value = ([]);
                    groups[sortedStr] = value;
                }

                value.Add(str);
            }

            return [.. groups.Values];
        }
    }
}
