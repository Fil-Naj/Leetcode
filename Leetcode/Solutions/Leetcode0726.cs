using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0726 : ISolution
    {
        public string Name => "Number of Atoms";
        public string Description => "Given a string formula representing a chemical formula, return the count of each atom.\r\n\r\nThe atomic element always starts with an uppercase character, then zero or more lowercase letters, representing the name.\r\n\r\nOne or more digits representing that element's count may follow if the count is greater than 1. If the count is 1, no digits will follow.\r\n\r\n    For example, \"H2O\" and \"H2O2\" are possible, but \"H1O2\" is impossible.\r\n\r\nTwo formulas are concatenated together to produce another formula.\r\n\r\n    For example, \"H2O2He3Mg4\" is also a formula.\r\n\r\nA formula placed in parentheses, and a count (optionally added) is also a formula.\r\n\r\n    For example, \"(H2O2)\" and \"(H2O2)3\" are formulas.\r\n\r\nReturn the count of all elements as a string in the following form: the first name (in sorted order), followed by its count (if that count is more than 1), followed by the second name (in sorted order), followed by its count (if that count is more than 1), and so on.\r\n\r\nThe test cases are generated so that all the values in the output fit in a 32-bit integer.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var formula = "H(N(O2)5M3)4";
            var result = CountOfAtoms(formula);

            // Prettify
            Console.WriteLine($"Input: formula = {formula}");
            Console.WriteLine($"Output: {result}");
        }

        public string CountOfAtoms(string formula)
        {
            var n = formula.Length;

            Dictionary<string, int> formulae = [];
            Stack<Dictionary<string, int>> stack = [];

            var currentAtom = string.Empty;
            var currentAtomCount = string.Empty;
            Dictionary<string, int> currentFormulae = formulae;
            for (var i = 0; i < formula.Length; i++)
            {
                if (char.IsUpper(formula[i]))
                {
                    currentAtom = formula[i].ToString();
                    while (i + 1 < n && char.IsLower(formula[i + 1]))
                    {
                        currentAtom += formula[++i];
                    }

                    currentAtomCount = string.Empty;
                    while (i + 1 < n && char.IsDigit(formula[i + 1]))
                    {
                        currentAtomCount += formula[++i];
                    }

                    if (!currentFormulae.ContainsKey(currentAtom))
                    {
                        currentFormulae[currentAtom] = 0;
                    }
                    currentFormulae[currentAtom] += int.TryParse(currentAtomCount, out var cac) ? cac : 1;
                }
                else if (formula[i] == '(')
                {
                    stack.Push(currentFormulae);
                    currentFormulae = [];
                }
                else
                {
                    var moleculeCount = string.Empty;
                    while (i + 1 < n && char.IsDigit(formula[i + 1]))
                    {
                        moleculeCount += formula[++i];
                    }
                    var multiplier = int.TryParse(moleculeCount, out var m) ? m : 1;

                    var lower = stack.Pop();
                    foreach (var atom in currentFormulae)
                    {
                        if (!lower.ContainsKey(atom.Key))
                        {
                            lower[atom.Key] = 0;
                        }

                        lower[atom.Key] += atom.Value * multiplier;
                    }

                    currentFormulae = lower;
                }
            }

            return string.Join(string.Empty, formulae.OrderBy(a => a.Key).Select(a => $"{a.Key}{(a.Value > 1 ? a.Value : string.Empty)}"));
        }
    }
}
