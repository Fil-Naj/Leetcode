namespace Leetcode.Solutions
{
    [ToBeContinued("Shit dont work")]
    public class Leetcode7
    {
        // Is shit, does not work
        public int Reverse(int x)
        {
            const int limit = int.MaxValue;
            int multiplier = x < 0 ? -1 : 1;
            long reversed = long.Parse(Math.Abs(x).ToString());
            return (int)(reversed > limit ? 0 : reversed * multiplier);
        }
    }
}
