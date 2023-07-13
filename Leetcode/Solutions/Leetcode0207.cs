using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0207 : ISolution
    {
        public string Name => " Course Schedule";
        public string Description => "There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.\r\n\r\n    For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.\r\n\r\nReturn true if you can finish all courses. Otherwise, return false.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var numCourses = 2;
            var prerequisites = new int[][]
            {
                new int[] { 1, 0 },
                new int[] { 0, 1 }
            };
            var result = CanFinish(numCourses, prerequisites);

            // Prettify
            Console.WriteLine($"Input: numCourses = {numCourses}, data = {prerequisites.GetString()}, ");
            Console.WriteLine($"Output: {result}");
        }

        // The following question is relating to cycle detection
        // If course 'a' requires course 'b' requires course 'a', cycle detected. Therefore, not possible
        // Dfs with tracking visited courses. If new path is in visited, not possible
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, List<int>> adj = new();
            foreach (var edge in prerequisites)
            {
                if (!adj.ContainsKey(edge[0]))
                    adj[edge[0]] = new();
                adj[edge[0]].Add(edge[1]);
            }

            HashSet<int> visited = new();
            HashSet<int> possibleCourses = new();
            bool IsPossibleCourse(int i)
            {
                if (!visited.Contains(i))
                {
                    visited.Add(i);
                    var prereqs = adj.TryGetValue(i, out var pre) ? pre : new();
                    if (prereqs.All(IsPossibleCourse))
                        possibleCourses.Add(i);
                }

                return possibleCourses.Contains(i);
            }

            return Enumerable.Range(0, numCourses).All(IsPossibleCourse);
        }
    }
}
