using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2751 : ISolution
    {
        public string Name => "Robot Collisions";
        public string Description => "There are n 1-indexed robots, each having a position on a line, health, and movement direction.\r\n\r\nYou are given 0-indexed integer arrays positions, healths, and a string directions (directions[i] is either 'L' for left or 'R' for right). All integers in positions are unique.\r\n\r\nAll robots start moving on the line simultaneously at the same speed in their given directions. If two robots ever share the same position while moving, they will collide.\r\n\r\nIf two robots collide, the robot with lower health is removed from the line, and the health of the other robot decreases by one. The surviving robot continues in the same direction it was going. If both robots have the same health, they are both removed from the line.\r\n\r\nYour task is to determine the health of the robots that survive the collisions, in the same order that the robots were given, i.e. final heath of robot 1 (if survived), final health of robot 2 (if survived), and so on. If there are no survivors, return an empty array.\r\n\r\nReturn an array containing the health of the remaining robots (in the order they were given in the input), after no further collisions can occur.\r\n\r\nNote: The positions may be unsorted.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            int[] positions = [3, 5, 2, 6];
            int[] healths = [10, 10, 15, 12];
            var directions = "RLRL";
            var result = SurvivedRobotsHealths(positions, healths, directions);

            // Prettify
            Console.WriteLine($"Input: positions = {positions.GetString()}, healths = {healths.GetString()}, directions = {directions}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
        {
            List<Robot> robots = [];
            for (var i  = 0; i < positions.Length; i++)
            {
                robots.Add(new()
                {
                    Health = healths[i],
                    Position = positions[i],
                    Order = i,
                    Direction = directions[i] == 'L'
                        ? Direction.Left 
                        : Direction.Right,
                });
            }

            robots.Sort();

            Stack<Robot> stack = [];
            foreach (var robot in robots)
            {
                if (robot.Direction == Direction.Right)
                {
                    stack.Push(robot);
                }
                else
                {
                    while (stack.TryPeek(out var next) && next.Direction == Direction.Right && robot.Health > 0)
                    {
                        if (next.Health < robot.Health)
                        {
                            stack.Pop();
                            robot.Health--;
                        }
                        else if (next.Health > robot.Health)
                        {
                            next.Health--;
                            robot.Health = 0;
                        }
                        else
                        {
                            stack.Pop();
                            robot.Health = 0;
                        }
                    }

                    if (robot.Health > 0)
                    {
                        stack.Push(robot);
                    }
                }
            }

            return stack.OrderBy(x => x.Order).Select(r => r.Health).ToList();
        }

        public class Robot : IComparable<Robot>
        {
            public int Health { get; set; }
            public int Position { get; set; }
            public int Order { get; set; }
            public Direction Direction { get; set; }

            public int CompareTo(Robot other)
            {
                return Position > other.Position ? 1 : -1;
            }
        }

        public enum Direction
        {
            Left,
            Right
        }
    }
}
