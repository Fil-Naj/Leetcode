using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode990 : ISolution
    {
        public string Name => "Satisfiability of Equality Equations";
        public string Description => "You are given an array of strings equations that represent relationships between variables where each string equations[i] is of length 4 and takes one of two different forms: \"xi==yi\" or \"xi!=yi\".Here, xi and yi are lowercase letters (not necessarily different) that represent one-letter variable names.\r\n\r\nReturn true if it is possible to assign integers to variable names so as to satisfy all the given equations, or false otherwise.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            string[] equations = new string[] { "a==b", "c==b", "d==e", "e==f", "f==a", "g!=c", "d==g" };
            var result = EquationsPossible(equations);

            // Prettify
            Console.WriteLine($"Input: equations = {equations.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        // I'm so upset about this one
        // If only we had pointers man
        // So, so upset
        int[] uf = new int[26];

        public bool EquationsPossible(string[] equations)
        {
            for (int i = 0; i < 26; i++) uf[i] = i;
            foreach (string e in equations)
            {
                if (e[1] == '=')
                    uf[Find(e[0] - 'a')] = Find(e[3] - 'a');
            }
            foreach (string e in equations)
            {
                if (e[1] == '!' && Find(e[0] - 'a') == Find(e[3] - 'a'))
                    return false;
            }
            return true;
        }

        private int Find(int x)
        {
            if (x != uf[x])
                uf[x] = Find(uf[x]);
            return uf[x];
        }
    }
}
