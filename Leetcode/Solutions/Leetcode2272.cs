using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2272 : ISolution
    {
        public string Name => "Substring With Largest Variance";
        public string Description => "The variance of a string is defined as the largest difference between the number of occurrences of any 2 characters present in the string. Note the two characters may or may not be the same.\r\n\r\nGiven a string s consisting of lowercase English letters only, return the largest variance possible among all substrings of s.\r\n\r\nA substring is a contiguous sequence of characters within a string.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var s = "";
            var result = LargestVariance(s);

            // Prettify
            Console.WriteLine($"Input: s = {s}");
            Console.WriteLine($"Output: {result}");
        }

        // Kadane Algorithm
        // Source: https://www.geeksforgeeks.org/largest-sum-contiguous-subarray/
        public int LargestVariance(string s)
        {
            var arr = new int[26];

            // Count letter frequency
            foreach (var c in s)
                arr[c - 'a']++;

            var result = 0;

            for (char i = 'a'; i <= 'z'; i++)
            {
                for (char j = 'a'; j <= 'z'; j++)
                {
                    if (j == i || arr[i - 'a'] == 0 || arr[j - 'a'] == 0)
                        continue;

                    for (int k = 1; k <= 2; k++)
                    {
                        var c1 = 0;
                        var c2 = 0;

                        foreach (var c in s)
                        {
                            if (c == i) c1++;
                            if (c == j) c2++;

                            if (c2 > c1)
                            {
                                c1 = 0;
                                c2 = 0;
                            }

                            if (c1 > 0 && c2 > 0)
                                result = Math.Max(result, c1 - c2);
                        }
                        Reverse(ref s);
                    }
                }
            }
            return result;
        }

        private static void Reverse(ref string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            s = new string(charArray);
        }
    }
}
