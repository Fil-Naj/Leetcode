using Leetcode;
using Leetcode.Solutions;

public class Solution
{
    public static void Main(string[] args)
    {
        ISolution solution = new Leetcode198();
        // Console.WriteLine(solution.GetUrlString());
        //PrintCompletedDifficulties();
        solution.Solve();
    }

    private static readonly HashSet<ISolution> Completed = new()
    {
        new Leetcode1(),
        new Leetcode2(),
        new Leetcode3(),
        new Leetcode4(),
        new Leetcode6(),
        new Leetcode12(),
        new Leetcode19(),
        new Leetcode38(),
        new Leetcode42(),
        new Leetcode48(),
        new Leetcode50(),
        new Leetcode53(), // Also a dp problem, good start for it
        new Leetcode88(),
        new Leetcode94(),
        new Leetcode112(),
        new Leetcode113(),
        new Leetcode121(), // also sort of dp
        new Leetcode219(),
        new Leetcode234(),
        new Leetcode237(),
        new Leetcode326(),
        new Leetcode334(),
        new Leetcode338(), // Could be better. Search for Hamming Weight or Population Count
        new Leetcode342(),
        new Leetcode350(),
        new Leetcode393(),
        new Leetcode429(),
        new Leetcode433(),
        new Leetcode557(),
        new Leetcode622(),
        new Leetcode623(),
        new Leetcode653(),
        new Leetcode658(),
        new Leetcode692(),
        new Leetcode718(),
        new Leetcode838(),
        new Leetcode976(),
        new Leetcode985(),
        new Leetcode987(),
        new Leetcode990(),
        new Leetcode1328(),
        new Leetcode1335(), // DP problem, revisit in future
        new Leetcode1383(),
        new Leetcode1457(),
        new Leetcode1531(),  // Revisit to better understand dp
        new Leetcode1662(),
        new Leetcode1680(),
        new Leetcode1706(),
        new Leetcode1832(),
        new Leetcode1996(),
    };

    private static void PrintCompletedDifficulties()
    {
        Dictionary<Difficulty, int> difficulties = new()
        {
            { Difficulty.Easy, 0 },
            { Difficulty.Medium, 0 },
            { Difficulty.Hard, 0 },
        };

        foreach (var solution in Completed)
            difficulties[solution.Difficulty]++;

        Console.WriteLine($"Easy: {difficulties[Difficulty.Easy]}, Medium: {difficulties[Difficulty.Medium]}, Hard: {difficulties[Difficulty.Hard]}");
        Console.WriteLine($"Total: {Completed.Count}");
    }
}