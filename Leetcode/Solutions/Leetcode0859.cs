using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0859 : ISolution
    {
        public string Name => "Buddy Strings";
        public string Description => "Given two strings s and goal, return true if you can swap two letters in s so the result is equal to goal, otherwise, return false.\r\n\r\nSwapping letters is defined as taking two indices i and j (0-indexed) such that i != j and swapping the characters at s[i] and s[j].\r\n\r\n    For example, swapping at indices 0 and 2 in \"abcd\" results in \"cbad\".\r\n";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var s = "aa";
            var goal = "aa";
            var result = BuddyStrings(s, goal);

            // Prettify
            Console.WriteLine($"Input: s = {s}, goal = {goal}");
            Console.WriteLine($"Output: {result}");
        }

        public bool BuddyStrings(string s, string goal)
        {
            if (s.Length != goal.Length) return false;
            if (s == goal) return s.ToHashSet().Count < s.Length;

            int index1 = -1;
            int index2 = -1;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != goal[i])
                {
                    if (index1 < 0)
                    {
                        index1 = i;
                    }
                    else if (index2 < 0) 
                    {
                        index2 = i;
                    }
                    // If more than two different, not possible
                    else return false;
                }
            }

            return index1 > -1 && index2 > -1
                && s[index1] == goal[index2]
                && s[index2] == goal[index1];
        }
    }
}
