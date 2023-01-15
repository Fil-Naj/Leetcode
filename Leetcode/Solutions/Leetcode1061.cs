using Leetcode.Extensions;
using System.Text;

namespace Leetcode.Solutions
{
    public class Leetcode1061 : ISolution
    {
        public string Name => "Lexicographically Smallest Equivalent String";
        public string Description => "You are given two strings of the same length s1 and s2 and a string baseStr.\r\n\r\nWe say s1[i] and s2[i] are equivalent characters.\r\n\r\n    For example, if s1 = \"abc\" and s2 = \"cde\", then we have 'a' == 'c', 'b' == 'd', and 'c' == 'e'.\r\n\r\nEquivalent characters follow the usual rules of any equivalence relation:\r\n\r\n    Reflexivity: 'a' == 'a'.\r\n    Symmetry: 'a' == 'b' implies 'b' == 'a'.\r\n    Transitivity: 'a' == 'b' and 'b' == 'c' implies 'a' == 'c'.\r\n\r\nFor example, given the equivalency information from s1 = \"abc\" and s2 = \"cde\", \"acd\" and \"aab\" are equivalent strings of baseStr = \"eed\", and \"aab\" is the lexicographically smallest equivalent string of baseStr.\r\n\r\nReturn the lexicographically smallest equivalent string of baseStr by using the equivalency information from s1 and s2.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var s1 = "dfeffdfafbbebbebacbbdfcfdbcacdcbeeffdfebbdebbdafff";
            var s2 = "adcdfabadbeeafeabbadcefcaabdecabfecffbabbfcdfcaaae";
            var baseStr = "myickvflcpfyqievitqtwvfpsrxigauvlqdtqhpfugguwfcpqv";
            var result = SmallestEquivalentString(s1, s2, baseStr);

            // Prettify
            Console.WriteLine($"Input: s1 = {s1}, s2 = {s2}, baseStr = {baseStr}");
            Console.WriteLine($"Output: {result}");

            Console.WriteLine(result == "myiakvalapayqiavitqtwvapsrxigauvlqatqhpaugguwaapqv");
        }

        // Another union find. This time, we have to worry about pointing to the lower index
        public string SmallestEquivalentString(string s1, string s2, string baseStr)
        {
            var uf = new UnionFind(26);

            for (int i = 0; i < s1.Length; i++)
                uf.Union(s1[i] - 'a', s2[i] - 'a');

            StringBuilder sb = new();

            foreach (var letter in baseStr)
                sb.Append((char)(uf.Find(letter - 'a') + 'a'));

             return sb.ToString();
        }

        public class UnionFind
        {
            public int[] _uf;

            public UnionFind(int n)
            {
                _uf = new int[n];
                for (int i = 0; i < n; i++) _uf[i] = i;
            }

            public int Find(int x)
            {
                if (x != _uf[x])
                    _uf[x] = Find(_uf[x]);

                return _uf[x];
            }

            public void Union(int x, int y)
            {
                int i = Find(x);
                int j = Find(y);

                // Deals with sorting in lexicographical order
                if (i > j)
                    _uf[i] = j;
                else
                    _uf[j] = i;
            }
        }
    }
}
