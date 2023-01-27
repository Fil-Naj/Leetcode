using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0472 : ISolution
    {
        public string Name => "Concatenated Words";
        public string Description => "Given an array of strings words (without duplicates), return all the concatenated words in the given list of words.\r\n\r\nA concatenated word is defined as a string that is comprised entirely of at least two shorter words in the given array.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var data = new string[] { "cat", "cats", "catsdogcats", "dog", "dogcatsdog", "hippopotamuses", "rat", "ratcatdogcat" };
            var result = FindAllConcatenatedWordsInADict(data);

            // Prettify
            Console.WriteLine($"Input: data = {data.GetString()}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            HashSet<string> initialWords = new(words);
            List<string> concatWords = new();

            bool CheckConcatenate(string word)
            {
                for (int i = 1; i < word.Length; i++)
                {
                    var prefixWord = word.Substring(0, i);
                    var suffixWord = word.Substring(i, word.Length - i);

                    if (initialWords.Contains(prefixWord) && (initialWords.Contains(suffixWord) || CheckConcatenate(suffixWord)))
                        return true;
                }
                return false;
            }

            foreach (string word in initialWords)
            {
                if (CheckConcatenate(word))
                    concatWords.Add(word);
            }

            return concatWords;
        }
    }
}
