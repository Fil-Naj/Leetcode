using Leetcode.Extensions;
using System.ComponentModel;

namespace Leetcode.Solutions
{
    public class Leetcode0520 : ISolution
    {
        public string Name => "Detect Capital";
        public string Description => "We define the usage of capitals in a word to be right when one of the following cases holds:\r\n\r\n    All letters in this word are capitals, like \"USA\".\r\n    All letters in this word are not capitals, like \"leetcode\".\r\n    Only the first letter in this word is capital, like \"Google\".\r\n\r\nGiven a string word, return true if the usage of capitals in it is right.We define the usage of capitals in a word to be right when one of the following cases holds:\r\n\r\n    All letters in this word are capitals, like \"USA\".\r\n    All letters in this word are not capitals, like \"leetcode\".\r\n    Only the first letter in this word is capital, like \"Google\".\r\n\r\nGiven a string word, return true if the usage of capitals in it is right.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var word = "FLaG";
            var result = DetectCapitalUse(word);

            // Prettify
            Console.WriteLine($"Input: word = {word}");
            Console.WriteLine($"Output: {result}");
        }

        public bool DetectCapitalUse(string word)
        {
            ReadOnlySpan<char> chars = word.AsSpan();

            int count = 0;
            foreach (var ch in chars)
                if (char.IsUpper(ch))
                    count++;

            return count == 0 || count == chars.Length || (count == 1 && char.IsUpper(chars[0]));
        }

        public bool DetectCapitalUse2(string word)
        {
            return word == word.ToUpper() || word == word.ToLower() || (char.IsUpper(word[0]) && word[1..] == word[1..].ToLower());
        }
    }
}
