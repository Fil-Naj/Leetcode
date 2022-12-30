using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1154 : ISolution
    {
        public string Name => "Make The String Great";
        public string Description => "Given a string s of lower and upper case English letters.\r\n\r\nA good string is a string which doesn't have two adjacent characters s[i] and s[i + 1] where:\r\n\r\n    0 <= i <= s.length - 2\r\n    s[i] is a lower-case letter and s[i + 1] is the same letter but in upper-case or vice-versa.\r\n\r\nTo make the string good, you can choose two adjacent characters that make the string bad and remove them. You can keep doing this until the string becomes good.\r\n\r\nReturn the string after making it good. The answer is guaranteed to be unique under the given constraints.\r\n\r\nNotice that an empty string is also good.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var s = "abBAcC";
            var result = MakeGood(s);

            // Prettify
            Console.WriteLine($"Input: s = {s}");
            Console.WriteLine($"Output: {result}");
        }

        public string MakeGood(string s)
        {
            var length = s.Length;
            if (length == 0) return string.Empty;

            for (int i = 0; i <= length - 2; i++)
            {
                if (Math.Abs(s[i] - s[i + 1]) == 32)
                    return MakeGood(s.Remove(i, 2));
            }
            return s;
        }
    }
}
