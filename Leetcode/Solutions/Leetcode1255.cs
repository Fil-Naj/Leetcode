using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1255 : ISolution
    {
        public string Name => "Maximum Score Words Formed by Letters";
        public string Description => "Given a list of words, list of  single letters (might be repeating) and score of every character.\r\n\r\nReturn the maximum score of any valid set of words formed by using the given letters (words[i] cannot be used two or more times).\r\n\r\nIt is not necessary to use all characters in letters and each letter can only be used once. Score of letters 'a', 'b', 'c', ... ,'z' is given by score[0], score[1], ... , score[25] respectively.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            string[] words = ["dog", "cat", "dad", "good"];
            char[] letters = ['a', 'a', 'c', 'd', 'd', 'd', 'g', 'o', 'o'];
            int[] score = [1, 0, 9, 5, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
            var result = MaxScoreWords(words, letters, score);

            // Prettify
            Console.WriteLine($"Input: words = {words.GetString()}, letters= {letters.GetString()}, score = {score.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int MaxScoreWords(string[] words, char[] letters, int[] score)
        {
            // Find out how many of each letter we have to work with
            var counts = new int[26];
            foreach (var letter in letters)
                counts[letter - 'a']++;

            // Pre-calculate the scores for each word, and their letter frequencies
            var wordScores = new (int score, int[] counts)[words.Length];
            for (var i = 0; i < words.Length; i++)
            {
                var count = new int[26];
                var wordScore = 0;
                foreach (var c in words[i])
                {
                    count[c - 'a']++;
                    wordScore += score[c - 'a'];
                }

                wordScores[i] = (wordScore, count);
            }

            var maxScore = 0;

            // Used to see if we have sufficient letters to use word in score
            bool CanUseWord(int[] lettersLeft, int[] wordCount)
            {
                for (var i = 0; i < wordCount.Length; i++)
                {
                    if (wordCount[i] > lettersLeft[i]) return false;
                }

                return true;
            }

            // Backtracking DFS algorithm
            void Dfs(int wordIndex, int currentScore)
            {
                // If we have gone past the end of the list, stop and evaluate score
                if (wordIndex >= words.Length)
                {
                    maxScore = Math.Max(currentScore, maxScore);
                    return;
                }

                // Try the next word without adding this one
                Dfs(wordIndex + 1, currentScore);

                // See if we can use this word
                var currentWord = wordScores[wordIndex];
                if (CanUseWord(counts, currentWord.counts))
                {
                    // Remove letters from counts
                    for (var i = 0; i < counts.Length; i++)
                    {
                        counts[i] -= currentWord.counts[i];
                    }

                    // Go to next word
                    Dfs(wordIndex + 1, currentScore + currentWord.score);

                    // Add back to counts
                    for (var i = 0; i < counts.Length; i++)
                    {
                        counts[i] += currentWord.counts[i];
                    }
                }
            }

            // Start from the start with a score of zero
            Dfs(0, 0);

            return maxScore;
        }
    }
}
