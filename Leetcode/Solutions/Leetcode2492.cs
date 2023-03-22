using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2492 : ISolution
    {
        public string Name => "Minimum Score of a Path Between Two Cities";
        public string Description => "You are given a positive integer n representing n cities numbered from 1 to n. You are also given a 2D array roads where roads[i] = [ai, bi, distancei] indicates that there is a bidirectional road between cities ai and bi with a distance equal to distancei. The cities graph is not necessarily connected.\r\n\r\nThe score of a path between two cities is defined as the minimum distance of a road in this path.\r\n\r\nReturn the minimum possible score of a path between cities 1 and n.\r\n\r\nNote:\r\n\r\n    A path is a sequence of roads between two cities.\r\n    It is allowed for a path to contain the same road multiple times, and you can visit cities 1 and n multiple times along the path.\r\n    The test cases are generated such that there is at least one path between 1 and n.\r\n";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var n = 4;
            var roads = new int[][] 
            { 
                new int[] { 1, 2, 9 },
                new int[] { 2, 3, 6 },
                new int[] { 2, 4, 5 },
                new int[] { 1, 4, 7 },
            };
            var result = MinScore(n, roads);

            // Prettify
            Console.WriteLine($"Input:  n = {n}, roads = [{string.Join(", ", roads.Select(r => r.GetString()))}]");
            Console.WriteLine($"Output: {result}");
        }

        public int MinScore(int n, int[][] roads)
        {
            Dictionary<int, List<(int dest, int cost)>> paths = new();
            foreach (var road in roads)
            {
                if (paths.ContainsKey(road[0]))
                {
                    paths[road[0]].Add((road[1], road[2]));
                }
                else
                {
                    paths[road[0]] = new() { (road[1], road[2]) };
                }

                if (paths.ContainsKey(road[1]))
                {
                    paths[road[1]].Add((road[0], road[2]));
                }
                else
                {
                    paths[road[1]] = new() { (road[0], road[2]) };
                }
            }

            Queue<int> queue = new();
            queue.Enqueue(1);

            bool[] visited = new bool[n];
            int minValue = int.MaxValue;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (paths.TryGetValue(node, out var list))
                {
                    foreach (var dest in list)
                    {
                        minValue = Math.Min(minValue, dest.cost);
                        if (visited[dest.dest - 1]) continue;

                        visited[dest.dest - 1] = true;
                        queue.Enqueue(dest.dest);
                    }
                }
            }

            return minValue;
        }
    }
}
