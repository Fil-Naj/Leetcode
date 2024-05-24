using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1750 : ISolution
    {
        public string Name => "Minimum Length of String After Deleting Similar Ends";
        public string Description => "Given a string s consisting only of characters 'a', 'b', and 'c'. You are asked to apply the following algorithm on the string any number of times:\r\n\r\n    Pick a non-empty prefix from the string s where all the characters in the prefix are equal.\r\n    Pick a non-empty suffix from the string s where all the characters in this suffix are equal.\r\n    The prefix and the suffix should not intersect at any index.\r\n    The characters from the prefix and suffix must be the same.\r\n    Delete both the prefix and the suffix.\r\n\r\nReturn the minimum length of s after performing the above operation any number of times (possibly zero times).";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var s = "abbbbbbbbbbbbbbbbbbba";
            var result = MinimumLength(s);

            // Prettify
            Console.WriteLine($"Input: s = {s}");
            Console.WriteLine($"Output: {result}");
        }

        public int MinimumLength(string s)
        {
            // Two pointer solution
            var l = 0;
            var r = s.Length - 1;

            // Keep track of previous same character
            // Will help to remove equal suffix/prefix characters of varying lengths
            var prevChar = 'd';
            while (l < r)
            {
                // If equal, move both pointers closer together and keep track of character
                if (s[l] == s[r])
                {
                    prevChar = s[l];
                    l++;
                    r--;
                }
                // If two pointers do not match but the left pointer is equal to the previously removed character, move pointer
                else if (s[l] == prevChar)
                {
                    l++;
                }
                // If two pointers do not match but the right pointer is equal to the previously removed character, move pointer
                else if (s[r] == prevChar)
                {
                    r--;
                }
                // If none of the above, no more similar ends. Therefore, stop.
                else
                {
                    break;
                }
            }

            // If last remaining character is equal to last removed character, then it must be removed, too
            // Else, return the distance between the left and right pointer. It will be the length of the leftover string
            return s[l] == prevChar 
                ? 0 
                : r - l + 1;
        }
    }
}
