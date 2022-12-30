namespace Leetcode.Solutions
{
    [ToBeContinued("Shit was boring apparently. Maybe one day but who cares. Heat death.")]
    public class Leetcode2007
    {
        [Obsolete("Boringgggg. Same as everything else. I guess what can you expect for puzzle 2007")]
        public int[] FindOriginalArray(int[] changed)
        {
            if (changed.Length % 2 != 0) return Array.Empty<int>();
            var sorted = changed.OrderBy(n => n);
            List<int> result = new();
            HashSet<int> set = new();
            foreach (int i in sorted)
            {

            }

            return result.ToArray();

        }
    }
}
