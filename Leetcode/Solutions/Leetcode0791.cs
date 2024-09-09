using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0791 : ISolution
    {
        public string Name => "Custom Sort String";
        public string Description => "You are given two strings order and s. All the characters of order are unique and were sorted in some custom order previously.\r\n\r\nPermute the characters of s so that they match the order that order was sorted. More specifically, if a character x occurs before a character y in order, then x should occur before y in the permuted string.\r\n\r\nReturn any permutation of s that satisfies this property.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var order = "bcafg";
            var s = "abcd";
            var result = CustomSortString(order, s);

            // Prettify
            Console.WriteLine($"Input: order = {order}, s = {s}");
            Console.WriteLine($"Output: {result}");
        }

        public string CustomSortString(string order, string s)
        {
            var arrOrder = new int[26];
            for (int i = 0; i < order.Length; i++)
            {
                arrOrder[order[i] - 'a'] = i;
            }

            var arrS = s.ToCharArray();
            Array.Sort(arrS, (x, y) => arrOrder[x - 'a'].CompareTo(arrOrder[y - 'a']));

            return string.Concat(arrS);
        }
    }
}
