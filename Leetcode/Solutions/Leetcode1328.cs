using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1328 : ISolution
    {
        public string Name => "Break a Palindrome";
        public string Description => "Given a palindromic string of lowercase English letters palindrome, replace exactly one character with any lowercase English letter so that the resulting string is not a palindrome and that it is the lexicographically smallest one possible.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var data = "aaaaabaaaaa";
            var result = BreakPalindrome(data);

            // Prettify
            Console.WriteLine($"Input: data = {data}");
            Console.WriteLine($"Output: {result}");
        }

        /* 
         * Description of the solution:
         * 'a' is lexicographically the lowest character possible in this situation (lower case case alphabettical characters).
         * It is the only character that will change the palindrome into a result we want, lexicographically smallest palindrome breaking string.
         * To ensure the palindrome is broken in the lexicographically smallest way, we only iterate through the first half of it, as both sides are equal.
         * The first character in the first half of the palindrome that is not an 'a', we change to an 'a' and call it a success!
         * We do not care to change the middle character (if length is odd) because the string will still be a palindrome no matter what it is changed to.
         * 
         * The ONLY edge case to the prescribed solution above is if all characters in the first half are equal to 'a'.
         * This means the entire first half and second half are equal to 'a'. Remember we don't care about the middle character.
         * The solution to this is to increment the character at the end of the string.
         * In this case, simply changing the last character to a 'b'.
         * 
        */
        public string BreakPalindrome(string palindrome)
        {
            if (palindrome.Length == 0) return string.Empty;

            int middle = (palindrome.Length) / 2;

            for (int i = 0; i < middle; i++)
            {
                if (palindrome[i] == 'a')
                    continue;

                return palindrome.Remove(i, 1).Insert(i, "a");
            }
            return palindrome.Remove(palindrome.Length - 1, 1).Insert(palindrome.Length - 1, "b");
        }
    }
}
