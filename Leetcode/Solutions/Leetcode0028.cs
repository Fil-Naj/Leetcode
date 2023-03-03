using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0028 : ISolution
    {
        public string Name => "Find the Index of the First Occurrence in a String";
        public string Description => "Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var haystack = "sadbutsad";
            var needle = "sad";
            var result = StrStr(haystack, needle);

            // Prettify
            Console.WriteLine($"Input: haystack = {haystack}, needle = {needle}");
            Console.WriteLine($"Output: {result}");
        }

        public int StrStr(string haystack, string needle)
        {
            return haystack.IndexOf(needle);
        }
    }
}
