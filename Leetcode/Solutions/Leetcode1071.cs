using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    [ToBeContinued("Review for optimal solution. Shame to post this...")]
    public class Leetcode1071 : ISolution
    {
        public string Name => "Greatest Common Divisor of Strings";
        public string Description => "For two strings s and t, we say \"t divides s\" if and only if s = t + ... + t (i.e., t is concatenated with itself one or more times).\r\n\r\nGiven two strings str1 and str2, return the largest string x such that x divides both str1 and str2.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var str1 =  "NLZGMNLZGMNLZGMNLZGMNLZGMNLZGMNLZGMNLZGM";
            var str2 =  "NLZGMNLZGMNLZGMNLZGMNLZGMNLZGMNLZGMNLZGMNLZGM";
            var result = GcdOfStrings(str1, str2);

            // Prettify
            Console.WriteLine($"Input: {nameof(str1)} = {str1}, {nameof(str2)} = {str2}");
            Console.WriteLine($"Output: {result}");
        }

        public string GcdOfStrings(string str1, string str2)
        {
            // Is the smaller one the divisor of the bigger one
            if (str1.Replace(str2, string.Empty) == string.Empty) return str2;
            if (str2.Replace(str1, string.Empty) == string.Empty) return str1;

            int midStr1 = str1.Length / 2;
            HashSet<string> common1 = new();
            for (int i = 0; i < midStr1; i++)
            {
                var divisor = str1[..(i + 1)];
                if (str1.Replace(divisor, string.Empty) == string.Empty)
                    common1.Add(divisor);
            }

            int midStr2 = str2.Length / 2;
            HashSet<string> common2 = new();
            for (int i = 0; i < midStr2; i++)
            {
                var divisor = str2[..(i + 1)];
                if (str2.Replace(divisor, string.Empty) == string.Empty)
                    common2.Add(divisor);
            }

            return common1.Intersect(common2).OrderByDescending(l => l.Length).FirstOrDefault() ?? string.Empty;
        }
    }
}
