using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2336 : ISolution
    {
        public string Name => "Smallest Number in Infinite Set";
        public string Description => "You have a set which contains all positive integers [1, 2, 3, 4, 5, ...].\r\n\r\nImplement the SmallestInfiniteSet class:\r\n\r\n    SmallestInfiniteSet() Initializes the SmallestInfiniteSet object to contain all positive integers.\r\n    int popSmallest() Removes and returns the smallest integer contained in the infinite set.\r\n    void addBack(int num) Adds a positive integer num back into the infinite set, if it is not already in the infinite set.\r\n";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            SmallestInfiniteSet sis = new();

            sis.AddBack(2);
            Console.WriteLine($"Adding 2 back into the set //Should do nothing as 2 already in");

            Console.WriteLine($"Popping smallest! Expected: 1, Actual: {sis.PopSmallest()};");
            Console.WriteLine($"Popping smallest! Expected: 2, Actual: {sis.PopSmallest()};");
            Console.WriteLine($"Popping smallest! Expected: 3, Actual: {sis.PopSmallest()};");

            sis.AddBack(1);
            Console.WriteLine($"Adding 1 back into the set //Should now be the smallest again");

            Console.WriteLine($"Popping smallest! Expected: 1, Actual: {sis.PopSmallest()};");
            Console.WriteLine($"Popping smallest! Expected: 4, Actual: {sis.PopSmallest()};");
            Console.WriteLine($"Popping smallest! Expected: 5, Actual: {sis.PopSmallest()};");
        }

        public class SmallestInfiniteSet
        {
            private int _min;
            private HashSet<int> _removed;

            public SmallestInfiniteSet()
            {
                _min = 1;
                _removed = new();
            }

            public int PopSmallest()
            {
                var toReturn = _min;
                _removed.Add(toReturn);

                do
                {
                    _min++;
                } while (_removed.Contains(_min));

                return toReturn;
            }

            public void AddBack(int num)
            {
                if (!_removed.Contains(num)) return;

                _removed.Remove(num);
                _min = Math.Min(_min, num);
            }
        }
    }
}
