using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1832 : ISolution
    {
        public string Name => "Check if the Sentence Is Pangram";
        public string Description => "A pangram is a sentence where every letter of the English alphabet appears at least once.\r\n\r\nGiven a string sentence containing only lowercase English letters, return true if sentence is a pangram, or false otherwise.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var s = "thequickbrownfoxjumpsoverthelazydog";
            //var s = "leetcode";
            var result = CheckIfPangram(s);

            // Prettify
            Console.WriteLine($"Input: s = {s}");
            Console.WriteLine($"Output: {result}");
        }

        public bool CheckIfPangram(string sentence)
        {
            //HashSet<char> alphabet = new("abcdefghijklmnopqrstuvwxyz".ToCharArray());

            //for (int i = 0; i < sentence.Length; i++)
            //    alphabet.Remove(sentence[i]);

            //return !alphabet.Any();
            return sentence.Distinct().Count() == 26;
        }
    }
}
