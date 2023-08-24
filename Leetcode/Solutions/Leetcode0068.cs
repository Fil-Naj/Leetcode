using System.Text;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0068 : ISolution
    {
        public string Name => "Text Justification";
        public string Description => "Given an array of strings words and a width maxWidth, format the text such that each line has exactly maxWidth characters and is fully (left and right) justified.\r\n\r\nYou should pack your words in a greedy approach; that is, pack as many words as you can in each line. Pad extra spaces ' ' when necessary so that each line has exactly maxWidth characters.\r\n\r\nExtra spaces between words should be distributed as evenly as possible. If the number of spaces on a line does not divide evenly between words, the empty slots on the left will be assigned more spaces than the slots on the right.\r\n\r\nFor the last line of text, it should be left-justified, and no extra space is inserted between words.\r\n\r\nNote:\r\n\r\n    A word is defined as a character sequence consisting of non-space characters only.\r\n    Each word's length is guaranteed to be greater than 0 and not exceed maxWidth.\r\n    The input array words contains at least one word.\r\n";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var words = new string[] { "Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a", "computer.", "Art", "is", "everything", "else", "we", "do" };
            var maxWidth = 20;
            var result = FullJustify(words, maxWidth);

            // Prettify
            Console.WriteLine($"Input: words = {words.GetString()}, maxWidth = {maxWidth}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            var n = words.Length;
            List<string> result = new();
            StringBuilder sb = new();
            var l = 0;
            while (l < n)
            {
                sb.Clear();
                var firstWordOnLine = words[l++];
                var wordsOnLine = new List<string>() { firstWordOnLine };
                var lineLength = firstWordOnLine.Length;

                while (l < n && lineLength + words[l].Length + 1 <= maxWidth)
                {
                    var nextWord = words[l++];
                    wordsOnLine.Add(nextWord);
                    lineLength += nextWord.Length + 1;
                }

                if (l >= n)
                {
                    var endLine = string.Join(" ", wordsOnLine);
                    sb.Append(endLine);
                    sb.Append(' ', maxWidth - endLine.Length);
                }
                else
                {
                    if (wordsOnLine.Count == 1)
                    {
                        sb.Append(wordsOnLine[0]);
                        sb.Append(' ', maxWidth - wordsOnLine[0].Length);
                    }
                    else
                    {
                        var spacesRequired = maxWidth - lineLength + (wordsOnLine.Count - 1);
                        var avgSpace = (int)Math.Round((double)spacesRequired / (wordsOnLine.Count - 1));
                        for (int i = 0; i < wordsOnLine.Count - 1; i++)
                        {
                            sb.Append(wordsOnLine[i]);
                            sb.Append(' ', Math.Min(spacesRequired, avgSpace));
                            spacesRequired -= avgSpace;
                        }
                        sb.Append(wordsOnLine[^1]);
                    }
                }

                result.Add(sb.ToString());
            }

            return result;
        }
    }
}
