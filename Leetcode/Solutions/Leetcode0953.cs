using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0953 : ISolution
    {
        public string Name => "Verifying an Alien Dictionary";
        public string Description => "In an alien language, surprisingly, they also use English lowercase letters, but possibly in a different order. The order of the alphabet is some permutation of lowercase letters.\r\n\r\nGiven a sequence of words written in the alien language, and the order of the alphabet, return true if and only if the given words are sorted lexicographically in this alien language.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var words = new string[] { "apple", "app" };
            var order = "abcdefghijklmnopqrstuvwxyz";
            var result = IsAlienSorted(words, order);

            // Prettify
            Console.WriteLine($"Input: data = {words.GetString()}, order = {order}");
            Console.WriteLine($"Output: {result}");
        }

        // Wanted to create an IComparer
        public bool IsAlienSorted(string[] words, string order)
        {
            Dictionary<char, int> dictionary = new();
            for (int i = 0; i < order.Length; i++)
            {
                dictionary.Add(order[i], i);
            }

            string[] initial = new string[words.Length];
            Array.Copy(words, initial, words.Length);

            Array.Sort(words, new AlienStringComparer(dictionary));

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != initial[i]) return false;
            }

            return true;
        }

        public class AlienStringComparer : IComparer<string>
        {
            Dictionary<char, int> _dictionary;

            public AlienStringComparer(Dictionary<char, int> dictionary)
            {
                _dictionary = dictionary;
            }

            public int Compare(string? x, string? y)
            {
                int minLength = Math.Min(x.Length, y.Length);

                for (int i = 0; i < minLength; i++)
                {
                    int indexOfX = _dictionary[x[i]];
                    int indexOfY = _dictionary[y[i]];

                    var compare = indexOfX.CompareTo(indexOfY);

                    if (compare != 0) return compare;
                }

                return x.Length.CompareTo(y.Length);
            }
        }
    }
}
