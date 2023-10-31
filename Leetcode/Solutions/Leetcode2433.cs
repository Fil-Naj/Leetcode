using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2433 : ISolution
    {
        public string Name => "Find The Original Array of Prefix Xor";
        public string Description => "You are given an integer array pref of size n. Find and return the array arr of size n that satisfies:\r\n\r\n    pref[i] = arr[0] ^ arr[1] ^ ... ^ arr[i].\r\n\r\nNote that ^ denotes the bitwise-xor operation.\r\n\r\nIt can be proven that the answer is unique.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var pref = new int[] { 5, 2, 0, 3, 1 };
            var result = FindArray(pref);

            // Prettify
            Console.WriteLine($"Input: pref = {pref.GetString()}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public int[] FindArray(int[] pref)
        {
            if (pref.Length == 1) return pref;

            var result = new int[pref.Length];
            result[0] = pref[0];
            for (int i = 1; i < pref.Length; i++)
            {
                result[i] = pref[i - 1] ^ pref[i];
            }

            return result;
        }
    }
}
