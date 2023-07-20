using System.ComponentModel.Design;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0735 : ISolution
    {
        public string Name => "Asteroid Collision";
        public string Description => "We are given an array asteroids of integers representing asteroids in a row.\r\n\r\nFor each asteroid, the absolute value represents its size, and the sign represents its direction (positive meaning right, negative meaning left). Each asteroid moves at the same speed.\r\n\r\nFind out the state of the asteroids after all collisions. If two asteroids meet, the smaller one will explode. If both are the same size, both will explode. Two asteroids moving in the same direction will never meet.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var asteroids = new int[] { -2, -1, 1, 2 };
            var result = AsteroidCollision(asteroids);

            // Prettify
            Console.WriteLine($"Input: asteroids = {asteroids.GetString()}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public int[] AsteroidCollision(int[] asteroids)
        {
            Stack<int> result = new();

            // Only left moving bois can destroy stuff
            foreach (var asteroid in asteroids)
            {
                var size = Math.Abs(asteroid);
                var isGoingLeft = asteroid < 0;

                if (isGoingLeft)
                {
                    // While there is stuff in the stack, the top is going right, and we are bigger than the top
                    while (result.TryPeek(out var top) && top > 0 && size > top)
                        result.Pop();
                    if (result.TryPeek(out var last) && last > 0 && last >= size)
                    {
                        if (last == size) result.Pop();
                    }
                    else
                    {
                        result.Push(asteroid);
                    }
                }
                else
                {
                    result.Push(asteroid);
                }
            }

            return result.Reverse().ToArray();
        }
    }
}
