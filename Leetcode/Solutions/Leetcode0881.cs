using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0881 : ISolution
    {
        public string Name => "Boats to Save People";
        public string Description => "You are given an array people where people[i] is the weight of the ith person, and an infinite number of boats where each boat can carry a maximum weight of limit. Each boat carries at most two people at the same time, provided the sum of the weight of those people is at most limit.\r\n\r\nReturn the minimum number of boats to carry every given person.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var people = new int[] { 3, 2, 2, 1 };
            var limit = 3;
            var result = NumRescueBoats(people, limit);

            // Prettify
            Console.WriteLine($"Input: people = {people.GetString()}, limit = {limit}");
            Console.WriteLine($"Output: {result}");
        }

        public int NumRescueBoats(int[] people, int limit)
        {
            Array.Sort(people);
            var l = 0;
            var r = people.Length - 1;

            var result = 1;
            while (l <= r)
            {

                if (people[l] + people[r] <= limit)
                {
                    l++;
                    r--;
                }
                else
                {
                    r--;
                }

                result++;
            }

            return result;
        }
    }
}
