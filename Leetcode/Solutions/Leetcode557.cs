using Leetcode.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Solutions
{
    public class Leetcode557 : ISolution
    {
        public string Name => "Reverse Words in a String III";
        public string Description => "Given a string s, reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            string s = "Let's take LeetCode contest";
            var result = ReverseWords(s);

            // Prettify 
            Console.WriteLine($"Input: s = {s}");
            Console.WriteLine($"Output: {result}");
        }

        public string ReverseWords(string s)
        {
            string[] words = s.Split(' ');
            for (int i = 0; i < words.Length; i++)
                words[i] = Reverse(words[i]);
            
            return string.Join(' ', words);
        }

        public string ReverseWordsParallelFor(string s)
        {
            var x = new ConcurrentBag<string>();
            string[] words = s.Split(' ');
            Parallel.For(0, words.Length, i =>
                words[i] = Reverse(words[i])
            );

            return string.Join(' ', words);
        }


        public string ReverseWordsParallelForEach(string s)
        {
            string[] words = s.Split(' ');
            Parallel.ForEach(words, i =>
                i = Reverse(i)
            );

            return string.Join(' ', words);
        }

        public string ReverseWordsParallelForAll(string s)
        {
            var x = new ConcurrentBag<string>();
            var words = s.Split(' ').AsParallel().WithDegreeOfParallelism(8);
            ParallelEnumerable.ForAll<string>(words, (word) => Reverse(word));

            return string.Join(' ', words);
        }

        private string Reverse(string word)
        {
            string result = string.Empty;
            foreach (char letter in word)
                result = letter + result;
            return result;
        }
    }
}
