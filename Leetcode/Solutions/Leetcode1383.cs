using Leetcode.Extensions;
using System.Data;
using System.Text;

namespace Leetcode.Solutions
{
    public class Leetcode1383 : ISolution
    {
        public string Name => "Maximum Performance of a Team";
        public string Description => @"You are given two integers n and k and two integer arrays speed and efficiency both of length n. There are n engineers numbered from 1 to n. speed[i] and efficiency[i] represent the speed and efficiency of the ith engineer respectively.

            Choose at most k different engineers out of the n engineers to form a team with the maximum performance.

            The performance of a team is the sum of their engineers' speeds multiplied by the minimum efficiency among their engineers.

            Return the maximum performance of this team. Since the answer can be a huge number, return it modulo 109 + 7.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var speed = new int[] { 10, 5, 1, 7, 4, 2 };
            var efficiency = new int[] { 2, 1, 1, 1, 7, 3 };
            var n = 6;
            var k = 6;

            var result = MaxPerformance(n, speed, efficiency, k);

            // Prettify
            Console.WriteLine($"Input: n = {n}, speed = {speed.GetString()}, efficiency = {efficiency.GetString()}, k = {k}");
            Console.WriteLine($"Output: {result}");
        }

        public int MaxPerformance(int n, int[] speed, int[] efficiency, int k)
        {
            long maxTeamPower = 0;
            long totalSpeed = 0;

            int[][] ord = new int[n][];
            for (int i = 0; i < n; i++)
                ord[i] = new int[] { efficiency[i], speed[i] };

            var sorted = ord.OrderByDescending(n => n[0]).ToArray();
            PriorityQueue<int, int> pq = new();
            foreach (int[] pair in sorted)
            {
                int engSpeed = pair[1];
                pq.Enqueue(engSpeed, engSpeed);
                if (pq.Count <= k) totalSpeed += engSpeed;
                else totalSpeed += engSpeed - pq.Dequeue();
                maxTeamPower = Math.Max(maxTeamPower, totalSpeed * pair[0]);

            }

            return (int)(maxTeamPower % 1000000007);
        }
    }

    // This implementation uses DFS and can be massive. It simply takes too long, but it works
    //public class Leetcode1383
    //{
    //    public static long MaxPerformanceAmount = 0;
    //    public Dictionary<int, (int Speed, int Efficiency)> Engineers;
    //    public HashSet<int> TempTeam;
    //    public long TempSum;

    //    public int MaxPerformance(int n, int[] speed, int[] efficiency, int k)
    //    {
    //        // Init
    //        Engineers = new Dictionary<int, (int Speed, int Efficiency)>();
    //        for (int i = 0; i < n; i++)
    //            Engineers.Add(i + 1, (speed[i], efficiency[i]));
    //        TempTeam = new();
    //        MaxPerformanceAmount = 0;
    //        TempSum = 0;

    //        DFS(n, 1, k);

    //        return (int)(MaxPerformanceAmount % (Math.Pow(10, 9) + 7));
    //    }

    //    private void DFS(int n, int k, int depth)
    //    {
    //        if (depth == 0)
    //        {
    //            //EvaluateTeam();
    //            return;
    //        }

    //        for (int i = k; i <= n; ++i)
    //        {
    //            TempTeam.Add(i);
    //            TempSum += Engineers[i].Speed;
    //            DFS(n, i + 1, depth - 1);

    //            // Remove last inserted element
    //            EvaluateTeam();
    //            TempTeam.Remove(i);
    //            TempSum -= Engineers[i].Speed;
    //        }
    //    }

    //    private static void PrintArray(int[] array)
    //    {
    //        Console.WriteLine("[{0}]", string.Join(", ", array));
    //    }

    //    public void PrintTeamDetails()
    //    {
    //        foreach (int eng in TempTeam)
    //        {
    //            if (eng == 0) return;
    //            Console.WriteLine($"Number: {eng}, Speed: {Engineers[eng].Speed}, Efficiency: {Engineers[eng].Efficiency}.");
    //        }
    //        Console.WriteLine($"Speed sum: {TempTeam.Sum(n => Engineers[n].Speed)}, Min Efficiency: {TempTeam.Min(n => Engineers[n].Efficiency)}, Total: {TempTeam.Sum(n => Engineers[n].Speed) * TempTeam.Min(n => Engineers[n].Efficiency)}");
    //        Console.WriteLine();
    //    }

    //    public void EvaluateTeam()
    //    {
    //        //PrintArray(TempTeam);
    //         PrintTeamDetails();
    //        long teamPower = 0;
    //        //TempTeam.Sum(n => Engineers[n].Speed) * TempTeam.Where(n => n > 0).Min(n => Engineers[n].Efficiency);
    //        int min = int.MaxValue;
    //        foreach(int i in TempTeam)
    //        {
    //            var eff = Engineers[i].Efficiency;
    //            if (eff < min)
    //                min = eff;
    //        }
    //        teamPower = TempSum * min;
    //        if (teamPower > MaxPerformanceAmount)
    //            MaxPerformanceAmount = teamPower;
    //    }
    //}
}
